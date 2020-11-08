using System.Threading.Tasks;

namespace SwellAlert.Models
{
    public interface IDataProvider
    {
        Task<SwellData> GetSwellDataFromWeb(string mswSpotUrl);
        Task<SwellData> GetSwellDataFromFile(string filePath);
    }
}