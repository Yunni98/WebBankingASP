﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBankingASP.Models;

namespace WebBankingASP.ViewModels
{
    public class AccountMovementListViewModel
    {
        public string Title { get; set; }
        public List<AccountMovement> listMovement { get; set; }
    }
}