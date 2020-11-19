using FluentAssertions;
using SwellAlert.Data;
using SwellAlert.Models;
using Xunit;

namespace SwellAlert.Test.Data
{
    public class MswDataProviderTest
    {
        private const string MswVieuxBoucauForecast = @"TestFiles\MswVieuxBoucau.html";

        [Fact]
        public void Test_GetSwellDataFromFile()
        {
            // Arrange
            IDataProvider mswDataProvider = new MswDataProvider();

            // Act
            SwellData swellData = mswDataProvider.GetSwellDataFromFile(MswVieuxBoucauForecast);

            // Assert
            swellData.Count.Should().Be(7);

            for (int day = 1; day <= swellData.Count; day++)
            {
                bool hasValueForDay = swellData.TryGetValue(day, out DailySwellData dailySwellData);
                hasValueForDay.Should().BeTrue();

                AssertDailySwellData(day, dailySwellData);
            }
        }

        private void AssertDailySwellData(int day, DailySwellData dailySwellData)
        {
            dailySwellData.Date.Should().NotBeNullOrEmpty();
            dailySwellData.Count.Should().Be(8);

            for (int forecastHour = 1; forecastHour <= dailySwellData.Count; forecastHour++)
            {
                bool hasValueForHour = dailySwellData.TryGetValue((ForecastHour)forecastHour, out HourlySwellData hourlySwellData);
                hasValueForHour.Should().BeTrue();

                switch (day)
                {
                    case 1:
                        dailySwellData.Date.Should().BeEquivalentTo("Tuesday1011");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 2:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 3:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 4:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 5:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 6:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    case 7:
                        dailySwellData.Date.Should().BeEquivalentTo("");
                        switch (forecastHour)
                        {
                            case (int)ForecastHour.Hour_12am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_3am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9am:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_Noon:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;
                            case (int)ForecastHour.Hour_3pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_6pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            case (int)ForecastHour.Hour_9pm:
                                hourlySwellData.FullStars.Should().Be(1);
                                hourlySwellData.BlurredStars.Should().Be(1);
                                hourlySwellData.EmptyStars.Should().Be(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
