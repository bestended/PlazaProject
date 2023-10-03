using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOrnek.Models;
namespace MvcProjeOrnek.Controllers
{
    public class FirmalarController : Controller
    {
        Model1Container db = new Model1Container();
        // GET: Plazalar
        [HttpGet]
        public ActionResult Listele()
        {
            var result = db.firmalarSet.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(firmalar firma)
        {
            try
            {
                using (Model1Container con = new Model1Container())
                {

                    con.firmalarSet.Add(firma);
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
            var result = db.firmalarSet.Where(i => i.firmaNo == id).FirstOrDefault();
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(int id, firmalar firma)
        {

            try
            {
                db.Entry(firma).State = System.Data.Entity.EntityState.Modified;
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
            var result=db.firmalarSet.Where(i => i.firmaNo == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, firmalar firma)
        {
            firma = db.firmalarSet.Where(i => i.firmaNo == id).FirstOrDefault();
            db.firmalarSet.Remove(firma);
            db.SaveChanges();
            return RedirectToAction("Listele");

        }

      
    }
}