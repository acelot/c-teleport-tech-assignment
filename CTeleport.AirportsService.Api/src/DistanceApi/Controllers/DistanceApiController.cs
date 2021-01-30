using System;
using System.Net;
using System.Threading.Tasks;
using CTeleport.AirportsService.Api.DistanceApi.Services;
using CTeleport.AirportsService.Api.DistanceApi.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTeleport.AirportsService.Api.DistanceApi.Controllers
{
    [ApiController]
    [Route("/distance")]
    public sealed class DistanceApiController : ControllerBase
    {
        private readonly ILogger<DistanceApiController> _logger;

        private readonly DistanceApiService _distanceApiService;

        private const int _responseCacheDurationSecs = 24 * 60 * 60;

        public DistanceApiController(ILogger<DistanceApiController> logger, DistanceApiService distanceApiService)
        {
            this._logger = logger;
            this._distanceApiService = distanceApiService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Distance), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ResponseCache(Duration = _responseCacheDurationSecs)]
        public async Task<IActionResult> Get([FromQuery] GetDistanceQuery query)
        {
            var originAirport = await this._distanceApiService.GetAirport(query.Origin);
            if (originAirport is null)
            {
                ModelState.AddModelError(nameof(GetDistanceQuery.Origin), "Origin airport not found");

                return ValidationProblem(ModelState);
            }

            var destinationAirport = await this._distanceApiService.GetAirport(query.Destination);
            if (destinationAirport is null)
            {
                ModelState.AddModelError(nameof(GetDistanceQuery.Destination), "Destination airport not found");

                return ValidationProblem(ModelState);
            }

            var distance = this._distanceApiService.CalculateDistance(originAirport.Location, destinationAirport.Location, query.Unit);

            return Ok(
                new Distance
                {
                    Origin = originAirport,
                    Destination = destinationAirport,
                    Length = distance,
                    Unit = query.Unit,
                }
            );
        }
    }
}
