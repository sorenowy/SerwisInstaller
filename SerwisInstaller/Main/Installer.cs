using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SerwisInstaller.Main
{
    class Installer : Process
    {
        public Installer()
        {
            this.StartInfo.UseShellExecute = true;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.WorkingDirectory = @"C:\Data\";
        }
        public Installer(bool netconnection)
        {
            if (netconnection == false)
            {

            }
            else if (netconnection == true)
            {

            }
        }
        public void InstallLotus(int option)
        {
            if (option == 0)
            {
                this.StartInfo.FileName = "LotusNotesBasic853.exe";
                this.Start();
                this.WaitForExit();
            }
            if (option == 1)
            {
                this.StartInfo.FileName = "LotusNotesStd853.exe";
                this.Start();
                this.WaitForExit();
            }
        }
    }
}
