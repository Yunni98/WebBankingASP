using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBankingASP.Models;

namespace WebBankingASP.ViewModels
{
    public class BankAccountDetailsViewModel
    {
        public string Title { get; set; }
        public BankAccount Bank_Account { get; set; }
    }
}