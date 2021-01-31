using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CTeleport.AirportsService.Api.DistanceApi.Exceptions;
using CTeleport.AirportsService.Api.DistanceApi.Services;
using CTeleport.AirportsService.Api.DistanceApi.ValueObjects;
using CTeleport.AirportsService.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTeleport.AirportsService.Api.DistanceApi.Controllers
{
    /// <summary>
    /// Distance API main controller
    /// </summary>
    [ApiController]
    [Route("/distance")]
    public sealed class DistanceApiController : ControllerBase
    {
        private readonly ILogger<DistanceApiController> _logger;

        private readonly DistanceApiService _distanceApiService;

        private readonly IGeoUtils _geoUtils;

        private readonly TimeSpan _getAirportsTimeout = TimeSpan.FromSeconds(5);

        private const int _responseCacheDurationSecs = 24 * 60 * 60;

        /// <summary>
        /// Controller constructor
        /// </summary>
        public DistanceApiController(
            ILogger<DistanceApiController> logger, 
            DistanceApiService distanceApiService,
            IGeoUtils geoUtils
        )
        {
            this._logger = logger;
            this._distanceApiService = distanceApiService;
            this._geoUtils = geoUtils;
        }

        /// <summary>
        /// Returns the distance between two airports in given unit
        /// </summary>
        /// <response code="200">Returns the distance</response>
        /// <response code="400">If the request has validation errors</response>
        /// <response code="503">If service temporarily unavailable</response>
        /// <response code="500">If internal error ocurred</response>
        [HttpGet]
        [ProducesResponseType(typeof(Distance), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails),(int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ResponseCache(Duration = _responseCacheDurationSecs)]
        public async Task<IActionResult> Get([FromQuery] GetDistanceQuery query)
        {
            try
            {
                using var cts = new CancellationTokenSource(_getAirportsTimeout);

                var originAirport = await this._distanceApiService.GetAirport(query.Origin, cts.Token);
                if (originAirport.IsT1)
                {
                    ModelState.AddModelError(nameof(GetDistanceQuery.Origin), "Origin airport not found");

                    return ValidationProblem(ModelState);
                }

                var destinationAirport = await this._distanceApiService.GetAirport(query.Destination, cts.Token);
                if (destinationAirport.IsT1)
                {
                    ModelState.AddModelError(nameof(GetDistanceQuery.Destination), "Destination airport not found");

                    return ValidationProblem(ModelState);
                }

                var distance = this._geoUtils.CalculateDistance(
                    originAirport.AsT0.Location, 
                    destinationAirport.AsT0.Location, 
                    query.Unit
                );

                return Ok(
                    new Distance
                    {
                        Origin = originAirport.AsT0,
                        Destination = destinationAirport.AsT0,
                        Length = distance,
                        Unit = query.Unit,
                    }
                );
            }
            catch (Exception e) when (e is DistanceApiServiceException || e is TaskCanceledException)
            {
                this._logger.LogError(e, "Error ocurred");
                return Problem(statusCode: (int)HttpStatusCode.ServiceUnavailable);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, "Unexpected error ocurred");
                return Problem(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
