using Kryptic_Crawler.Util;
using System;

namespace Kryptic_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Kryptic-Crawler";

            if (args.Length == 0 || args == null)
            {
                Console.Clear();

                Console.WriteLine(
                        "No parameters passed to program" +
                        "\n\n" +
                        "If you need help, please feel free to consult the documentation at:\n" + Environment.CurrentDirectory + "\\Documentation" +
                        "\n\n" +
                        "Please press any key to continue"
                    );

                Console.ReadKey();
            }
            else if (args[0] == "-xml")
            {
                Console.Clear();
                ParseXML.ParseXMLSettings(args);
            }
            else if (args[0] == "-direct")
            {
                Console.Clear();
                ParseCMD.ParseCMDSettings(args);
            }
        }
    }
}
