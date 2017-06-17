using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class MoneyCurrency : Entity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tasa")]
        public decimal LastExchangeRate { get; set; }
    }
}
