using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class PromoteStudentModel
    {

        public int PromoteID { get; set; }
        public int AdmissionID { get; set; }
        public string StudentName { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
        public int SessionID { get; set; }

        public List<SelectListItem> AdmissionList { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> ClassList { get; set; }
        public List<SelectListItem> SectionList { get; set; }
        public List<SelectListItem> SessionList { get; set; }
    }
}