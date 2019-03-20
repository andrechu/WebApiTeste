using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Helper
{
    public static class Util
    {
        public static bool SetDate(string dateInYourSystemFormat)
        {
            try
            {
                var proc = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    CreateNoWindow = true,
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Verb = "runas",
                    Arguments = "/C date " + dateInYourSystemFormat
                };

                Process.Start(proc);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
