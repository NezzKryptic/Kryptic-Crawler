using HtmlAgilityPack;
using Kryptic_Crawler.Downloaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace Kryptic_Crawler.Util
{
    class WebHandler
    {
        internal static void PullContentLinks(string page, int page_index, int thread_index)
        {
            HtmlDocument document = new HtmlDocument();
            List<string> blacklist = (ArgumentManager.BLACKLIST_PATH != null) ? File.ReadAllLines(ArgumentManager.BLACKLIST_PATH).ToList() : null;
            int file_index = 0;

            try
            {
                using (WebClient client = new WebClient())
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
                                        if (ArgumentManager.BLACKLIST_PATH != null)
                                        {
                                            if (!blacklist.Any(src.Contains))
                                            {
                                                if (ArgumentManager.LOG_PATH != null)
                                                {
                                                    LogManager.WriteToLog("File Index: " + page_index + "_" + file_index + " | Source: " + src, thread_index);
                                                }

                                                GeneralDownloader.DownloadFile(src, page_index + "_" + file_index.ToString());
                                                file_index++;
                                            }
                                        }
                                        else
                                        {
                                            if (ArgumentManager.LOG_PATH != null)
                                            {
                                                LogManager.WriteToLog("File Index: " + page_index + "_" + file_index + " | Source: " + src, thread_index);
                                            }

                                            GeneralDownloader.DownloadFile(src, page_index + "_" + file_index.ToString());
                                            file_index++;
                                        }

                                        Console.SetCursorPosition(0, thread_index * 4);
                                        Console.WriteLine(new string(' ', Console.WindowWidth * 4));
                                        Console.SetCursorPosition(0, thread_index * 4);
                                        Console.WriteLine("Thread Index: " + thread_index + " | Page Index: " + page_index + "_" + file_index + " | Source: " + src + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
