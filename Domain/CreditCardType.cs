using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum CreditCardType
    {
        Visa=0,
        MasterCard=1,

        [Description("American Express")]
        [EnumMember(Value = "American Express")]
        AmericanExpress =2,

        [Description("Discover Card")]
        [EnumMember(Value = "Discover Card")]
        DiscoverCard = 3
    }
}
