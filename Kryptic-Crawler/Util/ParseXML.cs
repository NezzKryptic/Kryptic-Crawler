using System;
using System.Linq;
using System.Xml;

namespace Kryptic_Crawler.Util
{
    class ParseSettings
    {
        public static void ParseXMLSettings(string[] args)
        {
            XmlDocument settings_file = new XmlDocument();
            settings_file.Load(args[1]);

            // ---------------------------------------------------- GENERAL SETTINGS ---------------------------------------------------- //

            XmlNode general_settings = settings_file.DocumentElement.SelectSingleNode("/settings/general_settings");

            XmlNode program_mode_node = general_settings.SelectSingleNode("program_mode");
            if (program_mode_node != null && program_mode_node.InnerText != null)
            {
                ArgumentManager.PROGRAM_MODE = program_mode_node.InnerText;
            }
            else
            {
                ConsoleManager.WriteToConsole("You need to supply a <program_mode>");
                ConsoleManager.GetKeyPressed();
                Environment.Exit(0);
            }

            XmlNode download_threads_node = general_settings.SelectSingleNode("download_threads");
            if (download_threads_node != null && download_threads_node.InnerText != null)
            {
                ArgumentManager.DOWNLOAD_THREADS = int.Parse(download_threads_node.InnerText);
            }

            XmlNode verbose_console_node = general_settings.SelectSingleNode("verbose_console");
            if (verbose_console_node != null && verbose_console_node.InnerText != null)
            {
                ArgumentManager.VERBOSE_CONSOLE = Convert.ToBoolean(verbose_console_node.InnerText);
            }

            // ---------------------------------------------------- CONNECTION SETTINGS ---------------------------------------------------- //

            XmlNode connection_settings = settings_file.DocumentElement.SelectSingleNode("/settings/connection_settings");

            XmlNode download_url_node = connection_settings.SelectSingleNode("download_url");
            if (download_url_node != null && download_url_node.InnerText != null)
            {
                ArgumentManager.URL = download_url_node.InnerText.Replace("\\", "\\\\");
            }
            else
            {
                ConsoleManager.WriteToConsole("You need to supply a <download_url>");
                ConsoleManager.GetKeyPressed();
                Environment.Exit(0);
            }

            XmlNode start_page_node = connection_settings.SelectSingleNode("start_page");
            if (start_page_node != null && start_page_node.InnerText != null)
            {
                ArgumentManager.START_PAGE = int.Parse(start_page_node.InnerText);
            }

            XmlNode end_page_node = connection_settings.SelectSingleNode("end_page");
            if (end_page_node != null && end_page_node.InnerText != null)
            {
                ArgumentManager.END_PAGE = int.Parse(end_page_node.InnerText);
            }

            XmlNode html_tags_node = connection_settings.SelectSingleNode("html_tags");
            if (html_tags_node != null && html_tags_node.InnerText != null)
            {
                ArgumentManager.HTML_TAGS = (html_tags_node.InnerText).Split(',').ToList();
            }

            XmlNode html_attributes_node = connection_settings.SelectSingleNode("hmtl_attributes");
            if (html_attributes_node != null && html_attributes_node.InnerText != null)
            {
                ArgumentManager.HTML_ATTRIBUTES = (html_attributes_node.InnerText).Split(',').ToList();
            }

            XmlNode user_agent_node = connection_settings.SelectSingleNode("user_agent");
            if (user_agent_node != null && user_agent_node.InnerText != null)
            {
                ArgumentManager.USER_AGENT = user_agent_node.InnerText;
            }

            // ---------------------------------------------------- DOWNLOAD SETTINGS ---------------------------------------------------- //

            XmlNode download_settings = settings_file.DocumentElement.SelectSingleNode("/settings/download_settings");

            XmlNode download_path_node = download_settings.SelectSingleNode("download_path");
            if (download_path_node != null && download_path_node.InnerText != null)
            {
                ArgumentManager.DOWNLOAD_PATH = (download_path_node.InnerText).Replace("\\", "\\\\");
            }
            else
            {
                ConsoleManager.WriteToConsole("You need to supply a <download_path>");
                ConsoleManager.GetKeyPressed();
                Environment.Exit(0);
            }

            XmlNode file_name_node = download_settings.SelectSingleNode("file_name");
            if (file_name_node != null && file_name_node.InnerText != null)
            {
                ArgumentManager.FILE_NAME = file_name_node.InnerText;
            }

            XmlNode file_formats_node = download_settings.SelectSingleNode("file_formats");
            if (file_formats_node != null && file_formats_node.InnerText != null)
            {
                ArgumentManager.FILE_FORMATS = (file_formats_node.InnerText).Split(',').ToList();
            }

            XmlNode blacklist_node = download_settings.SelectSingleNode("blacklist");
            if (blacklist_node != null && blacklist_node.InnerText != null)
            {
                ArgumentManager.BLACKLIST_PATH = (blacklist_node.InnerText).Replace("\\", "\\\\");
            }

            // ---------------------------------------------------- LOG SETTINGS ---------------------------------------------------- //

            XmlNode log_settings = settings_file.DocumentElement.SelectSingleNode("/settings/log_settings");

            XmlNode log_mode_node = log_settings.SelectSingleNode("log_mode");
            if (log_mode_node != null && log_mode_node.InnerText != null)
            {
                ArgumentManager.LOG_FILE_MODE = log_mode_node.InnerText;
            }

            XmlNode log_path_node = log_settings.SelectSingleNode("log_path");
            if (log_path_node != null && log_path_node.InnerText != null)
            {
                ArgumentManager.LOG_FILE_PATH = (log_path_node.InnerText).Replace("\\", "\\\\");
            }

            XmlNode log_name_node = log_settings.SelectSingleNode("log_name");
            if (log_name_node != null && log_name_node.InnerText != null)
            {
                ArgumentManager.LOG_FILE_NAME = log_name_node.InnerText;
            }

            XmlNode log_size_node = log_settings.SelectSingleNode("log_size");
            if (log_size_node != null && log_size_node.InnerText != null)
            {
                ArgumentManager.LOG_FILE_SIZE = int.Parse(log_size_node.InnerText);
            }

            ProgramMode.LoadMode(ArgumentManager.PROGRAM_MODE);
        }
    }
}
