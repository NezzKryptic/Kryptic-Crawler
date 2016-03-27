using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Kryptic_Crawler.Util
{
    class ParseJSON
    {
        public static void ParseJSONSettings(string[] args)
        {
            string settings = File.ReadAllText(args[1].Replace("\\", "\\\\"));

            JObject setting_json = JObject.Parse(settings);

            // Program Mode
            try
            {
                ArgumentManager.PROGRAM_MODE = (string)setting_json["program_mode"];
            }
            catch
            {

            }

            // Download Threads
            try
            {
                ArgumentManager.DOWNLOAD_THREADS = (int)setting_json["download_threads"];
            }
            catch
            {

            }

            // Verbose Console
            try
            {
                ArgumentManager.VERBOSE_CONSOLE = (bool)setting_json["verbose_console"];
            }
            catch
            {

            }

            // Download URL
            try
            {
                ArgumentManager.DOWNLOAD_URL = (string)setting_json["download_url"];
            }
            catch
            {

            }

            // Start Page
            try
            {
                ArgumentManager.START_PAGE = (int)setting_json["start_page"];
            }
            catch
            {

            }

            // End Page
            try
            {
                ArgumentManager.END_PAGE = (int)setting_json["end_page"];
            }
            catch
            {

            }

            // HTML Tags
            try
            {
                ArgumentManager.HTML_TAGS = ((string)setting_json["html_tags"]).Split(',');
            }
            catch
            {

            }

            // HTML Attributes
            try
            {
                ArgumentManager.HTML_ATTRIBUTES = ((string)setting_json["html_attributes"]).Split(',');
            }
            catch
            {

            }

            // User Agent
            try
            {
                ArgumentManager.USER_AGENT = (string)setting_json["user_agent"];
            }
            catch
            {

            }

            // Download Path
            try
            {
                ArgumentManager.DOWNLOAD_PATH = (string)setting_json["download_path"];
            }
            catch
            {

            }

            // File Name
            try
            {
                ArgumentManager.FILE_NAME = (string)setting_json["file_name"];
            }
            catch
            {

            }

            // File Formats
            try
            {
                ArgumentManager.FILE_FORMATS = ((string)setting_json["file_formats"]).Split(',');
            }
            catch
            {

            }

            // Blacklist Path
            try
            {
                ArgumentManager.BLACKLIST_PATH = (string)setting_json["blacklist_path"];
            }
            catch
            {

            }

            // Log Mode
            try
            {
                ArgumentManager.LOG_MODE = (string)setting_json["log_mode"];
            }
            catch
            {

            }

            // Log Path
            try
            {
                ArgumentManager.LOG_PATH = (string)setting_json["log_path"];
            }
            catch
            {

            }

            // Log Name
            try
            {
                ArgumentManager.LOG_NAME = (string)setting_json["log_name"];
            }
            catch
            {

            }

            // Log Size
            try
            {
                ArgumentManager.LOG_SIZE = (int)setting_json["log_size"];
            }
            catch
            {

            }

            ProgramMode.LoadMode(ArgumentManager.PROGRAM_MODE);
        }
    }
}
