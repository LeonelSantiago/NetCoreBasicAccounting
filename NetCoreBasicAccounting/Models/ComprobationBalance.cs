using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Models
{
    public class ComprobationBalance
    {
        public int ID { get; set; }
        public int AccountToCredit { get; set; }
        public string AccountToCreditDescription { get; set; }
        public int AccountToDebit { get; set; }
        public decimal AmountToDebit { get; set; }
        public string AccountToDebitDescription { get; set; }
        public decimal AmountToCredit { get; set; }
    }
}
