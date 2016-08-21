using Kryptic_Crawler.Modes;
using Kryptic_Crawler.Util;
using System;

namespace Kryptic_Crawler.Parsers
{
    class ParseCMD
    {
        public static void ParseCMDSettings(string[] args)
        {
            for(int args_index = 1; args_index < args.Length; args_index += 0)
            {
                string current_argument = args[args_index].ToLower();

                switch (current_argument)
                {
                    case "-program_mode":
                        ArgumentManager.PROGRAM_MODE = args[args_index + 1];
                        args_index += 2;
                        break;

                    case "-download_threads":
                        ArgumentManager.DOWNLOAD_THREADS = int.Parse(args[args_index + 1]);
                        args_index += 2;
                        break;

                    // ADD DIFFERENT VERBOSE LEVELS - STANDARD, ERROR, LOG, ETC
                    case "-verbose_console":
                        ArgumentManager.VERBOSE_CONSOLE = bool.Parse(args[args_index + 1]);
                        args_index += 2;
                        break;

                    case "-download_url":
                        ArgumentManager.DOWNLOAD_URL = args[args_index + 1].Replace("\\", "\\\\");
                        args_index += 2;
                        break;

                    case "-start_page":
                        ArgumentManager.START_PAGE = int.Parse(args[args_index + 1]);
                        args_index += 2;
                        break;

                    case "-end_page":
                        ArgumentManager.START_PAGE = int.Parse(args[args_index + 1]);
                        args_index += 2;
                        break;

                    case "-html_tags":
                        ArgumentManager.HTML_TAGS = args[args_index + 1].Split(',');
                        args_index += 2;
                        break;

                    case "-html_attributes":
                        ArgumentManager.HTML_ATTRIBUTES = args[args_index + 1].Split(',');
                        args_index += 2;
                        break;

                    case "-user_agent":
                        ArgumentManager.USER_AGENT = args[args_index + 1];
                        args_index += 2;
                        break;

                    case "-download_path":
                        ArgumentManager.DOWNLOAD_PATH = args[args_index + 1].Replace("\\", "\\\\");
                        args_index += 2;
                        break;

                    case "-file_name":
                        ArgumentManager.FILE_NAME = args[args_index + 1];
                        args_index += 2;
                        break;

                    case "-file_formats":
                        ArgumentManager.FILE_FORMATS = args[args_index + 1].Split(',');
                        args_index += 2;
                        break;

                    case "-blacklist_path":
                        ArgumentManager.BLACKLIST_PATH = args[args_index + 1].Replace("\\", "\\\\");
                        args_index += 2;
                        break;

                    case "-log_mode":
                        ArgumentManager.LOG_MODE = args[args_index + 1];
                        args_index += 2;
                        break;

                    case "-log_path":
                        ArgumentManager.LOG_PATH = args[args_index + 1].Replace("\\", "\\\\");
                        args_index += 2;
                        break;

                    case "-log_name":
                        ArgumentManager.LOG_NAME = args[args_index + 1];
                        args_index += 2;
                        break;

                    case "-log_size":
                        ArgumentManager.LOG_SIZE = int.Parse(args[args_index + 1]);
                        args_index += 2;
                        break;

                    default:
                        Console.WriteLine("\"" + current_argument + "\" not recognized");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }

            if (ArgumentManager.PROGRAM_MODE == null)
            {
                Console.WriteLine("You need to supply a -program_mode");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (ArgumentManager.DOWNLOAD_URL == null)
            {
                Console.WriteLine("You need to supply a -download_url");
                Console.ReadKey();
                Environment.Exit(0);
            }

            ProgramMode.LoadMode();
        }
    }
}
