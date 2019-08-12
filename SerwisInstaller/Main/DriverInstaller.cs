using System;
using System.Windows;
using SerwisInstaller.Logs;
using System.IO;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Main
{
    public class DriverInstaller : Installer
    {
        private string _driverPath;
        private string _finalPath;
        public DriverInstaller()
        {
            _finalPath = LocalParameters.driverFinalPath;
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            _driverPath = LocalParameters.driverPath;
        }
        public DriverInstaller(bool connection) : this()
        {
            if(connection == false)
            {

            }
            if(connection == true)
            {
                _finalPath = LocalParameters.driverFinalPath;
                this.StartInfo.Verb = "runas";
                this.StartInfo.UseShellExecute = false;
                this.StartInfo.CreateNoWindow = false;
                this.StartInfo.RedirectStandardInput = true;
                this.StartInfo.RedirectStandardOutput = true;
                _driverPath = LocalParameters.onlineDriverPath;
            }
        }
        public void InstallDriver()
        {
            try
            {
                DirectoryInfo filePath = new DirectoryInfo(_driverPath); // program tworzy zmienna i przypisuje obiekt DI, o sciezce sterownika z pendrive
                Directory.CreateDirectory(_finalPath); // tworzy sciezke docelowa na dysku C:
                FileInfo[] files = filePath.GetFiles(); // Pobiera pliki z pendrive
                foreach (FileInfo file in files) // Wykonuje utworzenie nowej sciezki dla kazdego pliku + kopiuje do sciezki z nadpisem :)
                {
                    string temppath = Path.Combine(_finalPath, file.Name);
                    file.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c C:\Windows\sysnative\pnputil.exe /i /a C:\Data\64\ezusb.inf"; // wywołanie metody z argumentem w CMD
                this.Start();
                this.StandardOutput.Close();
                this.WaitForExit();
                LogWriter.LogWrite("Sterownik EZPU100 do czytnika kart został zainstalowany.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd");
                LogWriter.LogWrite(e.ToString());
            }
            finally
            {
                MessageBox.Show("Sterowniki czytnika EKD EZPU100 zainstalowano poprawnie!", "Uwaga");
            }
        }
    }

}
