using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace OgrenciNotMvc.Controllers
{
    [UserAuthorizeController]
    public class StudensController : Controller
    {
        // GET: Studens
        public ActionResult Index(StudentModel model)
        {
   

            int pageIndex = model.Page ?? 1;
            DbMvcOkulEntities4 db = new DbMvcOkulEntities4();
            model.Students = (from ogrenci in db.TBLOGRENCİLER.Where(f =>
                (String.IsNullOrEmpty(model.OGRAD) || f.OGRAD.Contains(model.OGRAD)) &&
                (String.IsNullOrEmpty(model.OGRSOYAD) || f.OGRSOYAD.Contains(model.OGRSOYAD))
                ).OrderBy(f => f.OGRAD)
                           select new StudentList
                           {
                               OGRAD = ogrenci.OGRAD,
                               OGRSOYAD = ogrenci.OGRSOYAD,
                               OGRCİNSİYET = ogrenci.OGRCİNSİYET,
                               OGRTAMAD = ogrenci.OGRTAMAD,
                               OGRENCIID = ogrenci.OGRENCIID,
                               OGRFOTOGRAF = ogrenci.OGRFOTOGRAF

                           }).ToPagedList(pageIndex, 10);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Customer", model);
            }
            else
            {
                return View(model);
            }


            return View();
        }
    }
}