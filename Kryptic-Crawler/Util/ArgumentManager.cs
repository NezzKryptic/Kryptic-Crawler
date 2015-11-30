using System;
using System.Collections.Generic;

namespace Kryptic_Crawler.Util
{
    class ArgumentManager
    {
        public static string
            URL,
            OUTPUT_PATH = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Content",
            FILE_NAME = "File(|#|)",
            BLACKLIST_PATH,
            LOGFILE_PATH,
            USER_AGENT = "Kryptic-Crawler";

        public static int
            START_PAGE,
            END_PAGE,
            FILE_INDEX;

        public static bool
            VERBOSE_CONSOLE = false;

        public static List<string>
            HTML_TAGS,
            HTML_ATTRIBUTES,
            FILE_FORMATS;
    }
}
