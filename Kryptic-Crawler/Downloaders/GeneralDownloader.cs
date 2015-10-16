using System;
using System.IO;
using System.Net;

namespace Kryptic_Crawler.Downloaders
{
    class GeneralDownloader
    {
        // WebClient Accepted Download Formats
        string mimeTypes = ArgumentManager.getSetting(12);

        // Download file
        public void downloadFile(string fileURL, int fileIndex)
        {
            // Check for output directory
            if (!Directory.Exists(ArgumentManager.getSetting(1)))
            {
                Directory.CreateDirectory(ArgumentManager.getSetting(1));
            }

            // Check file extension and download
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
            if (mimeTypes != null)
            {
                client.Headers.Add(HttpRequestHeader.Accept, mimeTypes);
            }

            string fileType = fileURL.Substring(fileURL.Length - 5);
            string[] fileFormats = ArgumentManager.getSetting(11).Split(',');

            // Attempt to determine file type and download
            try
            {
                for (int typeIndex = 0; typeIndex != fileFormats.Length; typeIndex++)
                {
                    if (fileType.Contains("." + fileFormats[typeIndex]))
                    {
                        client.DownloadFile(fileURL, ArgumentManager.getSetting(1) + "\\" + ArgumentManager.getSetting(3) + "(" + fileIndex + ")." + fileFormats[typeIndex]);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                if (ArgumentManager.getSetting(5) == "false")
                {
                    Console.WriteLine("Failed to save file: " + fileURL + Environment.NewLine);
                }
                else if (ArgumentManager.getSetting(5) == "true")
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
