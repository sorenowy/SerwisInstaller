using System;
using System.IO;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Logs
{
    public class LogWriter
    {
        public static void LogWrite(string logMessage)
        {

            if (!Directory.Exists(LocalParameters.loggingPath))
            {
                Directory.CreateDirectory(LocalParameters.loggingPath); // jezeli nie ma sciezki to tworzy ją
            }

            if (!File.Exists(LocalParameters.loggingPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt"))
            { 
                File.Create(LocalParameters.loggingPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt").Close();
            }

            try
            {
                using (var writer = File.AppendText(LocalParameters.loggingPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt"))
                {
                    AppendLog(logMessage, writer); // wypisuje do loga od nowej linijki :)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\n");
                txtWriter.WriteLine("{0} {1} : {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), logMessage);
                txtWriter.Close();
            }
            catch (Exception ex)
            {
                LogWrite(ex.ToString());
            }
        }
    }
}

