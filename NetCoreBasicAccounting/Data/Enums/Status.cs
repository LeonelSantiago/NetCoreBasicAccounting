using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Enums
{
    public enum Status
    {
        [Display(Name = "Habilitada")]
        Enable = 0,
        [Display(Name = "Deshabilitada")]
        Disabled = 1
    }
}
