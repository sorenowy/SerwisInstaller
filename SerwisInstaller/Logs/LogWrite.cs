using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Logs
{
    public class LogWrite
    {
        private StreamWriter _log;
        public LogWrite()
        {
            _log = File.AppendText(LocalParameters.loggingPath);
            _log.Write("\r\nLog Entry : ");
            _log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            _log.WriteLine("");
        }
        public void Logging(string logMessage)
        {
            try
            {
                _log.WriteLine("  :{0}", logMessage);
                _log.WriteLine("-------------------------------");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                _log.WriteLine(e.Message);
                _log.Close();
            }
        }
        public void CloseLog()
        {
            try
            {
                _log.WriteLine("Log zakończony");
                _log.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
