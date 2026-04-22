using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class StaffListModel
    {
        public int Id { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string StaffType { get; set; }
        public string FatherName { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       
        public string ProfileImage { get; set; }
        
        public bool Status { get; set; }
    }
}