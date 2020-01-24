using OgrenciNotMvc.Models.UyeGiris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class UyeGirisController : Controller
    {
        // GET: UyeGiris
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string pass)
        {

            if(new LoginState().isLoginSucces(username,pass))
            {
                return RedirectToAction("Index", "Default");
                
            }
            return RedirectToAction("Index","UyeGiris");



        }
    }
}