using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingEntry : Entity
    {
        public string Description { get; set; }
        public int AuxiliarOrigin { get; set; }
        public int AccountToDebit { get; set; }
        public string AccountToDebitDescription { get; set; }
        public int AccountToCredit { get; set; }
        public string AccountToCreditDescription { get; set; }
        public DateTime AccountingSeatDate { get; set; }
        public decimal AmountToCredit { get; set; }
        public decimal AmountToDebit { get; set; }
        public MajorizationProcessed IsMajorizationProcessed { get; set; }
        public int MoneyCurrency { get; set; }
        public decimal MoneyCurrencyRate { get; set; }
    }
}
