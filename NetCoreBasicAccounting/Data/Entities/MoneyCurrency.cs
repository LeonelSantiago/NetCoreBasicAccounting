using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class MoneyCurrency
    {
        public string Description { get; set; }
        public decimal LastExchangeRate { get; set; }
    }
}
