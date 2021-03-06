﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    [UserAuthorizeController]
    public class DefaultController : Controller
    {

        DbMvcOkulEntities4 db = new DbMvcOkulEntities4();
        // GET: Default
        public ActionResult Index()
        {

            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniKayit()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(TBLDERSLER p)
        {

            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }

            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public ActionResult Sil(int id)
        {

            try
            {
                var ders = db.TBLDERSLER.Find(id);
                db.TBLDERSLER.Remove(ders);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
        
            var ders = db.TBLDERSLER.Find(id);
            return View("DersGetir", ders);
        }

        public ActionResult Guncelle(TBLDERSLER p)
        {
         
            if (!ModelState.IsValid)
            {
                return View("DersGetir");
            }

            var dersler = db.TBLDERSLER.Find(p.DERSID);
            dersler.DERSADI = p.DERSADI;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

    }
}