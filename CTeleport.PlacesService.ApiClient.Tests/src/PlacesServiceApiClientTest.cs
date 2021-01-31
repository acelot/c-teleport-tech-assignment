using CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions;
using CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects;
using CTeleport.PlacesService.ApiClient.HttpClientAbstractions;
using NSubstitute;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CTeleport.PlacesService.ApiClient.Tests
{
    [TestFixture]
    public class PlacesServiceApiClientTest
    {
        [Test]
        public async Task TestGetAirport_ExistingIataCodePassed_ReturnsAirport()
        {
            var expected = new Airport
            {
                Name = "Test Airport",
                IataCode = "TST",
                Location = new Location
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

            var ct = CancellationToken.None;

            var httpClient = Substitute.For<IHttpClient>();

            httpClient
                .GetFromJsonAsync<Airport?>("airports/TST", ct)
                .Returns<Airport?>(expected);

            var client = new PlacesServiceApiClient(httpClient);
            var actualResult = await client.GetAirport("TST", ct);

            Assert.IsTrue(actualResult.IsT0);
            Assert.AreEqual(expected, actualResult.AsT0);
        }

        [Test]
        public async Task TestGetAirport_HttpClientReturning404_ReturnsAirportNotFound()
        {
            var expected = new AirportNotFound
            {
                IataCode = "TST",
            };

            var ct = CancellationToken.None;

            var httpClient = Substitute.For<IHttpClient>();

            httpClient
                .GetFromJsonAsync<Airport?>("airports/TST", ct)
                .Returns(Task.FromException<Airport?>(new HttpRequestException(null, null, HttpStatusCode.NotFound)));

            var client = new PlacesServiceApiClient(httpClient);

            var actualResult = await client.GetAirport("TST", ct);

            Assert.IsTrue(actualResult.IsT1);
            Assert.AreEqual(expected, actualResult.AsT1);
        }

        [Test]
        public void TestGetAirport_HttpClientReturning500_ThrowsGetAirportException()
        {
            var ct = CancellationToken.None;

            var httpClient = Substitute.For<IHttpClient>();

            httpClient
                .GetFromJsonAsync<Airport?>("airports/TST", ct)
                .Returns(Task.FromException<Airport?>(new HttpRequestException(null, null, HttpStatusCode.InternalServerError)));

            var client = new PlacesServiceApiClient(httpClient);

            Assert.ThrowsAsync<GetAirportException>(
                async () => await client.GetAirport("TST", ct), 
                "Cannot get airport"
            );
        }
    }
}