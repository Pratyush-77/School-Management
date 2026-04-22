using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class CollectFeeModel
    {
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string SessionName { get; set; }
        public string PaymentMode { get; set; }
        public decimal AmountPaid { get; set; }
        public int AdmissionID { get; set; }

        public List<SelectListItem> AdmissionNoList { get; set; }

    }
}