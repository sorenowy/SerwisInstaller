using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using SerwisInstaller.Configuration;
using SerwisInstaller.Logs;

namespace SerwisInstaller.Main
{
    public class Installer : Process
    {
        private string _dataPath;
        public Installer()
        {
        }
        public Installer(bool netconnection)
        {
            if (netconnection == false)
            {
                this.StartInfo.UseShellExecute = true;
                this.StartInfo.CreateNoWindow = false;
                _dataPath = LocalParameters.installationDataPath;
                this.StartInfo.WorkingDirectory = _dataPath;
            }
            else if (netconnection == true)
            {
                this.StartInfo.UseShellExecute = true;
                this.StartInfo.CreateNoWindow = false;
                _dataPath = @"\\192.168.0.54\Serwis\KWPInstaller\Data\";
                this.StartInfo.WorkingDirectory = _dataPath;
            }
        }
        public void ShitRemover()
        {
            try
            {
                this.StartInfo.FileName = "PCDecrapifier.exe";
                this.Start();
                LogWriter.LogWrite("Wyczyszczono komputer z shitu!");
                this.WaitForExit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void LotusInstaller(int option)
        {
            try
            {
                if (option == 0)
                {
                    this.StartInfo.FileName = "LotusNotesBasic853.exe";
                    this.Start();
                    LogWriter.LogWrite("Trwa instalacja Klienta Lotus Notes 8.5.3 Basic...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano klienta Lotus Notes 8.5.3 Basic.");
                }
                else if (option == 1)
                {
                    this.StartInfo.FileName = "LotusNotesStd853.exe";
                    this.Start();
                    LogWriter.LogWrite("Trwa instalacja Klienta Lotus Notes 8.5.3 Standard...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano klienta Lotus Notes 8.5.3 Standard.");
                }
                else if (option == 2)
                {
                    this.StartInfo.FileName = "thunderbird.exe";
                    this.Start();
                    LogWriter.LogWrite("Trwa instalacja Klienta Mozilla Thunderbird...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano klienta Mozilla Thunderbird.");
                }
                else
                {
                    MessageBox.Show("Nie wybrano żadnego lotusa.","Uwaga");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void BaseInstaller()
        {
            try
            {
                this.StartInfo.FileName = "Firefox.exe";
                this.Start();
                LogWriter.LogWrite("Instaluję Firefox 66.0...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano Firefox 66.0.");
                this.StartInfo.FileName = "7z1900.exe";
                this.Start();
                LogWriter.LogWrite("Instaluję 7-zip...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano 7-zip.");
                this.StartInfo.FileName = "Adobe11.exe";
                this.StartInfo.Arguments = string.Format($"/qn /i ALLUSERS=1 {this.StartInfo.WorkingDirectory}");
                this.Start();
                LogWriter.LogWrite("Instaluję Adobe Reader XI...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano Adobe Reader XI.");
                this.StartInfo.FileName = "KLite1504.exe";
                this.Start();
                LogWriter.LogWrite("Trwa instalacja K-Lite Codec 15.04 Standard...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano K-Lite Codec 15.04 Standard.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void InternetInstaller()
        {
            try
            {
                this.BaseInstaller();
                this.StartInfo.FileName = "EsetKWP64.exe";
                this.Start();
                LogWriter.LogWrite("Trwa instalowanie Oprogramowania ESET AV version 8 64bit...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano Oprogramowanie antywirusowe ESET.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void CWIInstaller()
        {
            this.InternetInstaller();
        }
        public void PSTDInstaller()
        {
            try
            {
                this.BaseInstaller();
                this.StartInfo.FileName = "java765.exe";
                this.Start();
                LogWriter.LogWrite("Trwa instalacja Java Runtime Enviroment 7u65 dla UKSP...");
                this.WaitForExit();
                LogWriter.LogWrite("Zainstalowano JRE 7u65.");
                this.StartInfo.FileName = @"KlientSWOP_CD\setup.exe";
                this.Start();
                LogWriter.LogWrite("Trwa instalacja SWOP...");
                this.WaitForExit();
                LogWriter.LogWrite("Instalacja SWOP ukończona.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }

        public void EKDAuthInstaller(int option)
        {
            try
            {
                if (option == 0)
                {
                    this.StartInfo.FileName = "msiexec.exe";
                    this.StartInfo.Arguments = string.Format("/i {0}", $@"{this.StartInfo.WorkingDirectory}Encard\setup.msi");
                    this.Start();
                    LogWriter.LogWrite("Instaluję Encard 2.1.0...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano Encarda 2.1.0");
                }
                else if (option == 1)
                {
                    this.StartInfo.FileName = "msiexec.exe";
                    this.StartInfo.Arguments = string.Format("/i {0}", $@"{this.StartInfo.WorkingDirectory}encard64bit\encard.msi");
                    this.Start();
                    Console.WriteLine("Instaluję Encard 4.1.6...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano Encard 4.1.6");
                }
                else if (option == 2)
                {
                    this.StartInfo.FileName = "CCSuite.exe";
                    this.Start();
                    LogWriter.LogWrite("Instaluję CCSuite...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano");
                }
                else
                {
                    MessageBox.Show("Nie wybrano żadnego klienta EKD..Aplikacja przejdzie dalej.", "Uwaga");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }

        }
        public void OfficeInstaller(int option)
        {
            try
            {
                if (option == 0)
                {
                    this.StartInfo.FileName = "OpenOffice.exe";
                    this.Start();
                    LogWriter.LogWrite("Instaluję OpenOffice 4.1.6...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano.");
                }
                else if (option == 1)
                {
                    this.StartInfo.FileName = @"office2007\setup.exe";
                    this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2007\config.msp");
                    this.Start();
                    LogWriter.LogWrite("Instaluję Office 2007 Enterprise...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano");
                }
                else if (option == 2)
                {
                    this.StartInfo.FileName = @"office2016\setup.exe";
                    this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2016\config.msp");
                    this.Start();
                    LogWriter.LogWrite("Instaluję Office 2016 MOLP...");
                    this.WaitForExit();
                    LogWriter.LogWrite("Zainstalowano");
                }
                else
                {
                    MessageBox.Show("Nie wybrano żadnego oprogramowania biurowego..Aplikacja przejdzie dalej.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                LogWriter.LogWrite(e.ToString());
            }
        }
    }
}