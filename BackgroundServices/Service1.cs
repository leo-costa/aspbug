using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AspBug
{
    class Service1 : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.Information($"Hosted Service {nameof(Service1)} started");
            return Task.CompletedTask;
        }
    }
}