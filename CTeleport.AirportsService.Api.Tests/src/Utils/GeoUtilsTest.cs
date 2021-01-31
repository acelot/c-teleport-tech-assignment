using System;
using CTeleport.AirportsService.Api.Enums;
using CTeleport.AirportsService.Api.Utils;
using CTeleport.AirportsService.Api.ValueObjects;
using NUnit.Framework;

namespace CTeleport.AirportsService.Api.Tests.Utils
{
    [TestFixture]
    public class GeoUtilsTest
    {
        [Test, TestCaseSource(nameof(CalculateDistanceTestCases))]
        public void TestCalculateDistance_PassedArguments_ReturnsCorrectValue(
            Location origin,
            Location destination,
            DistanceUnit unit,
            double expected
        )
        {
            Assert.AreEqual(expected, new GeoUtils().CalculateDistance(origin, destination, unit));
        }

        static object[] CalculateDistanceTestCases =
        {
            // Same locations
            new object[] {
                new Location
                {
                    Latitude = 0.0,
                    Longitude = 0.0,
                },
                new Location
                {
                    Latitude = 0.0,
                    Longitude = 0.0,
                },
                DistanceUnit.Meters,
                0
            },
            // 1000 meters
            new object[] {
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.0,
                },
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.014608,
                },
                DistanceUnit.Meters,
                1000
            },
            // 1000 meters in kilometers
            new object[] {
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.0,
                },
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.01461,
                },
                DistanceUnit.Kilometers,
                1
            },
            // 1000 meters in miles
            new object[] {
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.0,
                },
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.01461,
                },
                DistanceUnit.Miles,
                0.622
            },
            // 1000 meters in nautical miles
            new object[] {
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.0,
                },
                new Location
                {
                    Latitude = 52.0,
                    Longitude = 12.01461,
                },
                DistanceUnit.NauticalMiles,
                0.540
            }
        };

        [Test, TestCaseSource(nameof(CalculateDistanceInvalidTestCases))]
        public void TestCalculateDistance_PassedInvalidLocatiioin_ThrowsArgumentException(Location location)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new GeoUtils().CalculateDistance(location, location, DistanceUnit.Meters);
            });
        }

        static object[] CalculateDistanceInvalidTestCases =
        {
            // Invalid latitude
            new object[] {
                new Location
                {
                    Latitude = 180.1,
                    Longitude = 0.0,
                }
            },
            // Invalid latitude
            new object[] {
                new Location
                {
                    Latitude = -180.1,
                    Longitude = 0.0,
                }
            },
            // Invalid longitude
            new object[] {
                new Location
                {
                    Latitude = 0.0,
                    Longitude = 180.1,
                }
            },
            // Invalid longitude
            new object[] {
                new Location
                {
                    Latitude = 0.0,
                    Longitude = -180.1,
                }
            },
        };
    }
}