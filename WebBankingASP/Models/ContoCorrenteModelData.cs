using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBankingASP.Models
{
    public class ContoCorrenteModelData
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage = "Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage = "Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Password { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage = "Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Full_name { get; set; }
        [Display(Name = "Iban")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(5, ErrorMessage = "Il campo puo contenere minimo 5 caratteri")]
        [MaxLength(50, ErrorMessage = "Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Iban { get; set; }

        public ContoCorrenteModelData(string username, string password, string full_name, string iban)
        {
            Username = username;
            Password = password;
            Full_name = full_name;
            Iban = iban;
        }
    }
}