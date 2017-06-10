using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class Majorization
    {
        public AccountingAccount HigherAccountIdentification { get; set; }
        public MovementType TipoMovimiento { get; set; }
        public DateTime ProcessDate { get; set; }
        public decimal Balance { get; set; }
    }
}
