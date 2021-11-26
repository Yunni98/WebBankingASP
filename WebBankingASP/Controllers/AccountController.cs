using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBankingASP.Models;

namespace WebBankingASP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        public ActionResult Login(UserLoginData userLogin)
        {
            using(WebBankingEntities1 model = new WebBankingEntities1())
            {
                User credenzialiAccesso = model.Users.FirstOrDefault(fod => fod.username == userLogin.Username && fod.password == userLogin.Password);
                if(credenzialiAccesso == null)
                {
                    return HttpNotFound();
                }
                if(credenzialiAccesso.is_banker == true)
                {
                    //FormsAuthentication.SetAuthCookie(credenzialiAccesso.id.ToString(), false);
                    credenzialiAccesso.last_login = DateTime.Now;
                    model.SaveChanges();
                    return RedirectToAction("Index", "Banchiere");
                }
                else
                {
                    //FormsAuthentication.SetAuthCookie(credenzialiAccesso.id.ToString(), false);
                    credenzialiAccesso.last_login = DateTime.Now;
                    model.SaveChanges();
                    return RedirectToAction("conti-correnti", "Correntista", new { idCprremtista = credenzialiAccesso.id });
                }
            }
        }

        /*[HttpPost]
        public ActionResult Logout()
        {
            var u = HttpContext.User.Identity.Name;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }*/
    }
}