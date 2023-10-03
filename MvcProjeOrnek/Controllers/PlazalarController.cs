using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOrnek.Models;


namespace MvcProjeOrnek.Controllers
{
    public class PlazalarController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Plazalar
        [HttpGet]
        public ActionResult Listele()
        {
            var result=db.plazalarSet.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(plazalar plaza)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {

                    con.plazalarSet.Add(plaza);
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
            var result = db.plazalarSet.Where(i => i.plazaNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, plazalar plaza)
        {

            try
            {
                db.Entry(plaza).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.plazalarSet.Where(i => i.plazaNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, plazalar plaza)
        {
            plaza = db.plazalarSet.Where(i => i.plazaNo == id).FirstOrDefault();
            db.plazalarSet.Remove(plaza);
            db.SaveChanges();
            return RedirectToAction("Listele");

        }






    }
}