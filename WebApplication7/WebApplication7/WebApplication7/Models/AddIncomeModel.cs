using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class AddIncomeModel
    {
        public int IncomeID { get; set; }

        public int FundID { get; set; }
        public string FundName { get; set; }


        public List<SelectListItem> FundTypeList { get; set; }
        public string PayDate { get; set; }
        public HttpPostedFileBase TransactionImage { get; set; }
        public string TransactionImg { get; set; }

        public int Amount { get; set; }

        public string PersonName { get; set; }

        public string PayMode { get; set; }

        public string Remark { get; set; }

    }
}