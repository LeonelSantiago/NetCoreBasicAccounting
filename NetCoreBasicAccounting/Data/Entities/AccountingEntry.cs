using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetCoreBasicAccounting.Data.Enums;
using NetCoreBasicAccounting.Data._Core;

namespace NetCoreBasicAccounting.Data.Entities
{
    public class AccountingEntry : Entity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Auxiliar")]
        public int AuxiliarOrigin { get; set; }
        [Required]
        [Display(Name = "Cuenta Debitar")]
        public int AccountToDebit { get; set; }
        [Required]
        [Display(Name = "Descrión Cuenta Debitar")]
        public string AccountToDebitDescription { get; set; }
        [Required]
        [Display(Name = "Cuenta Creditar")]
        public int AccountToCredit { get; set; }
        [Required]
        [Display(Name = "Descripción Cuenta Creditar")]
        public string AccountToCreditDescription { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime AccountingSeatDate { get; set; }
        [Required]
        [Display(Name = "Monto a Créeditar")]
        public decimal AmountToCredit { get; set; }
        [Required]
        [Display(Name = "Monto de Debitar")]
        public decimal AmountToDebit { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public MajorizationProcessed IsMajorizationProcessed { get; set; }
        [Required]
        [Display(Name = "Moneda")]
        public int MoneyCurrency { get; set; }
        [Required]
        [Display(Name = "Tasa")]
        public decimal MoneyCurrencyRate { get; set; }
    }
}
