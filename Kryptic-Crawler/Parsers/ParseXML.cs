using Kryptic_Crawler.Modes;
using Kryptic_Crawler.Util;
using System;
using System.Xml;

namespace Kryptic_Crawler.Parsers
{
    class ParseXML
    {
        internal static void ParseXMLSettings(string[] args)
        {
            XmlDocument settings_file = new XmlDocument();
            settings_file.Load(args[1]);

            // ---------------------------------------------------- GENERAL SETTINGS ---------------------------------------------------- //

            XmlNode general_settings = settings_file.DocumentElement.SelectSingleNode("/settings/general_settings");

            XmlNode program_mode_node = general_settings.SelectSingleNode("program_mode");
            try
            {
                ArgumentManager.PROGRAM_MODE = program_mode_node.InnerText.ToLower();
            }
            catch
            {
                Console.WriteLine("You need to supply a <program_mode>");
                Console.ReadKey();
                Environment.Exit(0);
            }

            XmlNode download_threads_node = general_settings.SelectSingleNode("download_threads");
            try
            {
                ArgumentManager.DOWNLOAD_THREADS = int.Parse(download_threads_node.InnerText);
            }
            catch
            {

            }

            // ADD DIFFERENT VERBOSE LEVELS - STANDARD, ERROR, LOG, ETC
            XmlNode verbose_console_node = general_settings.SelectSingleNode("verbose_console");
            try
            {
                ArgumentManager.VERBOSE_CONSOLE = bool.Parse(verbose_console_node.InnerText);
            }
            catch
            {

            }

            // ---------------------------------------------------- CONNECTION SETTINGS ---------------------------------------------------- //

            XmlNode connection_settings = settings_file.DocumentElement.SelectSingleNode("/settings/connection_settings");

            XmlNode download_url_node = connection_settings.SelectSingleNode("download_url");
            try
            {
                ArgumentManager.DOWNLOAD_URL = download_url_node.InnerText.Replace("\\", "\\\\");
            }
            catch
            {
                Console.WriteLine("You need to supply a <download_url>");
                Console.ReadKey();
                Environment.Exit(0);
            }

            XmlNode start_page_node = connection_settings.SelectSingleNode("start_page");
            try
            {
                ArgumentManager.START_PAGE = int.Parse(start_page_node.InnerText);
            }
            catch
            {

            }

            XmlNode end_page_node = connection_settings.SelectSingleNode("end_page");
            try
            {
                ArgumentManager.END_PAGE = int.Parse(end_page_node.InnerText);
            }
            catch
            {

            }

            XmlNode html_tags_node = connection_settings.SelectSingleNode("html_tags");
            try
            {
                ArgumentManager.HTML_TAGS = html_tags_node.InnerText.Split(',');
            }
            catch
            {

            }

            XmlNode html_attributes_node = connection_settings.SelectSingleNode("hmtl_attributes");
            try
            {
                ArgumentManager.HTML_ATTRIBUTES = html_attributes_node.InnerText.Split(',');
            }
            catch
            {

            }

            XmlNode user_agent_node = connection_settings.SelectSingleNode("user_agent");
            try
            {
                ArgumentManager.USER_AGENT = user_agent_node.InnerText;
            }
            catch
            {

            }

            // ---------------------------------------------------- DOWNLOAD SETTINGS ---------------------------------------------------- //

            XmlNode download_settings = settings_file.DocumentElement.SelectSingleNode("/settings/download_settings");

            XmlNode download_path_node = download_settings.SelectSingleNode("download_path");
            try
            {
                ArgumentManager.DOWNLOAD_PATH = download_path_node.InnerText.Replace("\\", "\\\\");
            }
            catch
            {

            }

            XmlNode file_name_node = download_settings.SelectSingleNode("file_name");
            try
            {
                ArgumentManager.FILE_NAME = file_name_node.InnerText;
            }
            catch
            {

            }

            XmlNode file_formats_node = download_settings.SelectSingleNode("file_formats");
            try
            {
                ArgumentManager.FILE_FORMATS = file_formats_node.InnerText.Split(',');
            }
            catch
            {

            }

            XmlNode blacklist_path_node = download_settings.SelectSingleNode("blacklist_path");
            try
            {
                ArgumentManager.BLACKLIST_PATH = blacklist_path_node.InnerText.Replace("\\", "\\\\");
            }
            catch
            {

            }

            // ---------------------------------------------------- LOG SETTINGS ---------------------------------------------------- //

            XmlNode log_settings = settings_file.DocumentElement.SelectSingleNode("/settings/log_settings");

            XmlNode log_mode_node = log_settings.SelectSingleNode("log_mode");
            try
            {
                ArgumentManager.LOG_MODE = log_mode_node.InnerText.ToLower();
            }
            catch
            {

            }

            XmlNode log_path_node = log_settings.SelectSingleNode("log_path");
            try
            {
                ArgumentManager.LOG_PATH = log_path_node.InnerText.Replace("\\", "\\\\");
            }
            catch
            {

            }

            XmlNode log_name_node = log_settings.SelectSingleNode("log_name");
            try
            {
                ArgumentManager.LOG_NAME = log_name_node.InnerText;
            }
            catch
            {

            }

            XmlNode log_size_node = log_settings.SelectSingleNode("log_size");
            try
            {
                ArgumentManager.LOG_SIZE = int.Parse(log_size_node.InnerText);
            }
            catch
            {

            }

            ProgramMode.LoadMode();
        }
    }
}