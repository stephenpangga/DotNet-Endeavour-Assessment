using System;
using System.Globalization;

namespace Domain
{
    public class Person
    {
        public string name { get; set; }
        public string address { get; set; }
        public bool check { get; set; }
        public string description { get; set; }
        public string? interest { get; set; }

        /// <summary>
        /// The json serialize.deserialize for datetime in the format of dd/mm/yyyy is not converting correctly, 
        /// there i did it manually by collecting it as a string and then converting to datetime.
        /// there is probably a better way to do it but i decided to focus on other part of the assignment 
        /// because i quite couldnt find the problem in the background of the process..
        /// </summary>
        public string? date_of_birth 
        { 
            get { return this.dateOfBirth.ToString(); }
            set { if (value != null)
                {
                    this.dateOfBirth = DateTime.Parse(value);
                }
                else
                {
                    this.dateOfBirth = null;
                }
            } 
        }
        public DateTime? dateOfBirth { get; set; } //this.date_of_birth = value; } }
        public string email { get; set; }
        public string account { get; set; }
        public CreditCard credit_card { get; set; }

        public Person()
        {

        }

        /*public Person(string name, string address, bool check, string description, string? interest,string dateOfBirth, string email, string account, CreditCard creditCard)
        {

            var cultureInfo = new CultureInfo("en-US");
            string format = "yyyy/MM/dd";
            this.name = name;
            this.address = address;
            this.check = check;
            this.description = description;
            this.interest = interest;
            //this.date_of_birth = DateTime.ParseExact(dateOfBirth, format, cultureInfo, DateTimeStyles.None);
            this.date_of_birth = DateTime.Today;
            this.email = email;
            this.account = account;
            this.credit_card = creditCard;
        }*/



        public bool CheckAge(DateTime birthDate)
        {
            DateTime dateToday = DateTime.Today;

            int age = Convert.ToInt32(dateToday.Year - birthDate.Year);

            if (dateToday < birthDate.AddYears(age))
                age--;

            if (age > 18 && age < 65)
            {
                return true;
            }
            return false;
        }
    }
}