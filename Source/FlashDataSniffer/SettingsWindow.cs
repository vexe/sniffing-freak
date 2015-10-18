using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FlashDataSniffer
{
  public partial class SettingsWindow : Form
  {
    ProgramSettings PersonalSettings = new ProgramSettings();
    static public bool HasChangedSomething = false;
    CheckState ShowOnStartup_OldValue;
    CheckState SniffCurrentRemovalbeDrivesInSilentMode_OldValue;

    public SettingsWindow(ProgramSettings PersonalSettings)
    {
      InitializeComponent();

      // this is just to check an item by just a single click on it.
      checkListBox.CheckOnClick = true;

      this.PersonalSettings = PersonalSettings;
      //LoadSettings();
      ShowOnStartup_OldValue = checkListBox.GetItemCheckState(0);
      SniffCurrentRemovalbeDrivesInSilentMode_OldValue = checkListBox.GetItemCheckState(1);
    }

    // EVENTS:
    #region
    private void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      
      
    }
    private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      HasChangedSomething = (ShowOnStartup_OldValue != checkListBox.GetItemCheckState(0) || SniffCurrentRemovalbeDrivesInSilentMode_OldValue != checkListBox.GetItemCheckState(1));
    }
    #endregion
    
    // METHODS:
    #region
    
    #endregion
  }
}
