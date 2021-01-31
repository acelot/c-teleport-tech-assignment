using System.Threading;
using System.Threading.Tasks;
using CTeleport.AirportsService.Api.DistanceApi.Services;
using CTeleport.AirportsService.Api.DistanceApi.ValueObjects;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using PlacesServiceAirport = CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects.Airport;
using PlacesServiceAirportNotFound = CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects.AirportNotFound;
using PlacesServiceLocation = CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects.Location;
using NSubstitute;
using NUnit.Framework;
using OneOf;
using CTeleport.AirportsService.Api.DistanceApi.Exceptions;
using CTeleport.PlacesService.ApiClient.Exceptions;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.Tests.DistanceApi.Services
{
    [TestFixture]
    public class DistanceApiServiceTest
    {
        [Test]
        public async Task TestGetAirport_ExistingIataCodePassed_ReturnsAirport()
        {
            var airport = new PlacesServiceAirport
            {
                Name = "Test Airport",
                IataCode = "TST",
                Location = new PlacesServiceLocation
                {
                    Latitude = default,
                    Longitude = default,
                },
                TimezoneRegionName = "test/test",
                Hubs = 100500,
                Rating = 5,
                CountryName = "Test United States",
                CountryIataCode = "TUS",
                CityName = "Testinsk",
                CityIataCode = "TSK",
            };

            var expected = new Airport
            {
                Name = airport.Name,
                IataCode = airport.IataCode,
                Location = new Location
                {
                    Latitude = airport.Location.Latitude,
                    Longitude = airport.Location.Longitude,
                },
            };

            var ct = CancellationToken.None;

            var airportsApi = Substitute.For<IAirportsApi>();
            airportsApi
                .GetAirport("TST", ct)
                .Returns(
                    Task.FromResult<OneOf<PlacesServiceAirport, PlacesServiceAirportNotFound>>(airport)
                );

            var service = new DistanceApiService(airportsApi);
            var actualResult = await service.GetAirport("TST", ct);

            Assert.IsTrue(actualResult.IsT0);
            Assert.AreEqual(expected, actualResult.AsT0);
        }

        [Test]
        public async Task TestGetAirport_NotExistingIataCodePassed_ReturnsAirportNotFound()
        {
            var airportNotFound = new PlacesServiceAirportNotFound
            {
                IataCode = "TST",
            };

            var expected = new AirportNotFound
            {
                IataCode = "TST",
            };

            var ct = CancellationToken.None;

            var airportsApi = Substitute.For<IAirportsApi>();
            airportsApi
                .GetAirport("TST", ct)
                .Returns(
                    Task.FromResult<OneOf<PlacesServiceAirport, PlacesServiceAirportNotFound>>(airportNotFound)
                );

            var service = new DistanceApiService(airportsApi);
            var actualResult = await service.GetAirport("TST", ct);

            Assert.IsTrue(actualResult.IsT1);
            Assert.AreEqual(expected, actualResult.AsT1);
        }

        [Test]
        public void TestGetAirport_AirportsApiThrowingException_ThrowsDistanceApiServiceException()
        {
            var ct = CancellationToken.None;

            var airportsApi = Substitute.For<IAirportsApi>();

            airportsApi
                .GetAirport("TST", ct)
                .Returns(
                    Task.FromException<OneOf<PlacesServiceAirport, PlacesServiceAirportNotFound>>(
                        new PlacesServiceApiClientException("test message")
                    )
                );

            var service = new DistanceApiService(airportsApi);

            Assert.ThrowsAsync<DistanceApiServiceException>(
                async () => await service.GetAirport("TST", ct), 
                "Cannot get airport"
            );
        }
    }
}