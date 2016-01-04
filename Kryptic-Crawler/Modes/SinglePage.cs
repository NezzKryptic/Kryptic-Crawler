using Kryptic_Crawler.Util;

namespace Kryptic_Crawler.Modes
{
    class SinglePage
    {
        public static void SingleConnect()
        {
            WebHandler.PullContentLinks(ArgumentManager.DOWNLOAD_URL, 0, 0);
        }
    }
}
