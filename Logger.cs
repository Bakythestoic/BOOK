using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Week_7
{
    internal class Logger
    {
        private static Logger instance;
        private Logger() { }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            Console.WriteLine(logEntry);
            File.AppendAllText("log.txt", logEntry + Environment.NewLine);
        }
    }
}
