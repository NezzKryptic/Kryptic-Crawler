namespace Kryptic_Crawler
{
    class ArgumentManager
    {
        /*  
         *  - Argument Storage -
         *
         *  0: URL
         *  1: Output
         *  2: File Index
         *  3: File Name
         *  4: Blacklist Path
         *  5: Verbose Console Output
         *  6: Start Page
         *  7: End Page
         *  8: Log File
         *  9: HTML Tags
         * 10: HTML Attributes
         * 11: File Formats
         * 12: MIME Types
         */
        private static string[] settingsList = new string[13];

        public static string getSetting(int index)
        {
            return settingsList[index];
        }

        public static void setSetting(int index, string content)
        {
            settingsList[index] = content;
        }
    }
}
