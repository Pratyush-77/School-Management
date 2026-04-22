using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AddFeeModel
    {
        public int FeeID { get; set; }
        [Required(ErrorMessage = "Please Enter Fee Type Name")]
        public string FeeName { get; set; }

        public bool Status { get; set; }
    }
}