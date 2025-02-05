using CTeleport.AirportsService.Api.DistanceApi.Extensions;
using CTeleport.AirportsService.Api.Utils;
using CTeleport.PlacesService.ApiClient.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CTeleport.AirportsService.Api
{
    /// <summary>
    /// App startup
    /// </summary>
    public sealed class Startup
    {
        private const string RedisDsnEnv = "REDIS_DSN";
        private const string PlacesApiClientBaseUrlEnv = "PLACES_API_CLIENT_BASE_URL";

        /// <summary>
        /// App startup constructor
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures sevices
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            var redisDsn = System.Environment.GetEnvironmentVariable(RedisDsnEnv);
            if (redisDsn is string)
            {
                services.AddStackExchangeRedisCache(c =>
                {
                    c.Configuration = redisDsn;
                });
            }
            else
            {
                services.AddMemoryCache();
            }

            services.AddResponseCaching();

            var placesApiClientBaseUrl = System.Environment.GetEnvironmentVariable(PlacesApiClientBaseUrlEnv);
            if (placesApiClientBaseUrl is null)
            {
                throw new System.ArgumentException($"{PlacesApiClientBaseUrlEnv} environment variable not set!");
            }

            services.AddSingleton<IGeoUtils, GeoUtils>();
            services.AddPlacesServiceApiClient(new System.Uri(placesApiClientBaseUrl));
            services.AddDistanceApi();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CTeleport.AirportsService.Api", Version = "v1" });

                var xmlDocPath = System.IO.Path.Combine(
                    System.AppContext.BaseDirectory, 
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? ""
                );
                c.IncludeXmlComments(xmlDocPath + ".xml");
            });
        }

        /// <summary>
        /// Configures app
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCaching();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "C-Teleport Airports Service API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
