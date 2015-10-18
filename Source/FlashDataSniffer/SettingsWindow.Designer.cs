namespace FlashDataSniffer
{
  partial class SettingsWindow
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
      this.checkListBox = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // checkListBox
      // 
      this.checkListBox.FormattingEnabled = true;
      this.checkListBox.Items.AddRange(new object[] {
            "Show On Startup.",
            "Sniff Current Inserted Removable Drives In SilentMode."});
      this.checkListBox.Location = new System.Drawing.Point(3, 12);
      this.checkListBox.Name = "checkListBox";
      this.checkListBox.Size = new System.Drawing.Size(288, 34);
      this.checkListBox.TabIndex = 0;
      this.checkListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListBox_ItemCheck);
      // 
      // SettingsWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 60);
      this.Controls.Add(this.checkListBox);
      this.MaximizeBox = false;
      this.Name = "SettingsWindow";
      this.Text = "Settings";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox checkListBox;

  }
}