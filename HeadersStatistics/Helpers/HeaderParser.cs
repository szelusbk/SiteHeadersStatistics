using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HeadersStatistics.Helpers
{
    public class HeaderParser
    {
        private readonly string url = "https://www.finai.pl/blog?page=";
        private HtmlWeb htmlWeb = new HtmlWeb();

        public List<string> GetLatestHeaders()
        {
            List<string> latestHeaders = new List<string>();
            int page = 1;

            while(latestHeaders.Count < 20)
            {
                FillHeadersList(latestHeaders, page++);
            }

            return latestHeaders;
        }

        private void FillHeadersList(List<string> latestHeaders, int page)
        {
            HtmlDocument doc = htmlWeb.Load(url + page);

            var nodes = doc.DocumentNode.Descendants("div")
                .Where(x => x.HasClass("post-entry"))
                .ToList();

            foreach(var n in nodes)
            {
                if (latestHeaders.Count >= 20)
                    break;

                string entry = GetStringFromHeaderNode(n);

                if(!string.IsNullOrEmpty(entry))
                    latestHeaders.Add(entry);
            }
        }

        private string GetStringFromHeaderNode(HtmlNode node)
        {
            string title = node.Descendants("a")
                .FirstOrDefault()
                .InnerText
                .Trim();

            string content = node.Descendants("h3")
                .FirstOrDefault()
                .InnerText
                .Trim();

            title = System.Net.WebUtility.HtmlDecode(title).ToLower();
            content = System.Net.WebUtility.HtmlDecode(content).ToLower();

            return title + " " + content;
        }
    }
}
