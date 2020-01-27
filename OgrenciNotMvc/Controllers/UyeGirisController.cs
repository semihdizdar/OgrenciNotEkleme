//using OgrenciNotMvc.Models.UyeGiris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class UyeGirisController : Controller
    {
        private OgrenciNotMvc.Models.EntityFramework.DbMvcOkulEntities4 db = new OgrenciNotMvc.Models.EntityFramework.DbMvcOkulEntities4();
        // GET: UyeGiris
        public ActionResult Index()
        {
           
              
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string username, string pass)
        {

            TBLKULLANICI resultUser = db.TBLKULLANICI.Where(x => x.KullaniciAdi.Equals(username) && x.Sifre.Equals(pass)).FirstOrDefault();

            if (resultUser != null)
            {
                Session.Add("KullaniciAdi", resultUser.KullaniciAdi);
                Session.Add("Yetki", resultUser.Yetki);
                return RedirectToAction("Index", "Default");

            }

            return RedirectToAction("Index", "UyeGiris");
        }

        public ActionResult Cıkıs()
        {
            
            Session.Remove("KullaniciAdi");
            Session.Remove("Yetki");
            return View();
        }
        
    }
}