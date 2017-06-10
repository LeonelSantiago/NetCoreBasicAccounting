using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Enums
{
    public enum AllowsTransactions
    {
        [Display(Name = "Permite Transacciones")]
        Yes = 0,
        [Display(Name = "No permite transacciones")]
        No = 1
    }
}
