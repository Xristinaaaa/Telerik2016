using JSON.Net.Models;
using System.Collections.Generic;

namespace JSON.Net
{
    class Startup
    {
        static void Main(string[] args)
        {
            const string url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            const string fileName = "../../RSSfeed.xml";
            const string html = "../../index.html";

            DataManipulations.DownloadRss(url, fileName);
        
            DataManipulations.ParseXmlToJson(fileName);

            DataManipulations.PrintVideoTitles(fileName);

            IEnumerable<Video> videos = DataManipulations.GetVideos(fileName);
            DataManipulations.SaveHtml(html, DataManipulations.GetHtml(videos));
        }
    }
}
