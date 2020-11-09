using System.Threading.Tasks;

namespace SwellAlert.Models
{
    public interface IDataProvider
    {
        Task<SwellData> GetSwellDataFromWeb(string spotUrl);
        SwellData GetSwellDataFromFile(string filePath);
    }
}