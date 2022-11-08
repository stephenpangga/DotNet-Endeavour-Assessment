using Domain;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using System.Text.Json;

namespace EndeavourAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //program.readFile();
            program.jsonReader();
            //program.readerFiles();
            /*
            Person p = new Person(
                "Prof. Simeon Green",
                "328 Bergstrom Heights Suite 709 49592 Lake Allenville",
                false,
                "Voluptatibus nihil dolor quaerat.",
                null,
                new DateTime(),
                "nerdman@cormier.net",
                "556436171909",
                new Domain.CreditCard(Domain.CreditCardType.Visa, "4532383564703", "Brooks Hudson","12/19")
            );
            */
        }

        void readFile()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("challenge.json"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {

                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


        void readerFiles()
        {

            Person p = new Person();
            try
            {
                StreamReader reader = new StreamReader("simeon.json");
                string line = reader.ReadLine();

                string[] fields = line.Split(',');

                for (int i = 0; i < line.Length; i++)
                {
                    Console.Write(i);
                }


            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }



        void jsonReader()
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            List<Person> ListOfPeople = new List<Person>();

            using (FileStream s = File.Open("challenge.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Person o = serializer.Deserialize<Person>(reader);
                        ListOfPeople.Add(o);
                    }
                }
            }

            //Console.WriteLine(o);

           foreach(var a in ListOfPeople)
            {
                if(a.name == "Evelyn Pollich")
                {
                    Console.WriteLine(a.dateOfBirth.ToString());
                }
                
            }
        }
    }
}