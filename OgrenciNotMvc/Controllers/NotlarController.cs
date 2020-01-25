using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities4 db = new DbMvcOkulEntities4();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult NotGiris(int id)
        {
            //var ogrenci = db.TBLNOTLAR.Find(id);

            //List<SelectListItem> degerler = (from i in db.TBLDERSLER.ToList()

            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.DERSADI,
            //                                     Value = i.DERSID.ToString()

            //                                 }
            //                                ).ToList();

            //ViewBag.dersadı = degerler;
            //Emrah abiyle bak !!!

            ViewBag.ogrenciid = id; 
            return View();
        }

        [HttpPost]
        public ActionResult NotGiris(TBLNOTLAR tbl)
        {

            db.TBLNOTLAR.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
   
            return View("NotGetir", notlar);
        }

        [HttpPost]
        public ActionResult NotGetir(Hesaplamaİslemleri hesapla, TBLNOTLAR p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int Proje=0) 
        {
            if(hesapla.islem == "HESAPLA")
            {
                // işlem 1
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + Proje) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if(hesapla.islem == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
                
                


            }

            return View();

        }
    }

}