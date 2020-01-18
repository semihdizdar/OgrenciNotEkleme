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
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulüpGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);

            return View("KulüpGetir", kulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPADİ = p.KULUPADİ;
            db.SaveChanges();
            return RedirectToAction("Index","Kulüpler");
        }
    }
}