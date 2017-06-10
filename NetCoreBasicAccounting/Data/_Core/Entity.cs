using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data._Core
{
    public class Entity
    {
        public int ID { get; set; }
        public Status Status { get; set; }
    }
}
