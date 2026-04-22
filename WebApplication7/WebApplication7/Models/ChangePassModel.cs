using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class ChangePassModel
    {
        [Required(ErrorMessage = "Enter Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Enter new Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Enter confirm new Password")]
        [Compare(otherProperty: "NewPassword", ErrorMessage = "New password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}