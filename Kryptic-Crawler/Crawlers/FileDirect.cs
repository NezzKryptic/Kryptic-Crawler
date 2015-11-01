using Kryptic_Crawler.Downloaders;
using System;
using System.IO;

namespace Kryptic_Crawler.Crawlers
{
    class FileDirect
    {
        public static void parseFileList()
        {
            // Path to url list
            string[] urlList = File.ReadAllLines(ArgumentManager.getSetting(0));

            // Set file index to specified integer
            int fileIndex = int.Parse(ArgumentManager.getSetting(2));

            foreach (string url in urlList)
            {
                try
                {
                    GeneralDownloader.downloadFile(url, fileIndex);
                    fileIndex += 1;

                    Console.WriteLine("Image Src: " + url + " | Index: " + fileIndex + "\n");
                }
                catch(Exception e)
                {
                    if(ArgumentManager.getSetting(5) == "false")
                    {
                        Console.WriteLine(e);
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
