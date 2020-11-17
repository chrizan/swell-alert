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
                swellData.Add((ForecastDay)day, GetDailySwellData(day, htmlDoc));
            }
            return swellData;
        }

        private DailySwellData GetDailySwellData(int day, HtmlDocument htmlDoc)
        {
            var dayNodes = htmlDoc.DocumentNode.Descendants("tr").Where(tr => tr.GetAttributeValue("data-forecast-day", "-1") == day.ToString());

            DailySwellData dailySwellData = new DailySwellData()
            {
                Date = dayNodes.FirstOrDefault().GetAttributeValue("data-date-anchor", "Date not found")
            };

            for (int dayNode = 1; dayNode <= dayNodes.Count(); dayNode++)
            {
                dailySwellData.Add((ForecastHour)dayNode, GetHourlySwellData(dayNodes.ElementAt(dayNode - 1)));
            }

            return dailySwellData;
        }

        private HourlySwellData GetHourlySwellData(HtmlNode dayNode)
        {
            HourlySwellData hourlySwellData = new HourlySwellData();
            
            var listNodes = dayNode.Descendants("li");

            foreach (var listNode in listNodes)
            {
                string starClass = listNode.GetAttributeValue("class", string.Empty);
                switch (starClass)
                {
                    case "active ":
                        hourlySwellData.Full += 1;
                        break;
                    case "inactive ":
                        hourlySwellData.Semi += 1;
                        break;
                    case "placeholder":
                        hourlySwellData.None += 1;
                        break;
                    default:
                        break;
                }
            }
            return hourlySwellData;
        }
    }
}
