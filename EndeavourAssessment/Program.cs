using Domain;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using System.Text.Json;

namespace EndeavourAssessment
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Endeavour Assessment");
            Program program = new Program();
            
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => services.AddHostedService<ShutdownService>())
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
        }
    }
}