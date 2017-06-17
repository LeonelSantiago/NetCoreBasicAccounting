using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountType : Entity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Origen")]
        public MovementType Origin { get; set; }
    }
}
