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
            DOWNLOAD_THREADS = 1,
            MAX_DOWNLOAD_THREADS = 11,
            START_PAGE,
            END_PAGE;

        public static bool
            VERBOSE_CONSOLE = false,
            ALLOW_RUN = true;

        public static List<string>
            HTML_TAGS,
            HTML_ATTRIBUTES,
            FILE_FORMATS;

        public static int[]
            LOG_FILE_INDEX = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    }
}
