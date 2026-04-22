using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AddFundModel
    {
        public int FundID { get; set; }
        [Required(ErrorMessage = "Please Enter Fund Type Name")]
        public string FundName { get; set; }

        public bool Status { get; set; }

    }
}