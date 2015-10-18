namespace FlashDataSniffer
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.Timer_SilentMode = new System.Windows.Forms.Timer(this.components);
      this.ToolTip_SniffingFormats = new System.Windows.Forms.ToolTip(this.components);
      this.ToolTip_SniffDrive = new System.Windows.Forms.ToolTip(this.components);
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.ToolTip_SilentMode = new System.Windows.Forms.ToolTip(this.components);
      this.ToolTip_BlackBox = new System.Windows.Forms.ToolTip(this.components);
      this.SettingsTab = new System.Windows.Forms.TabPage();
      this.Settings_CheckList = new System.Windows.Forms.CheckedListBox();
      this.MainTab = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.ApplyFormats_Button = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.sniffingFormats_TextBox = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.RemovableDrives_ComboBox = new System.Windows.Forms.ComboBox();
      this.SniffDrive_Button = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.BlackBoxLocation_TextBox = new System.Windows.Forms.TextBox();
      this.Button_BlackBox = new System.Windows.Forms.Button();
      this.SilentMode_Button = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.AboutTab = new System.Windows.Forms.TabPage();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.SettingsTab.SuspendLayout();
      this.MainTab.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.AboutTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // Timer_SilentMode
      // 
      this.Timer_SilentMode.Tick += new System.EventHandler(this.SilentModeTimer_Tick);
      // 
      // timer2
      // 
      this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
      // 
      // SettingsTab
      // 
      this.SettingsTab.Controls.Add(this.Settings_CheckList);
      this.SettingsTab.Location = new System.Drawing.Point(4, 22);
      this.SettingsTab.Name = "SettingsTab";
      this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
      this.SettingsTab.Size = new System.Drawing.Size(217, 363);
      this.SettingsTab.TabIndex = 1;
      this.SettingsTab.Text = "Settings";
      this.SettingsTab.UseVisualStyleBackColor = true;
      // 
      // Settings_CheckList
      // 
      this.Settings_CheckList.BackColor = System.Drawing.SystemColors.Control;
      this.Settings_CheckList.CheckOnClick = true;
      this.Settings_CheckList.FormattingEnabled = true;
      this.Settings_CheckList.Items.AddRange(new object[] {
            "Show On Startup.",
            "SCIRD Mode."});
      this.Settings_CheckList.Location = new System.Drawing.Point(3, 18);
      this.Settings_CheckList.Name = "Settings_CheckList";
      this.Settings_CheckList.Size = new System.Drawing.Size(208, 349);
      this.Settings_CheckList.TabIndex = 0;
      this.Settings_CheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Settings_CheckList_ItemCheck);
      // 
      // MainTab
      // 
      this.MainTab.Controls.Add(this.groupBox2);
      this.MainTab.Controls.Add(this.groupBox1);
      this.MainTab.Controls.Add(this.groupBox3);
      this.MainTab.Location = new System.Drawing.Point(4, 22);
      this.MainTab.Name = "MainTab";
      this.MainTab.Padding = new System.Windows.Forms.Padding(3);
      this.MainTab.Size = new System.Drawing.Size(217, 363);
      this.MainTab.TabIndex = 0;
      this.MainTab.Text = "Main";
      this.MainTab.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.ApplyFormats_Button);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.sniffingFormats_TextBox);
      this.groupBox2.Location = new System.Drawing.Point(54, 112);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(114, 175);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      // 
      // ApplyFormats_Button
      // 
      this.ApplyFormats_Button.Location = new System.Drawing.Point(8, 144);
      this.ApplyFormats_Button.Name = "ApplyFormats_Button";
      this.ApplyFormats_Button.Size = new System.Drawing.Size(100, 23);
      this.ApplyFormats_Button.TabIndex = 11;
      this.ApplyFormats_Button.Text = "ApplyNewFormats";
      this.ApplyFormats_Button.UseVisualStyleBackColor = true;
      this.ApplyFormats_Button.Click += new System.EventHandler(this.ApplyFormats_Button_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "SniffingFormats";
      // 
      // sniffingFormats_TextBox
      // 
      this.sniffingFormats_TextBox.Location = new System.Drawing.Point(8, 29);
      this.sniffingFormats_TextBox.Multiline = true;
      this.sniffingFormats_TextBox.Name = "sniffingFormats_TextBox";
      this.sniffingFormats_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.sniffingFormats_TextBox.Size = new System.Drawing.Size(100, 109);
      this.sniffingFormats_TextBox.TabIndex = 7;
      this.sniffingFormats_TextBox.TextChanged += new System.EventHandler(this.Formats_TextBox_TextChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.RemovableDrives_ComboBox);
      this.groupBox1.Controls.Add(this.SniffDrive_Button);
      this.groupBox1.Location = new System.Drawing.Point(12, 293);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(193, 58);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(91, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "RemovableDrives";
      // 
      // RemovableDrives_ComboBox
      // 
      this.RemovableDrives_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.RemovableDrives_ComboBox.FormattingEnabled = true;
      this.RemovableDrives_ComboBox.Location = new System.Drawing.Point(6, 31);
      this.RemovableDrives_ComboBox.Name = "RemovableDrives_ComboBox";
      this.RemovableDrives_ComboBox.Size = new System.Drawing.Size(92, 21);
      this.RemovableDrives_ComboBox.TabIndex = 3;
      this.RemovableDrives_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RemovableDrives_ComboBox_SelectedIndexChanged);
      // 
      // SniffDrive_Button
      // 
      this.SniffDrive_Button.Location = new System.Drawing.Point(104, 30);
      this.SniffDrive_Button.Name = "SniffDrive_Button";
      this.SniffDrive_Button.Size = new System.Drawing.Size(80, 21);
      this.SniffDrive_Button.TabIndex = 1;
      this.SniffDrive_Button.Text = "SniffDrive";
      this.SniffDrive_Button.UseVisualStyleBackColor = true;
      this.SniffDrive_Button.Click += new System.EventHandler(this.SniffDrive_Button_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.BlackBoxLocation_TextBox);
      this.groupBox3.Controls.Add(this.Button_BlackBox);
      this.groupBox3.Controls.Add(this.SilentMode_Button);
      this.groupBox3.Location = new System.Drawing.Point(12, 6);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(193, 100);
      this.groupBox3.TabIndex = 12;
      this.groupBox3.TabStop = false;
      // 
      // BlackBoxLocation_TextBox
      // 
      this.BlackBoxLocation_TextBox.Location = new System.Drawing.Point(7, 74);
      this.BlackBoxLocation_TextBox.Name = "BlackBoxLocation_TextBox";
      this.BlackBoxLocation_TextBox.ReadOnly = true;
      this.BlackBoxLocation_TextBox.Size = new System.Drawing.Size(177, 20);
      this.BlackBoxLocation_TextBox.TabIndex = 5;
      // 
      // Button_BlackBox
      // 
      this.Button_BlackBox.Location = new System.Drawing.Point(7, 47);
      this.Button_BlackBox.Name = "Button_BlackBox";
      this.Button_BlackBox.Size = new System.Drawing.Size(177, 22);
      this.Button_BlackBox.TabIndex = 2;
      this.Button_BlackBox.Text = "BlackBox Location";
      this.Button_BlackBox.UseVisualStyleBackColor = true;
      this.Button_BlackBox.Click += new System.EventHandler(this.Browse_Button_Click);
      // 
      // SilentMode_Button
      // 
      this.SilentMode_Button.Location = new System.Drawing.Point(7, 19);
      this.SilentMode_Button.Name = "SilentMode_Button";
      this.SilentMode_Button.Size = new System.Drawing.Size(177, 22);
      this.SilentMode_Button.TabIndex = 0;
      this.SilentMode_Button.Text = "GoSilent";
      this.SilentMode_Button.UseVisualStyleBackColor = true;
      this.SilentMode_Button.Click += new System.EventHandler(this.SilentMode_Button_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.MainTab);
      this.tabControl1.Controls.Add(this.SettingsTab);
      this.tabControl1.Controls.Add(this.AboutTab);
      this.tabControl1.Location = new System.Drawing.Point(12, 9);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(225, 389);
      this.tabControl1.TabIndex = 15;
      // 
      // AboutTab
      // 
      this.AboutTab.Controls.Add(this.pictureBox1);
      this.AboutTab.Location = new System.Drawing.Point(4, 22);
      this.AboutTab.Name = "AboutTab";
      this.AboutTab.Size = new System.Drawing.Size(217, 363);
      this.AboutTab.TabIndex = 2;
      this.AboutTab.Text = "About";
      this.AboutTab.UseVisualStyleBackColor = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Image = global::FlashDataSniffer.Properties.Resources._545818_219739918143441_480537440_n1;
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(214, 357);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(242, 410);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "SniffingFreak 1.0.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.SettingsTab.ResumeLayout(false);
      this.MainTab.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.AboutTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer Timer_SilentMode;
    private System.Windows.Forms.ToolTip ToolTip_SniffingFormats;
    private System.Windows.Forms.ToolTip ToolTip_SniffDrive;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.ToolTip ToolTip_SilentMode;
    private System.Windows.Forms.ToolTip ToolTip_BlackBox;
    private System.Windows.Forms.TabPage SettingsTab;
    private System.Windows.Forms.CheckedListBox Settings_CheckList;
    private System.Windows.Forms.TabPage MainTab;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button ApplyFormats_Button;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox sniffingFormats_TextBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox RemovableDrives_ComboBox;
    private System.Windows.Forms.Button SniffDrive_Button;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox BlackBoxLocation_TextBox;
    private System.Windows.Forms.Button Button_BlackBox;
    private System.Windows.Forms.Button SilentMode_Button;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage AboutTab;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}

