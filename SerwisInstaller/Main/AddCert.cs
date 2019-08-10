using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using SerwisInstaller.Configuration;
using SerwisInstaller.Logs;

namespace SerwisInstaller.Main
{
    public class AddCert : Installer
    {
        private string _certCWIPath;
        private string _certPSTDPath;
        public AddCert()
        {
            this._certCWIPath = LocalParameters.installationDataPath;
            this._certPSTDPath = LocalParameters.installationDataPath;
        }
        public void InstallCWICert(string filename)
        {
            try
            {
                X509Certificate2 certificateCWI = new X509Certificate2(_certCWIPath + filename); // tworzy lokalną zmienną dopisaną do obiektu X509Cert2
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine); // tworzy zmienną obiektu X509Store czyli wskazuje na konkretny magazyn w konkretnym miejscu (zaufane gl. urz. certyfikacji)

                store.Open(OpenFlags.ReadWrite); //Otwiera magazyn i zezwala na zapis/odczyt
                store.Add(certificateCWI); // dodaje ceryfikat
                store.Close();
                LogWriter.LogWrite("Certyfikat CWI_CERT dograny pomyślnie!");

            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dogrywania certyfikatu CWI_CERT");
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void InstallInfrastrukturaCert(string filename)
        {
            try
            {
                X509Certificate2 certificatePSTD = new X509Certificate2(_certPSTDPath + filename);
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadWrite);
                store.Add(certificatePSTD);
                store.Close();
                LogWriter.LogWrite("Certyfikat infrastruktura dodano pomyślnie!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Bład dogrania cert. Infrastruktura2019!");
                LogWriter.LogWrite(e.ToString());
            }
        }
    }
}
