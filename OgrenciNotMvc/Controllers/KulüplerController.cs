using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KulüplerController : Controller
    {
        // GET: Kulüpler
        DbMvcOkulEntities4 db = new DbMvcOkulEntities4();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulüp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulüp(TBLKULUPLER p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKulüp");
            }

            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            try
            {
                var kulup = db.TBLKULUPLER.Find(id);
                db.TBLKULUPLER.Remove(kulup);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(string.Format("SEMİH!!! {0}{1}", ex.Message, ex.InnerException));
            }
            return RedirectToAction("Index");
        }

        public ActionResult KulüpGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);

            return View("KulüpGetir", kulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View("Index");
            //}   

            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPADİ = p.KULUPADİ;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulüpler");
        }
    }
}