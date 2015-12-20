using Kryptic_Crawler.Util;
using System.IO;

namespace Kryptic_Crawler.Scanners
{
    class FilePages
    {
        public static void FilePagesConnect()
        {
            string[] url_list = File.ReadAllLines(ArgumentManager.URL);

            foreach(string url in url_list)
            {
                WebHandler.PullContentLinks(url, 0, 0);
            }
        }
    }
}
