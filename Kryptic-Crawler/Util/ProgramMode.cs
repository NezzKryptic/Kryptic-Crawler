using Kryptic_Crawler.Scanners;
using System;

namespace Kryptic_Crawler.Util
{
    class ProgramMode
    {
        public static void LoadMode(string programMode)
        {
            switch (programMode)
            {
                case "single-page":
                    SinglePage.SingleConnect();
                    break;

                case "multi-page":
                    MultiPage.MultiConnect();
                    break;

                case "file-direct":
                    FileDirect.FileDirectConnect();
                    break;

                case "file-pages":
                    FilePages.FilePagesConnect();
                    break;

                case "subreddit":
                    Console.WriteLine("Mode not supported yet");
                    break;

                default:
                    ErrorMessages.InvalidMode();
                    break;
            }
        }
    }
}
