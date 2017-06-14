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
        public List<AccountingAccount> AccountToDebit { get; set; }
        public List<AccountingAccount> AccountToCredit { get; set; }
        public MovementType MovementType { get; set; }
        public DateTime AccountingSeatDate { get; set; }
        public decimal AccountingSeatAmount { get; set; }
        public MajorizationProcessed IsMajorizationProcessed { get; set; }
        public AccountingEntry()
        {
            AccountToDebit = new List<AccountingAccount>();
            AccountToCredit = new List<AccountingAccount>();
        }
    }
}
