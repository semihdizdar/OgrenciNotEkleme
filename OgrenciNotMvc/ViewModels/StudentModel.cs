using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OgrenciNotMvc.ViewModels
{
    public class StudentModel
    {

        public string OGRAD { get; set; }
        public string OGRSOYAD { get; set; }
        public int? Page { get; set; }
        public IPagedList<StudentList> Students { get; set; }

    }
}