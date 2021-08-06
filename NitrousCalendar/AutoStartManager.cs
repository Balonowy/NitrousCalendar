using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace NitrousCalendar
{
    [SupportedOSPlatform("windows")]
    public static class AutoStartManager
    {
        private static string AutoStartShortcut { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName + ".lnk"); }

        public static bool AutoStart
        {
            get
            {
                if (System.IO.File.Exists(AutoStartShortcut))
                {
                    //  Load existing shortcut
                    WshShell shell = new WshShell();
                    IWshShortcut link = (IWshShortcut)shell.CreateShortcut(AutoStartShortcut);

                    //  Check target path
                    if (link.TargetPath == Application.ExecutablePath)
                        return true;
                }

                return false;
            }
            set
            {
                Directory.CreateDirectory(Path.GetDirectoryName(AutoStartShortcut));
                System.IO.File.Delete(AutoStartShortcut);

                if (value)
                {
                    //  Create the shortcut
                    WshShell shell = new WshShell();
                    IWshShortcut link = (IWshShortcut)shell.CreateShortcut(AutoStartShortcut);
                    link.TargetPath = Application.ExecutablePath;
                    link.WorkingDirectory = Application.StartupPath;
                    link.Save();
                }
            }
        }
    }
}
