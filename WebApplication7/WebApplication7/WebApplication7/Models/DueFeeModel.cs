using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class DueFeeModel
    {
        public int DueFeeID { get; set; }
        public string AdmissionNo { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public int TotalAmt { get; set; }
        public int PaidAmt { get; set; }
        public int BalanceAmt { get; set; }

        public int ClassID { get; set; }

        public int SectionID { get; set; }

        public int SessionID { get; set; }
        public List<SelectListItem> ClassList { get; set; }

        public List<SelectListItem> SectionList { get; set; }

        public List<SelectListItem> SessionList { get; set; }
    }
}