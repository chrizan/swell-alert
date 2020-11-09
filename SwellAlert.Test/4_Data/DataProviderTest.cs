using FluentAssertions;
using SwellAlert.Data;
using SwellAlert.Models;
using Xunit;

namespace SwellAlert.Test.Data
{
    public class DataProviderTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            IDataProvider dataProvider = new MswDataProvider();

            // Act
            SwellData swellData = dataProvider.GetSwellData("");

            // Assert 
            swellData.Should().NotBeNull();
        }
    }
}
