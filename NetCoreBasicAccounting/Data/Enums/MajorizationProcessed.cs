using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Enums
{
    public enum MajorizationProcessed
    {
        [Display(Name = "Está procesada")]
        IsProcessed = 0,
        [Display(Name = "No está procesada")]
        NotProcessed = 1
    }
}
