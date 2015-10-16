using System;
using System.Xml;
using Kryptic_Crawler.Crawlers;

namespace Kryptic_Crawler
{
    class ParseSettings
    {
        // Instance Declaration
        ErrorMessages errorMessages = new ErrorMessages();
        SingleFileCrawler singleFileCrawler = new SingleFileCrawler();
        MultiFileCrawler multiFileCrawler = new MultiFileCrawler();

        // Parse provided XML for desired settings
        public void parseSettings(string[] args)
        {
            // Loading Settings file
            XmlDocument settingsFile = new XmlDocument();
            settingsFile.Load(args[0]);

            XmlNode settings = settingsFile.DocumentElement.SelectSingleNode("/settings");

            // Preparing program settings
            if (settings.SelectSingleNode("url").InnerText != null)
            {
                ArgumentManager.setSetting(0, settings.SelectSingleNode("url").InnerText);
            }

            if (settings.SelectSingleNode("output").InnerText != null)
            {
                ArgumentManager.setSetting(1, settings.SelectSingleNode("output").InnerText);
            }

            if (settings.SelectSingleNode("fileindex").InnerText != null)
            {
                ArgumentManager.setSetting(2, settings.SelectSingleNode("fileindex").InnerText);
            }

            if (settings.SelectSingleNode("filename").InnerText != null)
            {
                ArgumentManager.setSetting(3, settings.SelectSingleNode("filename").InnerText);
            }

            if (settings.SelectSingleNode("blacklist").InnerText != null)
            {
                ArgumentManager.setSetting(4, settings.SelectSingleNode("blacklist").InnerText);
            }

            if (settings.SelectSingleNode("verbose").InnerText != null)
            {
                ArgumentManager.setSetting(5, settings.SelectSingleNode("verbose").InnerText);
            }

            if (settings.SelectSingleNode("startpage").InnerText != null)
            {
                ArgumentManager.setSetting(6, settings.SelectSingleNode("startpage").InnerText);
            }

            if (settings.SelectSingleNode("endpage").InnerText != null)
            {
                ArgumentManager.setSetting(7, settings.SelectSingleNode("endpage").InnerText);
            }

            if (settings.SelectSingleNode("logfile").InnerText != null)
            {
                ArgumentManager.setSetting(8, settings.SelectSingleNode("logfile").InnerText);
            }

            if (settings.SelectSingleNode("tags").InnerText != null)
            {
                ArgumentManager.setSetting(9, settings.SelectSingleNode("tags").InnerText);
            }

            if (settings.SelectSingleNode("attributes").InnerText != null)
            {
                ArgumentManager.setSetting(10, settings.SelectSingleNode("attributes").InnerText);
            }

            if (settings.SelectSingleNode("fileformats").InnerText != null)
            {
                ArgumentManager.setSetting(11, settings.SelectSingleNode("fileformats").InnerText);
            }

            if (settings.SelectSingleNode("mimetypes").InnerText != null)
            {
                ArgumentManager.setSetting(12, settings.SelectSingleNode("mimetypes").InnerText);
            }

            // Determine program mode
            string programMode = settings.SelectSingleNode("programmode").InnerText;

            // Act based on chosen mode
            switch (programMode)
            {
                case "single":
                    singleFileCrawler.retrieveFileUrls();
                    break;

                case "multi":
                    multiFileCrawler.retrieveFileUrls();
                    break;

                case "file":
                    Console.WriteLine("Mode not supported yet");
                    break;

                case "imgur":
                    Console.WriteLine("Mode not supported yet");
                    break;

                case "subreddit":
                    Console.WriteLine("Mode not supported yet");
                    break;

                default:
                    errorMessages.invalidMode();
                    break;
            }
        }
    }
}
