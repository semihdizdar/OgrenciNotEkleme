using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class NotHesapController : Controller
    {
        // GET: NotHesap
        [HttpPost]
        public ActionResult Index(int sayi1=0,int sayi2=0)
        {
            int sonuc = (sayi1*30)/100 + (sayi2*70)/100;
            Index(sonuc);
            return View();
        }

        [HttpGet]
        public ActionResult Index(int sonuc = 0)
        {
            ViewBag.total = sonuc;
            return View();
        }

       
    }
}