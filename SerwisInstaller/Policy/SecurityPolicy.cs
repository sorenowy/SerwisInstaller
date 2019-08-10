using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using SerwisInstaller.Configuration;
using SerwisInstaller.Main;
using SerwisInstaller.Logs;

namespace SerwisInstaller.Policy
{
    public class SecurityPolicy : DriverInstaller
    {
        private string _finalPath; //Pobrane w metodzie zawartej w konstruktorze WPF
        private string _policyPath; //Pobrane w metodzie zawartej w konstruktorze WPF
        public SecurityPolicy()
        {
            _finalPath = LocalParameters.policyFinalDataPath;
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            _policyPath = LocalParameters.policyCertPath;
        }
        public void ApplySecurityPolicy()
        {
            try
            {
                DirectoryInfo dirPath = new DirectoryInfo(_policyPath); // Tworzenie zmiennej ze sciezka polityki na pendrive
                Directory.CreateDirectory(_finalPath); // Utworzenie sciezki polityki na dysku C
                FileInfo[] files = dirPath.GetFiles(); // Pobranie plikow
                foreach (FileInfo file in files) // Kopiowanie wszystkiego do nowej lokacji
                {
                    string temppath = Path.Combine(_finalPath, file.Name);
                    file.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c Secedit /configure /db secedit.sdb /cfg C:\Data\polityka\politykabezp.inf"; // Wywołanie komendy
                this.Start();
                this.StandardOutput.Close();
                this.WaitForExit();
                /* this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c Secedit /refreshpolicy machine_policy /enforce /quiet"; */ // Można wykonać załadowanie automatyczne polityki bez restartowania komputera tym poleceniem!
                LogWriter.LogWrite("Zainstalowano politykę bezpieczeństwa.");
                MessageBox.Show("Polityka bezpieczeństwa została zainstalowana.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite(e.ToString());
                MessageBox.Show(e.Message, "Błąd");

            }
        }
    }
}
