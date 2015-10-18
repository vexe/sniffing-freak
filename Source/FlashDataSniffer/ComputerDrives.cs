using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FlashDataSniffer
{
  /*
   * This class helped me to monitor the insertion/removal of the drives
   */
  public class ComputerDrives
  {
    // PROPERTIES:
    #region
    public List<DriveInfo> Removable_Disk_Drives
    { get; private set; }
    public List<DriveInfo> CD_ROM_Drives
    { get; private set; }
    public List<DriveInfo> HardDisk_Drives
    { get; private set; }
    #endregion

    // CONSTRUCTOR(S):
    #region
    public ComputerDrives()
    {
      HardDisk_Drives = GetCurrentDrives(DriveType.Fixed);
      Removable_Disk_Drives = GetCurrentDrives(DriveType.Removable);
      CD_ROM_Drives = GetCurrentDrives(DriveType.CDRom);
    }
    #endregion

    // METHODS:
    #region
    public List<DriveInfo> GetCurrentDrives(DriveType type)
    {
      List<DriveInfo> drives = new List<DriveInfo>();
      foreach (DriveInfo drive in DriveInfo.GetDrives())
        if (drive.DriveType == type)
          drives.Add(drive);
      return drives;
    }

    // this method just updates the value of the Removable_Disk_Drives value
    // so that it'll store the current inserted removable drives.
    public void UpdateRemovableDrives()
    {
      Removable_Disk_Drives = GetCurrentDrives(DriveType.Removable);
    }

    // this returns true if a removable drive has been inserted, else false.
    public bool HasInsertedNewRemovableDrive()
    {
      int OldNumberOfDrives = Removable_Disk_Drives.Count;
      int NewNumberOfDrives = GetCurrentDrives(DriveType.Removable).Count;
      return (NewNumberOfDrives > OldNumberOfDrives);
    }

    // this returns true if a removable drive has been removed, else false.
    public bool HasRemovedRemovableDrive()
    {
      int OldNumberOfDrives = Removable_Disk_Drives.Count;
      int NewNumberOfDrives = GetCurrentDrives(DriveType.Removable).Count;
      return (NewNumberOfDrives < OldNumberOfDrives);
    }

    // this returns a list of the newly inserted removable drives.
    public List<DriveInfo> GetNewlyInsertedRemovableDrives()
    {
      List<DriveInfo> NewlyInsertedDrives = new List<DriveInfo>();

      // getting all the current removable drives (the old and new ones):
      List<DriveInfo> CurrentRemovableDrives = GetCurrentDrives(DriveType.Removable);

      // remember, Removable_Disk_Drives is a list of all the old drives (doesn't include the ones inserted)
      // so the newly inserted drives = (Removable_Disk_Drives (UNION) CurrentRemovableDrives) - (Removable_Disk_Drives (INTERCECTION) CurrentRemovableDrives)
      // For example, if we had a drive, say F:\ in Removable_Disk_Drives and we inserted a new one, say G:\
      // now, CurrentRemovableDrives will be storing both F:\ and G:\ .. So the newly inserted is only G:\
      // but there's a case where we first have no drive inserted (Removable_Disk_Drives.Count == 0)
      // This means that the newly inserted drives are the whole drives in CurrentRemovableDrives.
      for (int i = 0; i < CurrentRemovableDrives.Count; i++)
      {
        if (Removable_Disk_Drives.Count == 0)
        {
          NewlyInsertedDrives.Add(CurrentRemovableDrives[i]);
        }
        else
        {
          for (int j = 0; j < Removable_Disk_Drives.Count; j++)
            if (CurrentRemovableDrives[i].Name != Removable_Disk_Drives[j].Name) // for some reason the comparsion didn't really work when I did: if (CurrentRemovableDrives[i] != Removable_Disk_Drives[j])
              NewlyInsertedDrives.Add(CurrentRemovableDrives[i]);
        }
      }
      return NewlyInsertedDrives;
    }
    #endregion
  }
}