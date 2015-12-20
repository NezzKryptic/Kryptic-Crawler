using System;

namespace Kryptic_Crawler.Util
{
    class ConsoleManager
    {
        public static void SetConsoleTitle(string title)
        {
            Console.Title = title;
        }

        public static void WriteToConsole(string text)
        {
            Console.WriteLine(text + Environment.NewLine);
        }

        public static ConsoleKeyInfo GetKeyPressed()
        {
            return Console.ReadKey();
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void ReadInput()
        {
            while (ArgumentManager.ALLOW_RUN)
            {
                string command_input = Console.ReadLine().ToLower();

                switch (command_input)
                {
                    case "stop":
                        ArgumentManager.ALLOW_RUN = false;
                        break;

                    default:
                        WriteToConsole("Command not recognized");
                        break;
                }
            }
        }
    }
}
