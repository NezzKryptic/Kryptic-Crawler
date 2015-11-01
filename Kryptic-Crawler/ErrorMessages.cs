using System;

namespace Kryptic_Crawler
{
    class ErrorMessages
    {
        // Alerting the user that they haven't provided any arguments
        public static void emptyParameters()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("It seems as though you didn't pass any parameters.");
            Console.WriteLine("");

            Console.ResetColor();

            Console.WriteLine("If this is your first time running the program feel free to consult the read me,it's got all kinds of useful parameters and decriptions as to what they do.");
            Console.WriteLine("");

            Console.WriteLine("But if you would like to continue to run the program this way, you're more than welcome to. But by Einstein's definition, you're insane, and you may be seeing \nthis message quite often.");
            Console.WriteLine("");

            Console.WriteLine("Now as every program would probably ask you to do at this point, you can press \nthe any key to exit, or maybe click that little X in the top corner, or you can sit here and stare at this screen, again I really don't mind.");
            Console.ReadKey();
        }

        // Alert the user that they have provided a parameter that the program doesn't recognize
        public static void invalidMode()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I'm sorry but the mode you typed isn't supported.");
            Console.ResetColor();
        }
    }
}
