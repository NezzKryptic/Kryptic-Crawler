using System;
using System.IO;

namespace Kryptic_Crawler.Util
{
    class LogManager
    {
        public static void WriteToLog(string text_to_write, int thread_index)
        {
            if(ArgumentManager.LOG_MODE == "single")
            {
                if(!Directory.Exists(ArgumentManager.LOG_PATH))
                {
                    Directory.CreateDirectory(ArgumentManager.LOG_PATH);
                    WriteToLog(text_to_write, thread_index);
                }
                else
                {
                    File.AppendAllText(ArgumentManager.LOG_PATH + "\\" + ArgumentManager.LOG_NAME, text_to_write + Environment.NewLine);
                }
            }
            else if(ArgumentManager.LOG_MODE == "multi")
            {
                if (!Directory.Exists(ArgumentManager.LOG_PATH))
                {
                    Console.WriteLine("Log Directory Created");
                    Directory.CreateDirectory(ArgumentManager.LOG_PATH);
                    WriteToLog(text_to_write, thread_index);
                }
                else
                {
                    if (File.Exists(ArgumentManager.LOG_PATH + "\\" + ArgumentManager.LOG_NAME.Replace("|#|", thread_index + "_" + ArgumentManager.LOG_INDEX[thread_index].ToString())))
                    {
                        long file_size = new FileInfo(ArgumentManager.LOG_PATH + "\\" + ArgumentManager.LOG_NAME.Replace("|#|", thread_index + "_" + ArgumentManager.LOG_INDEX[thread_index].ToString())).Length;

                        if (file_size >= ArgumentManager.LOG_SIZE)
                        {
                            ArgumentManager.LOG_INDEX[thread_index]++;
                            WriteToLog(text_to_write, thread_index);
                        }
                        else
                        {
                            File.AppendAllText(ArgumentManager.LOG_PATH + "\\" + ArgumentManager.LOG_NAME.Replace("|#|", thread_index + "_" + ArgumentManager.LOG_INDEX[thread_index].ToString()), text_to_write + Environment.NewLine);
                        }
                    }
                    else
                    {
                        Console.WriteLine("New Log File Started");
                        File.AppendAllText(ArgumentManager.LOG_PATH + "\\" + ArgumentManager.LOG_NAME.Replace("|#|", thread_index + "_" + ArgumentManager.LOG_INDEX[thread_index].ToString()), text_to_write + Environment.NewLine);
                    }
                }
            }
        }
    }
}
