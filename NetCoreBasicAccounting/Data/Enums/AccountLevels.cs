using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBasicAccounting.Data.Enums
{
    public enum AccountLevels
    {
        [Display(Name = "Nivel Uno")]
        LevelOne = 1,
        [Display(Name = "Nivel Dos")]
        LevelTwo = 2,
        [Display(Name = "Nivel Tres")]
        LevelThree = 3
    }
}
