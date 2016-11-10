using System;

namespace Kryptic_Crawler.Util
{
    class ArgumentManager
    {
        public static string
            PROGRAM_MODE,
            DOWNLOAD_URL,
            DOWNLOAD_PATH = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Content",
            FILE_NAME = "File(|#|)",
            BLACKLIST_PATH,
            USER_AGENT = "Kryptic-Crawler",
            LOG_MODE,
            LOG_PATH = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Content\\Logs",
            LOG_NAME = "Log_|#|";

        public static int
            DOWNLOAD_THREADS = 2,
            MAX_DOWNLOAD_THREADS = 256,
            START_PAGE,
            END_PAGE,
            LOG_SIZE;

        public static bool
            VERBOSE_CONSOLE = false,
            ALLOW_RUN = true;

        public static string[]
            HTML_TAGS = { "img" },
            HTML_ATTRIBUTES = { "src" },
            FILE_FORMATS = { "jpeg", "jpg", "png", "gif" };

        public static int[]
            PAGE_INDEXES = new int[MAX_DOWNLOAD_THREADS],
            LOG_INDEX = new int[MAX_DOWNLOAD_THREADS];
    }
}
