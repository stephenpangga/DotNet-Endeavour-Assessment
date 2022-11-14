using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ShutdownService : IHostedService
    {
        private bool pleaseStop;
        private Task BackgroundTask;
        private readonly IHostApplicationLifetime applicationLifetime;
        //file reader should be declared here

        public ShutdownService(IHostApplicationLifetime applicationLifetime)
        {
            this.applicationLifetime = applicationLifetime;
        }

        //here put ur code

        public Task StartAsync(CancellationToken _)
        {
            Console.WriteLine("Starting service");

            //here open filereader and call the code
            ReadFileService fileService = new ReadFileService();
            fileService.ReadJsonFile();

            BackgroundTask = Task.Run(async () =>
            {
                while (!pleaseStop)
                {
                    await Task.Delay(50);
                }
                //here close the filereader and do other stuff that needs to happen before shutdown
                Console.WriteLine("Background task gracefully stopped");
            });

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping service");

            pleaseStop = true;
            await BackgroundTask;

            Console.WriteLine("Service stopped");
        }
    }
}
