using DAL;
using Domain;
using Infrastructure;

namespace practice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tcs = new TaskCompletionSource();
            var sigintReceived = false;
            Program program = new Program();

            Console.WriteLine("The Endeavour assessment is running");
            Console.WriteLine("Waiting for SIGINT/SIGTERM");
            program.Start();


            Console.CancelKeyPress += (_, ea) =>
            {
                ea.Cancel = true;

                Console.WriteLine("Received SIGINT (Ctrl+C)");

                tcs.SetResult();
                sigintReceived = true;
            };

            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            {
                if (!sigintReceived)
                {
                    Console.WriteLine("Received SIGTERM");
                    tcs.SetResult();
                }
                else
                {
                    Console.WriteLine("Received SIGTERM, ignoring it because already processed SIGINT");
                }
            };

            await tcs.Task;
            Console.WriteLine("Good bye");
        }

        void Start()
        {
            ReadFileService fileService = new ReadFileService();
            UserDAO userDAO = new UserDAO();

            List<Person> peopleList = fileService.ReadJsonFile("challenge.json");
            List<Person> checkList = userDAO.GetAllPerson();

            foreach (Person p in peopleList)
            {
                if (!checkList.Contains(p))
                {
                    userDAO.InsertUserToDb(p);
                }
            }
        }
    }
}