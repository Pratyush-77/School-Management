using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class AdmissionModel
    {
        public int AdmissionID { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
        
        public int SessionID { get; set; }

        public string AdmissionNo { get; set; }

        public DateTime AdmissionDate { get; set; }

        
        public List<SelectListItem> ClassList { get; set; }
        
        public List<SelectListItem> SessionList { get; set; }

        
        public List<SelectListItem> SectionList { get; set; }
        public string StudentName { get; set; }

        public DateTime DOB { get; set; }

        public string MotherTongue { get; set; }

        public string BloodGroup { get; set; }

        public string Gender { get; set; }

        public string AadhaarNo { get; set; }
        public HttpPostedFileBase AadhaarFrontImage { get; set; }
        public HttpPostedFileBase AadhaarBackImage { get; set; }

        public string Nationality { get; set; }

        public string Religion { get; set; }

        public string Caste { get; set; }

        public string Address { get; set; }
        public string State { get; set; }

        public string FatherName { get; set; }

        public string FatherOccupation { get; set; }

        public string FatherMobileNo { get; set; }

        public string FatherAnnualIncome { get; set; }

        public string MotherName { get; set; }

        public string MotherOccupation { get; set; }

        public string MotherMobileNo { get; set; }

        public string MotherAnnualIncome { get; set; }

    }
}