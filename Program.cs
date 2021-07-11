using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AspBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .Enrich.FromLogContext()
                            .WriteTo.Console().CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>()
                                 .UseSerilog();
                   })
                   .ConfigureServices(services =>
                   {
                       // If one of the services here is commented out, it will work when
                       // ASPNETCORE_ENVIRONMENT = Development

                       services.AddHostedService<Service1>()
                               .AddHostedService<Service2>()
                               .AddHostedService<Service3>();
                   });
    }
}
