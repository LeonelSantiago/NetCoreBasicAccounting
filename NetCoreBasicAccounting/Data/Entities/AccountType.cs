using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountType
    {
        public string Description { get; set; }
        public MovementType Origin { get; set; }
    }
}
