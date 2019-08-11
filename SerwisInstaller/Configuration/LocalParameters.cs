using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisInstaller.Configuration
{
    internal class LocalParameters
    {

        internal static bool netconnection = false;

        internal static string netBIOSname = string.Empty;
        internal static string policyFinalDataPath = @"C:\Data\polityka";
        internal static string policyCertPath = Environment.CurrentDirectory + @"\Data\polityka";
        internal static string onlinePolicyCertPath = @"\\192.168.2.197\hubert\SerwisInstaller\Data\polityka";
        internal static string username = string.Empty;
        internal static string password = string.Empty;
        internal static string onlineLoginName = "Hubert";
        internal static string onlinePassword = "11-Hubert-1111!";
        internal static string installationDataPath = Environment.CurrentDirectory + @"\Data\";
        internal static string onlineInstallationDataPath = @"\\192.168.2.197\hubert\SerwisInstaller\Data\";
        internal static string driverPath = Environment.CurrentDirectory + @"\Data\64";
        internal static string onlineDriverPath = onlineInstallationDataPath + @"64\";
        internal static string driverFinalPath = @"C:\Data\64";
        internal static string ipLogPath = Environment.CurrentDirectory + @"\Logs\IPConfigLogs\";
        internal static string inventoryNumber = string.Empty;
        internal static string loggingPath = Environment.CurrentDirectory +@"\Logs\ProgramLogs\";
        internal static string addressMail = "hubert.kuszynski@go.policja.gov.pl";
        internal static string helpSubject = "Problem z KWP Serwis Installer v1.0";
    }
}
