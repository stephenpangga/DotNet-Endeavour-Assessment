using Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : Database
    {

        public List<Person> GetAllPerson()
        {
            string query = "SELECT * FROM user";
            MySqlParameter[] parameters = new MySqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, parameters));
        }

        public void InsertUserToDb(Person person)
        {
            InsertCreditCardToDb(person.credit_card);
            int i = 0;
            string query = "INSERT INTO user VALUES(@id, @name, @address, @checked, @description, @interest, @date_of_birth, @email, @account, @creditcard)";
            MySqlParameter[] parameters = (new[]
            {
                new MySqlParameter("@id", i++),
                new MySqlParameter("@name",person.name),
                new MySqlParameter("@address",person.address),
                new MySqlParameter("@checked",person.check),
                new MySqlParameter("@description",person.description),
                new MySqlParameter("@interest",person.interest),
                new MySqlParameter("@date_of_birth",person.dateOfBirth),
                new MySqlParameter("@email",person.email),
                new MySqlParameter("@account",person.account),
                new MySqlParameter("@creditcard",person.credit_card.number)
            });
            //execute the command
            ExecuteEditQuery(query, parameters);
        }

        public int InsertCreditCardToDb(CreditCard credit)
        {
            int i = 0;
            string query = "INSERT INTO creditcard VALUES(@id, @type, @number, @name, @expirationDate)";
            MySqlParameter[] parameters = (new[]
            {
                new MySqlParameter("@id", i++),
                new MySqlParameter("@type",credit.type.ToString()),
                new MySqlParameter("@number",credit.number),
                new MySqlParameter("@name",credit.name),
                new MySqlParameter("@expirationDate",credit.expirationDate)
            });
            return InsertCreditCard(query, parameters);
        }
        

        //special method for getting the table rows from the database table
        //for getall method, if needed.
        private List<Person> ReadTables(DataTable dataTable)
        {
            List<Person> peoplelist = new List<Person>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Person person = new Person();
                person.name = (string)dr["name"];
                person.address = (string)dr["address"];
                //person.check = bool.Parse((string)dr["checked"]);
                person.description = (string)dr["description"];
                //person.interest = (bool)dr["interest"] ? person.interest : null;
                //person.dateOfBirth = (DateTime?)dr["date_of_birth"];
                person.email = (string)dr["email"];
                person.account = (string)dr["account"];
                //person.credit_card = ()dr("creditcard");
                peoplelist.Add(person);
            }
            return peoplelist;
        }
    }
}
