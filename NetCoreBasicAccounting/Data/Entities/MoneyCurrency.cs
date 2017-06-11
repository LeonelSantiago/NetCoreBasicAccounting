using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class MoneyCurrency : Entity
    {
        public string Description { get; set; }
        public decimal LastExchangeRate { get; set; }
    }
}
