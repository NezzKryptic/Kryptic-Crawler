using Kryptic_Crawler.Util;
using System.Threading;

namespace Kryptic_Crawler.Scanners
{
    class MultiPage
    {
        public static void PageConnect(int thread_index)
        {
            for (int page_index = ArgumentManager.START_PAGE + thread_index; page_index < ArgumentManager.END_PAGE; page_index += ArgumentManager.DOWNLOAD_THREADS)
            {
                if (ArgumentManager.ALLOW_RUN)
                {
                    WebHandler.PullContentLinks(ArgumentManager.URL.Replace("|#|", page_index.ToString()), page_index, thread_index);
                }
                else
                {
                    break;
                }
            }
        }

        public static void MultiConnect()
        {
            Thread read_console_input = new Thread(() => ConsoleManager.ReadInput());
            read_console_input.Start();

            Thread[] download_threads = new Thread[ArgumentManager.MAX_DOWNLOAD_THREADS];

            for (int thread_index = 0; thread_index < (ArgumentManager.DOWNLOAD_THREADS + 1); thread_index++)
            {
                download_threads[thread_index] = new Thread(() => PageConnect(thread_index));
                download_threads[thread_index].Start();
            }
        }
    }
}
