using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class ExpensesModel
    {
        public int ExpensesID { get; set; }

        public string ExpensesHead { get; set; }

        public string BillDate { get; set; }

        public string BillNo { get; set; }
        public HttpPostedFileBase BillImage { get; set; }
        public string BillImg { get; set; }


        public int Amount { get; set; }

        public string PersonName { get; set; }

        public string PayMode { get; set; }

        public string Remark { get; set; }

        public int ExpenseHeadID { get; set; }
        public List<SelectListItem> ExpenseHeadList { get; set; }
    }
}