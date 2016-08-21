using System;

namespace Kryptic_Crawler.Util
{
    class ConsoleManager
    {
        internal static void ReadInput()
        {
            while (ArgumentManager.ALLOW_RUN)
            {
                string commandInput = Console.ReadLine().ToLower();

                switch (commandInput)
                {
                    case "stop":
                        ArgumentManager.ALLOW_RUN = false;
                        break;

                    default:
                        Console.WriteLine("Command not recognized");
                        break;
                }
            }
        }
    }
}
