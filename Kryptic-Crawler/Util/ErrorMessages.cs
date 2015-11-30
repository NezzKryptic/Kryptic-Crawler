using System;

namespace Kryptic_Crawler
{
    class ErrorMessages
    {
        public static string[] returnText { get; private set; } = new string[3];

        public static string[] EmptyParameters()
        {
            returnText[0] = "No parameters passed to program";
            returnText[1] = "If you need help, please feel free to consult the documentation at:\n" + Environment.CurrentDirectory + "\\Documentation";
            returnText[2] = "Please press any key to continue";

            return returnText;
        }

        public static string[] InvalidMode()
        {
            returnText[0] = "I'm sorry but the mode you requested isn't supported.";
            returnText[1] = "Please press any key to continue";

            return returnText;
        }
    }
}
