using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReadFileService
    {
        Person person = new Person();

        public List<Person> ReadJsonFile(string filename)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            List<Person> ListOfPeople = new List<Person>();

            using (FileStream s = File.Open(filename, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Person p = serializer.Deserialize<Person>(reader);

                        if (p.dateOfBirth == null || person.CheckAge((DateTime)p.dateOfBirth) == true)
                        {
                            ListOfPeople.Add(p);
                        }
                    }
                }
            }

            Console.WriteLine("There are {0} amount of users", ListOfPeople.Count() );

            return ListOfPeople;
        }
    }
}
