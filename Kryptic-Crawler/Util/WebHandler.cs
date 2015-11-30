using HtmlAgilityPack;
using Kryptic_Crawler.Downloaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Kryptic_Crawler.Util
{
    class WebHandler
    {
        public static void PullContentLinks(string page, int pageIndex)
        {
            WebClient client = new WebClient();
            HtmlDocument document = new HtmlDocument();

            List<string> blacklist = null;

            if (ArgumentManager.BLACKLIST_PATH != null)
            {
                blacklist = File.ReadAllLines(ArgumentManager.BLACKLIST_PATH).ToList();
            }

            try
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, ArgumentManager.USER_AGENT);

                string html = client.DownloadString(page);

                document.LoadHtml(html);

                foreach (string tag in ArgumentManager.HTML_TAGS)
                {
                    if (document.DocumentNode.SelectNodes(tag) != null)
                    {
                        foreach (HtmlNode current_node in document.DocumentNode.SelectNodes(tag))
                        {
                            foreach (string attribute in ArgumentManager.HTML_ATTRIBUTES)
                            {
                                string src = current_node.GetAttributeValue(attribute, null);

                                if (src != null)
                                {
                                    ConsoleManager.WriteToConsole("Page Index: " + pageIndex + " | File Index: " + ArgumentManager.FILE_INDEX + " | Source: " + src);

                                    if (ArgumentManager.BLACKLIST_PATH != null)
                                    {
                                        if (!blacklist.Any(src.Contains))
                                        {
                                            if (ArgumentManager.LOGFILE_PATH != null)
                                            {
                                                LogManager.WriteToLog("Page Index: " + pageIndex + " | File Index: " + ArgumentManager.FILE_INDEX + " | Source: " + src);
                                            }

                                            GeneralDownloader.DownloadFile(src, ArgumentManager.FILE_INDEX);
                                            ArgumentManager.FILE_INDEX++;
                                        }
                                    }
                                    else
                                    {
                                        if (ArgumentManager.LOGFILE_PATH != null)
                                        {
                                            LogManager.WriteToLog("Page Index: " + pageIndex + " | File Index: " + ArgumentManager.FILE_INDEX + " | Source: " + src);
                                        }

                                        GeneralDownloader.DownloadFile(src, ArgumentManager.FILE_INDEX);
                                        ArgumentManager.FILE_INDEX++;
                                    }
                                }
                            }
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
