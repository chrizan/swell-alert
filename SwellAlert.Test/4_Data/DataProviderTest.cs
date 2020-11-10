using FluentAssertions;
using SwellAlert.Data;
using SwellAlert.Models;
using Xunit;

namespace SwellAlert.Test.Data
{
    public class DataProviderTest
    {
        private const string MswVieuxBoucauForecast = @"TestFiles\MswVieuxBoucau.html";

        [Fact]
        public void Test1()
        {
            // Arrange
            IDataProvider mswDataProvider = new MswDataProvider();

            // Act
            SwellData swellData = mswDataProvider.GetSwellDataFromFile(MswVieuxBoucauForecast);

            // Assert 
            swellData.Should().NotBeNull();
        }
    }
}
