using Kryptic_Crawler.Util;
using System;
using System.IO;
using System.Net;

namespace Kryptic_Crawler.Downloaders
{
    class GeneralDownloader
    {
        public static void DownloadFile(string fileURL, string fileIndex)
        {
            WebClient client = new WebClient();

            string fileType = fileURL.Substring(fileURL.Length - 10);

            if (!Directory.Exists(ArgumentManager.DOWNLOAD_PATH))
            {
                Directory.CreateDirectory(ArgumentManager.DOWNLOAD_PATH);
            }

            client.Headers.Add(HttpRequestHeader.UserAgent, ArgumentManager.USER_AGENT);

            try
            {
                foreach (string file_format in ArgumentManager.FILE_FORMATS)
                {
                    if (fileType.Contains("." + file_format))
                    {
                        if (fileURL.Substring(0, 2) == "//")
                        {
                            client.DownloadFile("http:" + fileURL, ArgumentManager.DOWNLOAD_PATH + "\\" + ArgumentManager.FILE_NAME.Replace("|#|", fileIndex.ToString()) + "." + file_format);
                        }
                        else
                        {
                            client.DownloadFile(fileURL, ArgumentManager.DOWNLOAD_PATH + "\\" + ArgumentManager.FILE_NAME.Replace("|#|", fileIndex.ToString()) + "." + file_format);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ConsoleManager.WriteToConsole(e.ToString());
            }
        }
    }
}
