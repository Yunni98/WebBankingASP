using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBankingASP.Models;

namespace WebBankingASP.ViewModels
{
    public class BankAccountListViewModel
    {
        public string Title { get; set; }
        public List<BankAccount> Bank_Accounts { get; set; }
    }
}