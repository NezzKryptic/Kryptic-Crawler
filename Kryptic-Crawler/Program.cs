using System;

namespace Kryptic_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instance Declaration
            ErrorMessages errorMessages = new ErrorMessages();
            ParseSettings parseSettings = new ParseSettings();

            // Checking that args isn't null or equal to 0
            if (args.Length == 0 || args == null)
            {
                errorMessages.emptyParameters();
            }
            else
            {
                Console.Clear();
                parseSettings.parseSettings(args);
            }
        }
    }
}
