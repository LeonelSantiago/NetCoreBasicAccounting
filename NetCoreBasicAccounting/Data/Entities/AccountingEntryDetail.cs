using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingEntryDetail
    {
        public int ID { get; set; }
        public AccountingEntry AccountingEntry { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int MovementType { get; set; }
        public decimal AmountToCredit { get; set; }
        public decimal AmountToDebit { get; set; }
    }
}
