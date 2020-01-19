using System;
using System.Collections.Generic;
using System.IO;
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
                                                 Value = i.KULUPID.ToString()

                                             }
                                             ).ToList();

            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TBLOGRENCİLER p, HttpPostedFileBase file, FormCollection form)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View("OgrenciEkle");
            //}



            string photoPath = "unknown";
            //file upload
            if (file != null && file.ContentLength > 0)
            {   
                var path = Path.Combine(Server.MapPath("~/App_Data/student-images/"), Guid.NewGuid().ToString() + "_" + file.FileName);
                photoPath = Guid.NewGuid().ToString() + "_" + file.FileName;
                file.SaveAs(path);
                TempData["result"] = "Yükleme Başarılı.";
            }
            
            //var klp = db.TBLKULUPLER.Where(m => m.KULUPADİ == p.TBLKULUPLER.KULUPADİ).FirstOrDefault();
            //p.TBLKULUPLER.KULUPADİ = klp.KULUPADİ;
            p.OGRFOTOGRAF = photoPath;
            string secilenKulup = form["secilenKulup"];

            var klp = db.TBLKULUPLER.Where(m => m.KULUPADİ == secilenKulup).FirstOrDefault();
            p.OGRKULUP = klp.KULUPID;

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
                                                 Value = i.KULUPID.ToString()

                                             }
                                            ).ToList();

            ViewBag.dgr = degerler;


            return View("OgrenciGetir", ogrenci);
        }

        [HttpPost]
        public ActionResult Guncelle(TBLOGRENCİLER p)
        {

            //var klp = db.TBLKULUPLER.Where(m => m.KULUPADİ == p.TBLKULUPLER.KULUPADİ).FirstOrDefault();
            //p.TBLKULUPLER.KULUPADİ = klp.KULUPADİ;
            //p.OGRKULUP = klp.KULUPID;

            var ogrenci = db.TBLOGRENCİLER.Find(p.OGRENCIID);
            //ogrenci.OGRKULUP = p.OGRKULUP;
            ogrenci.OGRAD = p.OGRAD;
            ogrenci.OGRCİNSİYET = p.OGRCİNSİYET;
            ogrenci.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogrenci.OGRSOYAD = p.OGRSOYAD;
            ogrenci.OGRKULUP = p.TBLKULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "OgrenciListesi");
        }

    }
}