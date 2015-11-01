using Kryptic_Crawler.Downloaders;
using System;

namespace Kryptic_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Checking that args isn't null or equal to 0
            if (args.Length == 0 || args == null)
            {
                ErrorMessages.emptyParameters();
            }
            else if(args[0] == "-direct")
            {
                // URL
                ArgumentManager.setSetting(0, args[1]);

                // Output Path
                ArgumentManager.setSetting(1, args[2]);

                // File Index
                ArgumentManager.setSetting(2, args[3]);

                // File Name
                ArgumentManager.setSetting(3, args[4]);

                // File Types
                ArgumentManager.setSetting(11, args[5]);

                GeneralDownloader.downloadFile(ArgumentManager.getSetting(0), int.Parse(ArgumentManager.getSetting(2)));
            }
            else
            {
                // Parse settings from provided xml file
                Console.Clear();
                ParseSettings.parseSettings(args);
            }
        }
    }
}
