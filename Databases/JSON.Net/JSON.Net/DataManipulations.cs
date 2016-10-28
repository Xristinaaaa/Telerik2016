using JSON.Net.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace JSON.Net
{
    public class DataManipulations
    {
        public static void DownloadRss(string url, string file)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, file);
            }
        }
        public static string ParseXmlToJson(string file)
        {
            var document = XDocument.Load(file);
            string json = JsonConvert.SerializeObject(document, Newtonsoft.Json.Formatting.Indented);
            return json;           
        }

        public static IEnumerable<JToken> GetVideoTitles(string file)
        {
            string json = ParseXmlToJson(file);
            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["feed"]["entry"].Select(entry => entry["title"]);
            
            return titles;
        }
        
        public static void PrintVideoTitles(string file)
        {
            Console.WriteLine("Video titles: ");
            Console.WriteLine(string.Join(Environment.NewLine, GetVideoTitles(file)));
        }
        public static IEnumerable<Video> GetVideos(string file)
        {
            var json = ParseXmlToJson(file);
            var jsonObj = JObject.Parse(json);
            var videos = jsonObj["feed"]["entry"].Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        //public static void JsonToPaco(string file)
        //{
        //    GetVideoTitles(file);
        //}

        public static string GetHtml(IEnumerable<Video> videos)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html><html><body>");
            foreach (var video in videos)
            {
                html.AppendFormat("<div style=\"float:left; width: 420px; height: 300px; padding:10px; " +
                                  "margin:5px; background-color:lightblue; border-radius:10px\">" +
                                  "<iframe width=\"420\" height=\"200\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<h3>{2}</h3><a href=\"{0}\">Redirect to YouTube</a></div>", video.Link.Href, video.Id, video.Title);
            }
            html.Append("</body></html>");

            return html.ToString();
        }

        public static void SaveHtml(string path, string html)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.Write(html);
            }
        }
    }
}
