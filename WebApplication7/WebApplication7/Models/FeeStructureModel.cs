using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class FeeStructureModel
    {
        public int FeeID { get; set; }
        public int ClassNameID { get; set; }
        public int FeeNameID { get; set; }

        public string ClassName { get; set; }

        public string FeeName { get; set; }

        public int Amount { get; set; }

        public bool Status { get; set; }

        public List<SelectListItem> ClassNameList { get; set; }

        public List<SelectListItem> FeeNameList { get; set; }
    }
}