using HtmlAgilityPack;
using Kryptic_Crawler.Downloaders;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Kryptic_Crawler.Crawlers
{
    class SingleFileCrawler
    {
        // Parse single HTML page for content links
        public static void retrieveFileUrls()
        {
            // Set file index to specified integer
            int fileIndex = int.Parse(ArgumentManager.getSetting(2));

            // Declare blacklist variable
            string[] blacklist = null;

            // WebClient Accepted Download Formats
            string mimeTypes = ArgumentManager.getSetting(12);

            // HTML tags to search through
            string[] htmlTags = ArgumentManager.getSetting(9).Split(',');
            string[] htmlAttributes = ArgumentManager.getSetting(10).Split(',');

            // Populate blacklist array
            if (ArgumentManager.getSetting(4) != "")
            {
                blacklist = File.ReadAllLines(ArgumentManager.getSetting(4));
            }

            // Attempt to connect to webpage
            try
            {
                // Preparation for connection & specifying URL
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                if (mimeTypes != null)
                {
                    client.Headers.Add(HttpRequestHeader.Accept, mimeTypes);
                }

                string html = client.DownloadString(ArgumentManager.getSetting(0));

                // Load HTML code from webpage
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                // Loop through tags
                foreach (string tag in htmlTags)
                {
                    // Search for selected tag
                    foreach (var file in document.DocumentNode.SelectNodes(tag))
                    {
                        // Loop through attributes
                        foreach (string attribute in htmlAttributes)
                        {
                            // The source URL from the attribute
                            var src = file.GetAttributeValue(attribute, null);

                            // Write info to console
                            Console.WriteLine("File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);

                            // Save file without blacklist
                            if (ArgumentManager.getSetting(4) == "")
                            {
                                if (src != null)
                                {
                                    File.AppendAllText(ArgumentManager.getSetting(8), "File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);
                                    GeneralDownloader.downloadFile(src, fileIndex);
                                    fileIndex += 1;
                                }
                            }
                            // Save file with blacklist
                            else
                            {
                                try
                                {
                                    if (!blacklist.Any(src.Contains))
                                    {
                                        File.AppendAllText(ArgumentManager.getSetting(8), "File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);
                                        GeneralDownloader.downloadFile(src, fileIndex);
                                        fileIndex += 1;
                                    }
                                }
                                catch (Exception e)
                                {
                                    if (ArgumentManager.getSetting(5) == "true")
                                    {
                                        Console.WriteLine(e + Environment.NewLine);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to prepare file for download");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (ArgumentManager.getSetting(5) == "true")
                {
                    Console.WriteLine(e + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("Failed to create connection");
                }
            }
        }
    }
}
