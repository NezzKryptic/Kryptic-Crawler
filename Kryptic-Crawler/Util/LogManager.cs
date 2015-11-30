using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptic_Crawler.Util
{
    class LogManager
    {
        public static void WriteToLog(string text)
        {
            if (!File.Exists(ArgumentManager.LOGFILE_PATH))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ArgumentManager.LOGFILE_PATH));
                }
                catch (Exception e)
                {
                    ConsoleManager.WriteToConsole(e.ToString());
                }

                File.AppendAllText(ArgumentManager.LOGFILE_PATH, text + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(ArgumentManager.LOGFILE_PATH, text + Environment.NewLine);
            }
        }
    }
}
