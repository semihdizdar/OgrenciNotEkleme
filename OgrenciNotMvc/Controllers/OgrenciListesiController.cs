using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class OgrenciListesiController : Controller
    {
        // GET: OgrenciListesi
        
        DbMvcOkulEntities4 db = new DbMvcOkulEntities4();
        
        public ActionResult Index()
        {
            var ogrenci = db.TBLOGRENCİLER.ToList();
            
            return View(ogrenci);
        }



        [HttpGet]
        public ActionResult OgrenciEkle()
        {


            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPADİ,
                                                 Value = i.KULUPADİ.ToString()

                                             }
                                             ).ToList();

            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TBLOGRENCİLER p)
        {


            var klp = db.TBLKULUPLER.Where(m => m.KULUPADİ == p.TBLKULUPLER.KULUPADİ).FirstOrDefault();
            p.TBLKULUPLER.KULUPADİ = klp.KULUPADİ;
            db.TBLOGRENCİLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            var ogrenci = db.TBLOGRENCİLER.Find(id);
            db.TBLOGRENCİLER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCİLER.Find(id);


            //Ogrenci güncelleme ekranındaki dropdownlist e veri aktarımı için kullanılır...
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPADİ,
                                                 Value = i.KULUPADİ.ToString()

                                             }
                                            ).ToList();

            ViewBag.dgr = degerler;


            return View("OgrenciGetir", ogrenci);
        }

        [HttpPost]
        public ActionResult Guncelle(TBLOGRENCİLER p)
        {

            var klp = db.TBLKULUPLER.Where(m => m.KULUPADİ == p.TBLKULUPLER.KULUPADİ).FirstOrDefault();
            p.TBLKULUPLER.KULUPADİ = klp.KULUPADİ;
            
            var ogrenci = db.TBLOGRENCİLER.Find(p.OGRENCIID);
            //ogrenci.OGRKULUP = p.OGRKULUP;
            ogrenci.OGRAD = p.OGRAD;
            ogrenci.OGRCİNSİYET = p.OGRCİNSİYET;
            ogrenci.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogrenci.OGRSOYAD = p.OGRSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index", "OgrenciListesi");
        }

    }
}