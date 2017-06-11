using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Models
{
    public class ComprobationBalance
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public string Description { get; set; }
        public string AccountAmount { get; set; }
        public string MovementTypeDescription { get; set; }
    }
}
