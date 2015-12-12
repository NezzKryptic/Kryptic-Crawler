using Kryptic_Crawler.Util;
using System.Threading;

namespace Kryptic_Crawler.Scanners
{
    class MultiPage
    {
        public static void PageConnect(int thread_increment)
        {
            for (int pageIndex = ArgumentManager.START_PAGE + thread_increment; pageIndex < ArgumentManager.END_PAGE; pageIndex += ArgumentManager.DOWNLOAD_THREADS)
            {
                WebHandler.PullContentLinks(ArgumentManager.URL.Replace("|#|", pageIndex.ToString()), pageIndex);
            }
        }

        public static void MultiConnect()
        {
            Thread[] download_threads = new Thread[11];

            for (int current_thread = 0; current_thread < ArgumentManager.DOWNLOAD_THREADS; current_thread++)
            {
                download_threads[current_thread] = new Thread(() => PageConnect(current_thread));
                download_threads[current_thread].Start();
            }
        }
    }
}
