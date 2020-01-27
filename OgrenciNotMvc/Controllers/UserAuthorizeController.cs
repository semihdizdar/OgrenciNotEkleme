using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class UserAuthorizeController : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["KullaniciAdi"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/UyeGiris/Index");
                return false;
            }

           
        }
    }
}