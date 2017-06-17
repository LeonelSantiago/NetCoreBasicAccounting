using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingAccount : Entity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tipo de Cuenta")]
        public AccountType AccountType { get; set; }
        [Required]
        [Display(Name = "Permite Transacciones")]
        public AllowsTransactions AllowsTransactions { get; set; }
        [Required]
        [Display(Name = "Nivel")]
        public AccountLevels Level { get; set; }
        [Required]
        [Display(Name = "Cuenta Mayor")]        
        public int HigherAccount { get; set; }
        public decimal Balance { get; set; }
    }
}
