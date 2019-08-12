using System;
using System.IO;
using System.Windows;
using SerwisInstaller.Main;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Logs
{
    public class IPConfigLog : Installer
    {
        private string _logPath; // Pobrane w metodzie zawartej w konstruktorze WPF
        private int option =1; // Pobrane w metodzie zawartej w konstruktorze WPF
        public IPConfigLog()
        {
            this.StartInfo.Verb = "runas";
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false; // Koniecznie musi byc false, zeby nie uruchamiało shella systemu! inaczej CMD nie przyjmie danych!
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            _logPath = LocalParameters.ipLogPath;
        }
        public void GenerateIPConfigLog()
        {
            if (option == 1)
            {
                try
                {
                    this.StartInfo.FileName = "Cmd.exe";
                    this.StartInfo.Arguments = ($@"/c ipconfig -all > C:\{LocalParameters.inventoryNumber}.txt");
                    this.Start();
                    this.WaitForExit();
                    File.Move($@"C:\{LocalParameters.inventoryNumber}.txt", $@"{_logPath}{LocalParameters.inventoryNumber}.txt");
                    LogWriter.LogWrite($"Utworzono ipconfig Log o nazwie {LocalParameters.inventoryNumber} w lokacji {_logPath}");
                }
                catch (Exception e)
                {
                    MessageBox.Show("wystąpił błąd " + e.Message, "Błąd");
                    LogWriter.LogWrite(e.ToString());
                }
                finally
                {
                    MessageBox.Show($"Utworzono ipconfig Log o nazwie {LocalParameters.inventoryNumber} w lokacji {_logPath}", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie generowania logu.");
            }
        }
    }
}
