using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SerwisInstaller.Main;
using SerwisInstaller.Configuration;
using SerwisInstaller.Logs;

namespace SerwisInstaller.ActiveDirectory
{
    public class NetBIOSChange : Installer
    {
        public NetBIOSChange()
        {
            this.StartInfo.Verb = "runas";
        }
        public void ChangeNetBIOS()
        {
            try
            { /* Ustawienia wlasciwosci są w tej metodzie z racji braku przekazywania jej w konstruktorze WPF, 
                ktory automatycznie przyjmuje i nie wykonuje funkcji UseShellExecute, 
                kluczowej do wykonania w przypadku wywołania powershella! 
                Stąd przekazany został do metody ChangeNetBIOS zamiast do konstruktora klasy.*/

                this.StartInfo.CreateNoWindow = true;
                this.StartInfo.UseShellExecute = false;
                this.StartInfo.RedirectStandardInput = true;
                this.StartInfo.RedirectStandardOutput = true;
                this.StartInfo.FileName = "cmd.exe";
                this.StartInfo.Arguments = "/c wmic computersystem where caption='" + Environment.MachineName + "' rename " + LocalParameters.netBIOSname;
                this.Start();
                this.WaitForExit();
                LogWriter.LogWrite("Zmiana nazwy NetBIOS wykonana pomyślnie!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void JoinDomain()
        {
            try
            {
                this.StartInfo.FileName = "powershell.exe";
                this.StartInfo.Arguments = "add-computer -domainname kwp-gorzow.intranet";
                this.Start();
                this.WaitForExit();
                LogWriter.LogWrite("Udało się podłączyć do domeny.");
            }
            catch (Exception e)
            {
                LogWriter.LogWrite(e.ToString());
            }
        }
    }
}
