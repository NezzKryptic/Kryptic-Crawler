using Kryptic_Crawler.Util;

namespace Kryptic_Crawler.Scanners
{
    class SinglePage
    {
        public static void SingleConnect()
        {
            WebHandler.PullContentLinks(ArgumentManager.URL, 0, 0);
        }
    }
}
