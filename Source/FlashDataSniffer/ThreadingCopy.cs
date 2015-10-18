using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FlashDataSniffer
{
  /*
   * This is the class that does the actual copy
   */
  public class ThreadingCopy
  {
    // CONSTRUCTOR(S):
    #region
    public ThreadingCopy(string SourcePath, string DestinationPath, List<string> DataFormat, bool Recursive)
    {
      this.SourcePath = SourcePath;
      this.DestinationPath = DestinationPath;
      this.DataFormat = DataFormat;
      this.Recursive = Recursive;
      CopyThread = new Thread(() => CopyFiles());
    }
    #endregion

    // PROPERTIES:
    #region

    // This is the thread that does the copy.
    public Thread CopyThread
    { get; private set; }

    // Here lies the data which we wanna copy.
    public string SourcePath
    { get; set; }

    // Here where's the data will land.
    public string DestinationPath
    { get; set; }

    // This is a list of all file extensions that we wanna copy from our source.
    public List<string> DataFormat
    { get; set; }

    // This indicates whether our copy will be Recursive (from the source down to all sub-directories)
    // or just a normal copy (only from the source directory).
    public bool Recursive
    { get; set; }

    #endregion

    // METHODS:
    #region
    // This is the method that does the actual copy according to all the specs mentioned above.
    void CopyFiles()
    {
      try
      {
        SearchOption option = (Recursive) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        foreach (string format in DataFormat)
        {
          Directory.CreateDirectory(DestinationPath + "\\" + format);
          foreach (string _file in Directory.EnumerateFiles(SourcePath, "*" + format, option))
          {
            string FileName = Path.GetFileName(_file);
            if (!File.Exists(DestinationPath + "\\" + format + "\\" + FileName))
            {
              File.Copy(_file, DestinationPath + "\\" + format + "\\" + FileName);
            }
          }
        }
        // end of copy is reached at this point.
        CopyThread.Abort();
      }
      // not doing anything in the catch thus avoiding any noise.
      catch { }
    }

    public void StartCopy()
    {
      CopyThread.Start();
    }
    #endregion
  }
}
