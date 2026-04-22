using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class ExpenseHeadModel
    {
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Please Enter Expense Head Name")]
        public string ExpenseName { get; set; }
        public bool Status { get; set; }
    }
}