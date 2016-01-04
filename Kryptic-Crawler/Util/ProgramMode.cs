using Kryptic_Crawler.Modes;
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
                    Console.WriteLine(
                        "I'm sorry but the mode you requested isn't supported" +
                        "\n\n" +
                        "Please press any key to continue"
                        );
                    break;
            }
        }
    }
}
