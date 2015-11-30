using Kryptic_Crawler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptic_Crawler.Scanners
{
    class MultiPage
    {
        public static void MultiConnect()
        {
            for (int pageIndex = ArgumentManager.START_PAGE; pageIndex < ArgumentManager.END_PAGE; pageIndex++)
            {
                WebHandler.PullContentLinks((ArgumentManager.URL).Replace("|#|", pageIndex.ToString()), pageIndex);
            }
        }
    }
}
