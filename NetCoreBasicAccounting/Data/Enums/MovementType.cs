using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Enums
{
    public enum MovementType
    {
        [Display(Name = "Débito")]
        Debit = 0,
        [Display(Name = "Crédito")]
        Credit = 1
    }
}
