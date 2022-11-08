using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCard
    {
        public CreditCardType type { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string expirationDate { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(string cardType, string cardNumber, string name, string expirationDate)
        {
            this.type = (CreditCardType)Enum.Parse(typeof(CreditCardType),cardType);
            this.number = cardNumber;
            this.name = name;
            this.expirationDate = expirationDate;
        }
    }
}
