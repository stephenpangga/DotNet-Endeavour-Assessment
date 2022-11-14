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

        public void ReadJsonFile(/*file as input*/)
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

                        if (o.dateOfBirth == null || person.CheckAge((DateTime)o.dateOfBirth) == true)
                        {
                            ListOfPeople.Add(o);
                        }
                    }
                }
            }

            foreach (Person a in ListOfPeople)
            {
                //if(a.name == "Evelyn Pollich")
                //{
                //Console.WriteLine(a.dateOfBirth);
                //}
                //d.InsertUserToDb(a);
            }

            Console.WriteLine(ListOfPeople.Count());
        }
    }
}
