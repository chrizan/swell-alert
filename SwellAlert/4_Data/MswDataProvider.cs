using HtmlAgilityPack;
using SwellAlert.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SwellAlert.Data
{
    public class MswDataProvider : IDataProvider
    {
        private const int AvailableForecastDays = 7;

        public SwellData GetSwellDataFromFile(string filePath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);
            return GetSwellData(htmlDoc);
        }

        public async Task<SwellData> GetSwellDataFromWeb(string spotUrl)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = await web.LoadFromWebAsync(spotUrl);
            return GetSwellData(htmlDoc);
        }

        private SwellData GetSwellData(HtmlDocument htmlDoc)
        {
            SwellData swellData = new SwellData();
            for (int day = 1; day <= AvailableForecastDays; day++)
            {
                swellData.Add(day, GetDailySwellData(day, htmlDoc));
            }
            return swellData;
        }

        private DailySwellData GetDailySwellData(int day, HtmlDocument htmlDoc)
        {
            DailySwellData dailySwellData = new DailySwellData
            {
                Day = day.ToString()
            };

            var dayNodes = htmlDoc.DocumentNode.Descendants("tr").Where(tr => tr.GetAttributeValue("data-forecast-day", "-1") == day.ToString());

            foreach (var dayNode in dayNodes)
            {
                var listNodes = dayNode.Descendants("li");

                foreach (var listNode in listNodes)
                {
                    string starClass = listNode.GetAttributeValue("class", string.Empty);
                    switch (starClass)
                    {
                        case "active ":
                            dailySwellData.Full += 1;
                            break;
                        case "inactive ":
                            dailySwellData.Semi += 1;
                            break;
                        case "placeholder":
                            dailySwellData.None += 1;
                            break;
                        default:
                            break;
                    }
                }
            }
            return dailySwellData;
        }
    }
}
