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
            this.StartInfo.UseShellExecute = true;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.WorkingDirectory = @"C:\Data\";
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
            LogWrite log = new LogWrite();
            Console.Clear();
            this.StartInfo.FileName = "PCDecrapifier.exe";
            this.Start();
            Console.WriteLine("Użyj programu PC Decrapifier aby usunąć niepotrzebne oprogramowanie z komputera.\nŚmieci i inne rzeczy.");
            log.Logging("Zainstalowano shit remover");
            log.CloseLog();
            this.WaitForExit();
        }
        public void LotusInstaller(int option)
        {
            try
            {
                if (option == 0)
                {
                    this.StartInfo.FileName = "LotusNotesBasic853.exe";
                    this.Start();
                    Console.WriteLine("Trwa instalacja Klienta Lotus Notes 8.5.3 Basic...");
                    this.WaitForExit();
                    Console.WriteLine("Zainstalowano klienta Lotus Notes 8.5.3 Basic.");
                }
                else if (option == 1)
                {
                    this.StartInfo.FileName = "LotusNotesStd853.exe";
                    this.Start();
                    Console.WriteLine("Trwa instalacja Klienta Lotus Notes 8.5.3 Standard...");
                    this.WaitForExit();
                    Console.WriteLine("Zainstalowano klienta Lotus Notes 8.5.3 Standard.");
                }
                else if (option == 2)
                {
                    this.StartInfo.FileName = "thunderbird.exe";
                    this.Start();
                    Console.WriteLine("Trwa instalacja Klienta Mozilla Thunderbird...");
                    this.WaitForExit();
                    Console.WriteLine("Zainstalowano klienta Mozilla Thunderbird.");
                }
                else
                {
                    Console.WriteLine("Nie wybrano żadnego lotusa.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void BaseInstaller()
        {
            try
            {
                this.StartInfo.FileName = "Firefox.exe";
                this.Start();
                Console.WriteLine("Instaluję Firefox 66.0...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano Firefox 66.0.");
                this.StartInfo.FileName = "7z1900.exe";
                this.Start();
                Console.WriteLine("Instaluję 7-zip...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano 7-zip.");
                this.StartInfo.FileName = "Adobe11.exe";
                this.StartInfo.Arguments = string.Format($"/qn /i ALLUSERS=1 {this.StartInfo.WorkingDirectory}");
                this.Start();
                Console.WriteLine("Instaluję Adobe Reader XI...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano Adobe Reader XI.");
                this.StartInfo.FileName = "KLite1504.exe";
                this.Start();
                Console.WriteLine("Trwa instalacja K-Lite Codec 15.04 Standard...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano K-Lite Codec 15.04 Standard.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void InternetInstaller()
        {
            try
            {
                this.BaseInstaller();
                this.StartInfo.FileName = "EsetKWP64.exe";
                this.Start();
                Console.WriteLine("Trwa instalowanie Oprogramowania ESET AV version 8 64bit...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano Oprogramowanie antywirusowe ESET.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void CWIInstaller()
        {
            try
            {
                this.InternetInstaller();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void PSTDInstaller()
        {
            try
            {
                this.BaseInstaller();
                this.StartInfo.FileName = "java765.exe";
                this.Start();
                Console.WriteLine("Trwa instalacja Java Runtime Enviroment 7u65 dla UKSP...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano JRE 7u65.");
                this.StartInfo.FileName = @"KlientSWOP_CD\setup.exe";
                this.Start();
                Console.WriteLine("Trwa instalacja SWOP, bądź czujny i klikaj odpowiednio, to długa instalacja...");
                this.WaitForExit();
                Console.WriteLine("Instalacja SWOP ukończona.");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
                    Console.WriteLine("Instaluję Encard 2.1.0...");
                    this.WaitForExit();
                }
                else if (option == 1)
                {
                    this.StartInfo.FileName = "msiexec.exe";
                    this.StartInfo.Arguments = string.Format("/i {0}", $@"{this.StartInfo.WorkingDirectory}encard64bit\encard.msi");
                    this.Start();
                    Console.WriteLine("Instaluję Encard 4.1.5...");
                    this.WaitForExit();
                }
                else if (option == 2)
                {
                    this.StartInfo.FileName = "CCSuite.exe";
                    this.Start();
                    Console.WriteLine("Instaluję CCSuite...");
                    this.WaitForExit();
                }
                else
                {
                    Console.WriteLine("Nie wybrano żadnego klienta EKD..Aplikacja przejdzie dalej.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
            public void OfficeInstaller(int option)
            {
                Console.WriteLine("--------------------------------------------------");
                try
                {
                    if (option == 0)
                    {
                        this.StartInfo.FileName = "OpenOffice.exe";
                        this.Start();
                        Console.WriteLine("Instaluję OpenOffice 4.1.6...");
                        this.WaitForExit();
                    }
                    else if (option == 1)
                    {
                        this.StartInfo.FileName = @"office2007\setup.exe";
                        this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2007\config.msp");
                        this.Start();
                        Console.WriteLine("Instaluję Office 2007 Enterprise...");
                        this.WaitForExit();
                    }
                    else if (option == 2)
                    {
                        this.StartInfo.FileName = @"office2016\setup.exe";
                        this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2016\config.msp");
                        this.Start();
                        Console.WriteLine("Instaluję Office 2016 MOLP...");
                        this.WaitForExit();
                    }
                    else
                    {
                        Console.WriteLine("Nie wybrano żadnego oprogramowania biurowego..Aplikacja przejdzie dalej.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Wystąpił błąd instalacji oprogramowania biurowego");
                }
            }
        }
    }