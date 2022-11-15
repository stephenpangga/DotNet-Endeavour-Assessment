using Domain;
using DAL;
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
        //file reader
        ReadFileService fileService = new ReadFileService();
        UserDAO userDAO = new UserDAO();


        public ShutdownService(IHostApplicationLifetime applicationLifetime)
        {
            this.applicationLifetime = applicationLifetime;
        }

        //here put ur code

        public Task StartAsync(CancellationToken _)
        {
            Console.WriteLine("Starting service");

            //here open filereader and call the code
            List<Person> peopleList = fileService.ReadJsonFile("challenge.json");
            List<Person> checkList = userDAO.GetAllPerson();

            BackgroundTask = Task.Run(async () =>
            {
                //here close the filereader and do other stuff that needs to happen before shutdown

                Console.WriteLine("adding the user list to Database");

                while (!pleaseStop)
                {
                    foreach (Person p in peopleList)
                    {
                        userDAO.InsertUserToDb(p);
                    }
                    await Task.Delay(50);
                }
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
