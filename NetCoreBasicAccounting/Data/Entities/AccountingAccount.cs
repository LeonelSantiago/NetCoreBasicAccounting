using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingAccount
    {
        public string Description { get; set; }
        public AccountType AccountType { get; set; }
        public AllowsTransactions AllowsTransactions { get; set; }
        public AccountLevels Level { get; set; }
        public int HigherAccount { get; set; }
        public decimal Balance { get; set; }
    }
}
