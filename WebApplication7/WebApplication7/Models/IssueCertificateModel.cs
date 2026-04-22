using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class IssueCertificateModel
    {

        public string StudentName{ get; set; }
        public string Gender{ get; set; }
        public string FatherName{ get; set; }
        public string ClassName{ get; set; }
        public string AcademicYear{ get; set; }
        public string Section{ get; set; }
        public string Character{ get; set; }
        public string DOB{ get; set; }

        public string CertificateType{ get; set; }
        public string IssueDate{ get; set; }


        public int AdmissionID { get; set; }

        public List<SelectListItem> AdmissionNoList { get; set; }
    }
}