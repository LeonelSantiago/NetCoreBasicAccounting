using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingParameter
    {
        public int ID { get; set; }
        public int ProcessYear { get; set; }
        public int Month { get; set; }
        public MajorizationProcessed MajorizationProcessed { get; set; }
        public string Rnc { get; set; }
        public int MonthFiscalClose { get; set; }
    }
}
