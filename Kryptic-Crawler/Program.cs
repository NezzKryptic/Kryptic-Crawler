using Kryptic_Crawler.Util;

namespace Kryptic_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager.SetConsoleTitle("Kryptic-Crawler");

            if (args.Length == 0 || args == null)
            {
                ConsoleManager.ClearConsole();

                foreach (string line in ErrorMessages.EmptyParameters())
                {
                    ConsoleManager.WriteToConsole(line);
                }

                ConsoleManager.GetKeyPressed();
            }
            else if (args[0] == "-xml")
            {
                ConsoleManager.ClearConsole();
                ParseSettings.ParseXMLSettings(args);
            }
            else if (args[0] == "-manual")
            {
                ConsoleManager.WriteToConsole("Mode not supported yet");
            }
            else if (args[0] == "-direct")
            {
                ConsoleManager.WriteToConsole("Mode not supported yet");
            }
        }
    }
}
