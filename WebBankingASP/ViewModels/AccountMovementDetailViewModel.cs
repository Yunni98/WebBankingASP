using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBankingASP.Models;

namespace WebBankingASP.ViewModels
{
    public class AccountMovementDetailViewModel
    {
        public string Title { get; set; }
        public AccountMovement Movement { get; set; }
    }
}