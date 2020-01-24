using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Models.UyeGiris
{
    public class LoginState
    {

        private EntityFramework.DbMvcOkulEntities4 db;

        public LoginState()
        {
            db = new DbMvcOkulEntities4();
        }

        public bool isLoginSucces(string user, string pass)
        {
            TBLKULLANICI resultUser = db.TBLKULLANICI.Where(x => x.KullaniciAdi.Equals(user) && x.Sifre.Equals(pass)).FirstOrDefault();
            if(resultUser != null)
            {
                return true;
            }
            return false;
            
        }
    }
}