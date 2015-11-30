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
    }
}
