using HtmlAgilityPack;
using Kryptic_Crawler.Downloaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kryptic_Crawler.Crawlers
{
    class MultiFileCrawler
    {
        // Instance Declaration
        GeneralDownloader downloader = new GeneralDownloader();

        // WebClient Accepted Download Formats
        string mimeTypes = ArgumentManager.getSetting(12);

        // Parse single HTML page for content links
        public void retrieveFileUrls()
        {
            // Set file index to specified integer
            int fileIndex = int.Parse(ArgumentManager.getSetting(2));

            // Declare blacklist variable
            string[] blacklist = null;

            // HTML tags to search through
            string[] htmlTags = ArgumentManager.getSetting(9).Split(',');
            string[] htmlAttributes = ArgumentManager.getSetting(10).Split(',');

            // Populate blacklist array
            if (ArgumentManager.getSetting(4) != "")
            {
                blacklist = File.ReadAllLines(ArgumentManager.getSetting(4));
            }

            // Attempt to connect to webpage
            for (int pageIndex = int.Parse(ArgumentManager.getSetting(6)); pageIndex < int.Parse(ArgumentManager.getSetting(7)); pageIndex++)
            {
                try
                {
                    // Preparation for connection & specifying URL
                    WebClient client = new WebClient();
                    client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    if (mimeTypes != null)
                    {
                        client.Headers.Add(HttpRequestHeader.Accept, mimeTypes);
                    }

                    // Get URL and replace |#| with page index
                    string html = client.DownloadString(ArgumentManager.getSetting(0).Replace("|#|", pageIndex.ToString()));

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
                                Console.WriteLine("Page Index: " + pageIndex + " | File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);

                                // Save file without blacklist
                                if (ArgumentManager.getSetting(4) == "")
                                {
                                    if (src != null)
                                    {
                                        File.AppendAllText(ArgumentManager.getSetting(8), "Page Index: " + pageIndex + " | File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);
                                        downloader.downloadFile(src, fileIndex);
                                        fileIndex += 1;
                                    }
                                }
                                // Save file with blacklist
                                else
                                {
                                    if (src != null)
                                    {
                                        if (!blacklist.Any(src.Contains))
                                        {
                                            File.AppendAllText(ArgumentManager.getSetting(8), "Page Index: " + pageIndex + " | File Index: " + fileIndex + " | Source: " + src + Environment.NewLine);
                                            downloader.downloadFile(src, fileIndex);
                                            fileIndex += 1;
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
                        Console.WriteLine("Failed to get create connection" + Environment.NewLine);
                    }
                }
            }
        }
    }
}
