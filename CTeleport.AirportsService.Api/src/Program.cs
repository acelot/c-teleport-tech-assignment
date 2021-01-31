using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CTeleport.AirportsService.Api
{
    /// <summary>
    /// Main program
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// App entry point
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Host builder
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
