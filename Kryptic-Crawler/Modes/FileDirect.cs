using Kryptic_Crawler.Downloaders;
using Kryptic_Crawler.Util;
using System;
using System.Diagnostics;
using System.IO;

namespace Kryptic_Crawler.Modes
{
    class FileDirect
    {
        public static void FileDirectConnect()
        {
            string[] url_list = File.ReadAllLines(ArgumentManager.DOWNLOAD_URL);
            int file_index = 0;

            foreach (string url in url_list)
            {
                try
                {
                    GeneralDownloader.DownloadFile(url, file_index.ToString());
                    file_index++;

                    Console.WriteLine("Source: " + url + " | File Index: " + file_index);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
