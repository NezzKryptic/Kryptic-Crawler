using System;
using System.Linq;
using System.Xml;

namespace Kryptic_Crawler.Util
{
    class ParseSettings
    {
        public static void ParseXMLSettings(string[] args)
        {
            XmlDocument settingsFile = new XmlDocument();
            settingsFile.Load(args[0]);

            XmlNode settings = settingsFile.DocumentElement.SelectSingleNode("/settings");

            if (settings.SelectSingleNode("url") != null && settings.SelectSingleNode("url").InnerText != null)
            {
                ArgumentManager.URL = settings.SelectSingleNode("url").InnerText;
            }

            if (settings.SelectSingleNode("output") != null && settings.SelectSingleNode("output").InnerText != null)
            {
                ArgumentManager.OUTPUT_PATH = (settings.SelectSingleNode("output").InnerText).Replace("\\", "\\\\");
            }

            if (settings.SelectSingleNode("fileindex") != null && settings.SelectSingleNode("fileindex").InnerText != null)
            {
                ArgumentManager.FILE_INDEX = int.Parse(settings.SelectSingleNode("fileindex").InnerText);
            }

            if (settings.SelectSingleNode("filename") != null && settings.SelectSingleNode("filename").InnerText != null)
            {
                ArgumentManager.FILE_NAME = settings.SelectSingleNode("filename").InnerText;
            }

            if (settings.SelectSingleNode("blacklist") != null && settings.SelectSingleNode("blacklist").InnerText != null)
            {
                ArgumentManager.BLACKLIST_PATH = (settings.SelectSingleNode("blacklist").InnerText).Replace("\\", "\\\\");
            }

            if (settings.SelectSingleNode("verbose") != null && settings.SelectSingleNode("verbose").InnerText != null)
            {
                ArgumentManager.VERBOSE_CONSOLE = Convert.ToBoolean(settings.SelectSingleNode("verbose").InnerText);
            }

            if (settings.SelectSingleNode("startpage") != null && settings.SelectSingleNode("startpage").InnerText != null)
            {
                ArgumentManager.START_PAGE = int.Parse(settings.SelectSingleNode("startpage").InnerText);
            }

            if (settings.SelectSingleNode("endpage") != null && settings.SelectSingleNode("endpage").InnerText != null)
            {
                ArgumentManager.END_PAGE = int.Parse(settings.SelectSingleNode("endpage").InnerText);
            }

            if (settings.SelectSingleNode("logfile") != null && settings.SelectSingleNode("logfile").InnerText != null)
            {
                ArgumentManager.LOGFILE_PATH = (settings.SelectSingleNode("logfile").InnerText).Replace("\\", "\\\\");
            }

            if (settings.SelectSingleNode("tags") != null && settings.SelectSingleNode("tags").InnerText != null)
            {
                ArgumentManager.HTML_TAGS = (settings.SelectSingleNode("tags").InnerText).Split(',').ToList();
            }

            if (settings.SelectSingleNode("attributes") != null && settings.SelectSingleNode("attributes").InnerText != null)
            {
                ArgumentManager.HTML_ATTRIBUTES = (settings.SelectSingleNode("attributes").InnerText).Split(',').ToList();
            }

            if (settings.SelectSingleNode("fileformats") != null && settings.SelectSingleNode("fileformats").InnerText != null)
            {
                ArgumentManager.FILE_FORMATS = (settings.SelectSingleNode("fileformats").InnerText).Split(',').ToList();
            }

            if (settings.SelectSingleNode("useragent") != null && settings.SelectSingleNode("useragent").InnerText != null)
            {
                ArgumentManager.USER_AGENT = settings.SelectSingleNode("useragent").InnerText;
            }

            string desiredMode = settings.SelectSingleNode("programmode").InnerText;

            ProgramMode.LoadMode(desiredMode);
        }
    }
}
