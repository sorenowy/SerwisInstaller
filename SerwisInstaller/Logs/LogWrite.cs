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
        private StreamWriter _log = null;
        public LogWrite()
        {
            _log = new StreamWriter(LocalParameters.loggingPath, true);
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
            }
        }
        public void CloseLog(string logMessage)
        {
            try
            {
                _log.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
