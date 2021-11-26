using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankingASP.Models;
using WebBankingASP.ViewModels;

namespace WebBankingASP.Controllers
{
    public class BanchiereController : Controller
    {
        // GET: Banchiere/conti-correnti
        [Route("Banchiere/conti-correnti")]
        [HttpGet]
        public ActionResult Index()
        {
            using(WebBankingEntities1 model = new WebBankingEntities1())
            {
                List<BankAccount> contiBanchiere = model.BankAccounts.ToList();
                if(contiBanchiere == null)
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

        [Route("Banchiere/conti-correnti/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (WebBankingEntities1 model = new WebBankingEntities1())
            {
                var dettaglioConto = model.BankAccounts.FirstOrDefault(f => f.id == id);
                if (dettaglioConto == null)
                {
                    return HttpNotFound();
                }
                return View(new BankAccountDetailsViewModel
                {
                    Title = "Conto Corrente",
                    Bank_Account = dettaglioConto
                });
            }
        }

        [Route("Banchiere/conti-correnti/{id}/movimenti")]
        [HttpGet]
        public ActionResult Movimenti(int id)
        {
            using(WebBankingEntities1 model = new WebBankingEntities1())
            {
                var movimentiConto = model.AccountMovements.OrderBy(o => o.date).Where(w => w.BankAccount.id == id).ToList();
                if(movimentiConto == null)
                {
                    return HttpNotFound();
                }
                return View(new AccountMovementListViewModel
                {
                    Title = "Movimenti",
                    listMovement = movimentiConto
                });
            }
        }

        [Route("Banchiere/conti-correnti/{id}/movimenti/{id}")]
        [HttpGet]
        public ActionResult Movimento(int idMovimento)
        {
            using (WebBankingEntities1 model = new WebBankingEntities1())
            {
                var movimentoConto = model.AccountMovements.FirstOrDefault(f => f.id == idMovimento);
                if (movimentoConto == null)
                {
                    return HttpNotFound();
                }
                return View(new AccountMovementDetailViewModel
                {
                    Title = "Movimento",
                    Movement = movimentoConto
                });
            }
        }

        public ActionResult Bonifico()
        {
            return View();
        }

        [Route("Banchiere/conti-correnti/{id}/bonifico")]
        [HttpPost]
        public ActionResult Bonifico(int idConto, BonificoModelData specificheBonifico)
        {
            using(WebBankingEntities1 model = new WebBankingEntities1())
            {
                double? saldo = model.AccountMovements.Where(f => f.BankAccount.id == idConto).Sum(s => (s.@in == null ? 0 : s.@in) - (s.@out == null ? 0 : s.@out));
                if(specificheBonifico == null || specificheBonifico.Importo < 0 || saldo < specificheBonifico.Importo)
                {
                    return HttpNotFound();
                }
                else
                {
                    if(model.BankAccounts.Where(w => w.iban == specificheBonifico.Iban).Count() > 0)
                    {
                        model.AccountMovements.Add(new AccountMovement { fk_bankAccount = idConto, date = DateTime.Now, description = "Bonifico inviato", @out = specificheBonifico.Importo });
                        model.AccountMovements.Add(new AccountMovement { fk_bankAccount = model.BankAccounts.FirstOrDefault(w => w.iban == specificheBonifico.Iban).id, date = DateTime.Now, description = "Bonifico ricevuto", @in = specificheBonifico.Importo });
                        model.SaveChanges();
                        return RedirectToAction("Movimenti", "Banchiere");
                    }
                    else
                    {
                        model.AccountMovements.Add(new AccountMovement { fk_bankAccount = idConto, date = DateTime.Now, description = "Bonifico inviato", @out = specificheBonifico.Importo });
                        model.SaveChanges();
                        return RedirectToAction("Movimenti", "Banchiere");
                    }
                }
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [Route("Banchiere/conti-correnti")]
        [HttpPost]
        public ActionResult Create(ContoCorrenteModelData conto)
        {
            using(WebBankingEntities1 model = new WebBankingEntities1())
            {
                if(model.BankAccounts.Where(w => w.iban == conto.Iban).Count() == 0)
                {
                    model.Users.Add(new User { username = conto.Username, password = conto.Password, full_name = conto.Full_name, is_banker = false, last_login = null, last_logout = null });
                    model.SaveChanges();
                    model.BankAccounts.Add(new BankAccount { iban = conto.Iban, fk_user = model.Users.FirstOrDefault(w => w.username == conto.Username && w.password == conto.Password).id });
                    model.SaveChanges();
                    return RedirectToAction("Index", "Banchiere");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [Route("Banchiere/conti-correnti/{id}")]
        [HttpPut]
        public ActionResult Update(int idConto, BankAccount bankAccount)
        {
            using (WebBankingEntities1 model = new WebBankingEntities1())
            {
                if (model.BankAccounts.Where(w => w.id == idConto).Count() > 0)
                {
                    if(model.BankAccounts.Where(w => w.iban == bankAccount.iban).Count() < 1)
                    {
                        var contoEdit = model.BankAccounts.FirstOrDefault(f => f.id == idConto);
                        contoEdit.iban = bankAccount.iban;
                        model.SaveChanges();
                        return RedirectToAction("Index", "Banchiere");
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [Route("Banchiere/conti-correnti/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (WebBankingEntities1 model = new WebBankingEntities1())
            {
                if (model.BankAccounts.Where(w => w.id == id).Count() > 0)
                {
                        var contoDelete = model.BankAccounts.FirstOrDefault(f => f.id == id);
                        model.AccountMovements.RemoveRange(model.AccountMovements.Where(w => w.BankAccount.id == contoDelete.id));
                        model.BankAccounts.Remove(contoDelete);
                        model.SaveChanges();
                        return RedirectToAction("Index", "Banchiere");
                }
                else
                {
                        return HttpNotFound();
                }
            }
        }
    }
}