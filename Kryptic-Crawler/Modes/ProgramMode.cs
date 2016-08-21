using Kryptic_Crawler.Util;
using System;

namespace Kryptic_Crawler.Modes
{
    class ProgramMode
    {
        internal static void LoadMode()
        {
            switch (ArgumentManager.PROGRAM_MODE)
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
