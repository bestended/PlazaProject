using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOrnek.Models;

namespace MvcProjeOrnek.Controllers
{
    public class DepartmanlarController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Plazalar
        [HttpGet]
        public ActionResult Listele()
        {
            var result = db.departmanlarSet.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(departmanlar departman)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {

                    con.departmanlarSet.Add(departman);
                    con.SaveChanges();
                    return RedirectToAction("Listele");


                }



            }
            catch
            {

                return View();
            }



        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = db.departmanlarSet.Where(i => i.departmanNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, departmanlar departman)
        {

            try
            {
                db.Entry(departman).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listele");

            }
            catch
            {

                return View();
            }




        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = db.departmanlarSet.Where(i => i.departmanNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, departmanlar departman)
        {
            departman = db.departmanlarSet.Where(i => i.departmanNo == id).FirstOrDefault();
            db.departmanlarSet.Remove(departman);
            db.SaveChanges();
            return RedirectToAction("Listele");

        }
    }
}