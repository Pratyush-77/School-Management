using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class AdmissionListModel
    {
        public int AdmissionListID { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }

        public int SessionID { get; set; }
        public string AdmissionNo { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string FatherMobileNo { get; set; }
        public string Fee { get; set; }
        public string AdmissionDate { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string SessionName { get; set; }


        public List<SelectListItem> ClassList { get; set; }
         
        public List<SelectListItem> SessionList { get; set; }


        public List<SelectListItem> SectionList { get; set; }



    }
}