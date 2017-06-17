using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class Majorization : Entity
    {
        public int AccountingEntryId { get; set; }
        public int AccountToDebit { get; set; }
        public int AccountToDebitHigherAccount { get; set; }
        public decimal AmountToDebit { get; set; }
        public int AccountToCredit { get; set; }
        public int AccountToCreditHigherAccount { get; set; }
        public decimal AmountToCredit { get; set; }
        public DateTime ProcessDate { get; set; }
        public decimal Balance { get; set; }
    }
}
