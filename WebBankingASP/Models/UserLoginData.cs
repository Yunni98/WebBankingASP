using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBankingASP.Models
{
    public class UserLoginData
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Campo obbligatorio")]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage ="Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage = "Il campo puo contenere massimo 255 caratteri")]
        [Key]
        public string Password { get; set; }
    }
}