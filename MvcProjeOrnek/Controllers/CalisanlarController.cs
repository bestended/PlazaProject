using MvcProjeOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOrnek.Models;

namespace MvcProjeOrnek.Controllers
{
    public class CalisanlarController : Controller
    {
        Model1Container db = new Model1Container();

        [HttpGet]
        public ActionResult Listele()
        {
            var result = db.calisanlarSet.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(calisanlar calisan)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {

                    con.calisanlarSet.Add(calisan);
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
            var result = db.calisanlarSet.Where(i => i.calisanNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, calisanlar calisan)
        {

            try
            {
                db.Entry(calisan).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.calisanlarSet.Where(i => i.calisanNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, calisanlar calisan)
        {
            calisan = db.calisanlarSet.Where(i => i.calisanNo == id).FirstOrDefault();
            db.calisanlarSet.Remove(calisan);
            db.SaveChanges();
            return RedirectToAction("Listele");

        }



    }
}