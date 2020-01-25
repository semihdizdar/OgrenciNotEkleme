using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class DersTestController : Controller
    {
        // GET: DersTest
        public ActionResult AddOrEdit(int id =0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}