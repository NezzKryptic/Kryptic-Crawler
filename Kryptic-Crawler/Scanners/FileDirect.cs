using Kryptic_Crawler.Downloaders;
using Kryptic_Crawler.Util;
using System;
using System.IO;

namespace Kryptic_Crawler.Scanners
{
    class FileDirect
    {
        public static void FileDirectConnect()
        {
            string[] url_list = File.ReadAllLines(ArgumentManager.URL);
            int file_index = 0;

            foreach(string url in url_list)
            {
                try
                {
                    GeneralDownloader.DownloadFile(url, file_index.ToString());
                    file_index++;

                    ConsoleManager.WriteToConsole("Source: " + url + " | File Index: " + file_index);
                }
                catch(Exception e)
                {
                    if (ArgumentManager.VERBOSE_CONSOLE)
                    {
                        ConsoleManager.WriteToConsole(e.ToString());
                    }
                    else
                    {
                        Console.WriteLine("URL Failed: " + url);
                    }
                }
            }
        }
    }
}
