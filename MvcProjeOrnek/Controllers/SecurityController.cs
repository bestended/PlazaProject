using MvcProjeOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProjeOrnek.Controllers
{
    public class SecurityController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {

            var users = db.KullanicilarSet.FirstOrDefault(i => i.kullaniciAdi == kullanici.kullaniciAdi && i.sifre == kullanici.sifre);
            if (users != null)
            {

                FormsAuthentication.SetAuthCookie(users.kullaniciAdi, true);
                return RedirectToAction("Index","Admin");

            }

            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya parola yanlış";
                return View();
            }



        }
        public ActionResult Logout()
        {

            return RedirectToAction("Login");
        }


    }
}