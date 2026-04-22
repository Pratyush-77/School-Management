using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AddSessionModel
    {
        public int SessionID { get; set; }

        [Required(ErrorMessage = "Please Enter Session Name")]
        public string SessionName { get; set; }
        public bool Status { get; set; }
    }
}