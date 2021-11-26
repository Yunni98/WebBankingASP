using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBankingASP.Models
{
    public class BonificoModelData
    {
        [Display(Name = "IBAN")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(5)]
        [MaxLength(50, ErrorMessage = "Il campo puo contenere massimo 50 caratteri")]
        [Key]
        public string Iban { get; set; }

        [Display(Name = "Importo")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(0, double.MaxValue)]
        [MinLength(1)]
        [Key]
        public double? Importo { get; set; }
    }
}