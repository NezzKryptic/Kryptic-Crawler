using System;
using System.IO;

namespace Kryptic_Crawler.Util
{
    class LogManager
    {
        public static void WriteToLog(string text_to_write, int thread_index)
        {
            if(ArgumentManager.LOG_FILE_MODE == "single")
            {
                if(!Directory.Exists(ArgumentManager.LOG_FILE_PATH))
                {
                    Directory.CreateDirectory(ArgumentManager.LOG_FILE_PATH);
                    WriteToLog(text_to_write, thread_index);
                }
                else
                {
                    File.AppendAllText(ArgumentManager.LOG_FILE_PATH + "\\" + ArgumentManager.LOG_FILE_NAME, text_to_write + Environment.NewLine);
                }
            }
            else if(ArgumentManager.LOG_FILE_MODE == "multi")
            {
                if (!Directory.Exists(ArgumentManager.LOG_FILE_PATH))
                {
                    ConsoleManager.WriteToConsole("Log Directory Created");
                    Directory.CreateDirectory(ArgumentManager.LOG_FILE_PATH);
                    WriteToLog(text_to_write, thread_index);
                }
                else
                {
                    if (File.Exists(ArgumentManager.LOG_FILE_PATH + "\\" + ArgumentManager.LOG_FILE_NAME.Replace("|#|", ArgumentManager.LOG_FILE_INDEX[thread_index].ToString())))
                    {
                        long file_size = new FileInfo(ArgumentManager.LOG_FILE_PATH + "\\" + ArgumentManager.LOG_FILE_NAME.Replace("|#|", ArgumentManager.LOG_FILE_INDEX[thread_index].ToString())).Length;

                        if (file_size >= ArgumentManager.LOG_FILE_SIZE)
                        {
                            ArgumentManager.LOG_FILE_INDEX[thread_index] += ArgumentManager.DOWNLOAD_THREADS;
                            WriteToLog(text_to_write, thread_index);
                        }
                        else
                        {
                            File.AppendAllText(ArgumentManager.LOG_FILE_PATH + "\\" + ArgumentManager.LOG_FILE_NAME.Replace("|#|", ArgumentManager.LOG_FILE_INDEX[thread_index].ToString()), text_to_write + Environment.NewLine);
                        }
                    }
                    else
                    {
                        ConsoleManager.WriteToConsole("New Log File Started");
                        File.AppendAllText(ArgumentManager.LOG_FILE_PATH + "\\" + ArgumentManager.LOG_FILE_NAME.Replace("|#|", ArgumentManager.LOG_FILE_INDEX[thread_index].ToString()), text_to_write + Environment.NewLine);
                    }
                }
            }
        }
    }
}
