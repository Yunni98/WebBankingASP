using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankingASP.Models;
using WebBankingASP.ViewModels;

namespace WebBankingASP.Controllers
{
    public class CorrentistaController : Controller
    {
        // GET: Banchiere/conti-correnti
        [Route("Correntista/conti-correnti")]
        [HttpGet]
        public ActionResult Index(int idCorrentista)
        {
            using (WebBankingEntities1 model = new WebBankingEntities1())
            {
                List<BankAccount> contiBanchiere = model.BankAccounts.Where(w => w.fk_user == idCorrentista).ToList();
                if (contiBanchiere == null)
                {
                    return HttpNotFound();
                }
                return View(new BankAccountListViewModel
                {
                    Title = "Conti Correnti",
                    Bank_Accounts = contiBanchiere
                });
            }
        }
    }
}