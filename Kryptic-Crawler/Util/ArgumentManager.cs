using System;
using System.Collections.Generic;

namespace Kryptic_Crawler.Util
{
    class ArgumentManager
    {
        public static string
            PROGRAM_MODE,
            URL,
            DOWNLOAD_PATH = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Content",
            FILE_NAME = "File(|#|)",
            BLACKLIST_PATH,
            USER_AGENT = "Kryptic-Crawler",
            LOG_FILE_MODE,
            LOG_FILE_PATH = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Content\\Logs",
            LOG_FILE_NAME = "Log_|#|";

        public static int
            LOG_FILE_SIZE,
            LOG_FILE_INDEX = 0,
            DOWNLOAD_THREADS = 1,
            START_PAGE,
            END_PAGE;

        public static bool
            VERBOSE_CONSOLE = false;

        public static List<string>
            HTML_TAGS,
            HTML_ATTRIBUTES,
            FILE_FORMATS;
    }
}
