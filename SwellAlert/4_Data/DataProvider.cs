using HtmlAgilityPack;
using SwellAlert.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SwellAlert.Data
{
    public class DataProvider : IDataProvider
    {
        public async Task<SwellData> GetSwellDataFromFile(string filePath)
        {
            HtmlDocument load()
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(filePath);
                return doc;
            }
            Task<HtmlDocument> task = new Task<HtmlDocument>(load);
            return await GetSwellData(task);
        }

        public async Task<SwellData> GetSwellDataFromWeb(string mswSpotUrl)
        {
            HtmlWeb web = new HtmlWeb();
            Task<HtmlDocument> task = web.LoadFromWebAsync(mswSpotUrl);
            return await GetSwellData(task);
        }

        private async Task<SwellData> GetSwellData(Task<HtmlDocument> task)
        {
            HtmlDocument doc = task.Result;

            var day_1_nodes = doc.DocumentNode.Descendants("tr")
            .Where(tr => tr.GetAttributeValue("data-forecast-day", "-1") == "1");

            string s = "";
            foreach (var node in day_1_nodes)
            {
                var lis = node.Descendants("li");

                foreach (var li in lis)
                {
                    string str = li.GetAttributeValue("class", "");
                    switch (str)
                    {
                        case "":
                            break;
                        case "active ":
                            s += " " + "active";
                            break;
                        case "inactive ":
                            s += " " + "inactive";
                            break;
                        case "placeholder":
                            s += " " + "placeholder";
                            break;
                        default:
                            break;
                    }
                }
                s += System.Environment.NewLine;
            }
        }
    }
}
