using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AddClassModel
    {
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Please Enter Class Name")]
        public string ClassName { get; set; }
        public bool Status { get; set; }
    }

    public class AddSectionModel
    {
        public int SectionID { get; set; }

        [Required(ErrorMessage = "Please Enter Section Name")]
        public string SectionName { get; set; }
        public bool Status { get; set; }
    }
}