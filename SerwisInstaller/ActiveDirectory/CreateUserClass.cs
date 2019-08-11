using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SerwisInstaller.Logs;
using SerwisInstaller.Configuration;
using SerwisInstaller.Main;
using System.DirectoryServices;

namespace SerwisInstaller.ActiveDirectory
{
    public class CreateUserClass : Installer
    {
        public int option; // Pobrane w metodzie zawartej w konstruktorze WPF
        public CreateUserClass()
        {
            this.StartInfo.Verb = "runas";
        }
        public void ShowUser()
        {
            LogWriter.LogWrite("Tworzenie konta użytkownika");
            CreateUser(LocalParameters.username, LocalParameters.password); // Przekazuje dane do metody
        }
        public void CreateUser(string name, string pass)
        {
            try
            {
                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName); // Tworzy nowy zapis active directory o sciezce maszyny
                DirectoryEntry newUser = AD.Children.Add(name, "user"); // Dodaje potomka do active directory o nazwie name => name zwrocony z metody w WPF
                newUser.Invoke("SetPassword", new object[] { pass }); // wywołuje hasło i dodaje je do kontenera jako "(String = pass) => password zwrocony przez metode w WPF"
                newUser.CommitChanges(); // Wykonuje zmianę
                LogWriter.LogWrite($"Nazwa utworzonego konta:{newUser.Name.ToString()}");
                DirectoryEntry group; // tworzy kolejną scieżkę zmienną AD
                if (option == 1)
                {
                    group = AD.Children.Find(@"\Użytkownicy", "group"); // sprawdza czy istnieje taka grupa w Systemie, jeżeli tak, to dodaje do grupy Uzytkownicy.
                    if (group != null)
                    {
                        group.Invoke("Add", new object[] { newUser.Path.ToString() });
                    }
                }
                else if (option == 2)
                {
                    group = AD.Children.Find(@"\Administratorzy", "group");
                    if (group != null)
                    {
                        group.Invoke("Add", new object[] { newUser.Path.ToString() });
                    }
                }
                AD.Close();
                newUser.Close(); // Zamyka strumień
                LogWriter.LogWrite("Konto utworzone prawidłowo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
                LogWriter.LogWrite(ex.ToString());
            }
        }
    }
}
