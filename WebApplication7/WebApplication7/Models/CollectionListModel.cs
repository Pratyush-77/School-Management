using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class CollectionListModel
    {
        public int CollectionID { get; set; }

        public string AdmissionNo { get; set; }

        public string PaymentDate { get; set; }

        public string StudentName { get; set; }

        public string ClassName { get; set; }

        public string PaymentMode { get; set; }
        public decimal PaidAmount { get; set; }



        public List<SelectListItem> ClassList { get; set; }

        public List<SelectListItem> SectionList { get; set; }

        public List<SelectListItem> SessionList { get; set; }

        public List<SelectListItem> FeeHeadList { get; set; }
        public int ClassID { get; set; }

        public int SectionID { get; set; }

        public int SessionID { get; set; }
        public int FeeHeadID { get; set; }

        

       

    }
}