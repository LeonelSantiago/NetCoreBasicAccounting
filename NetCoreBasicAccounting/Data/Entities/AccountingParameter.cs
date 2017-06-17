using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingParameter
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Año")]
        public int ProcessYear { get; set; }
        [Required]
        [Display(Name = "Mes")]
        public int Month { get; set; }
        [Required]
        [Display(Name = "Mayorizáción Procesada")]
        public MajorizationProcessed MajorizationProcessed { get; set; }
        [Required]
        [Display(Name = "RNC")]
        public string Rnc { get; set; }
        [Required]
        [Display(Name = "Mes Cierre Fiscal")]
        public int MonthFiscalClose { get; set; }
    }
}
