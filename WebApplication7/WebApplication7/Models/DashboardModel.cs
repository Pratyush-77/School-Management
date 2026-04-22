using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class DashboardModel
    {
        public int TotalSession { get; set; }
        public int TotalSection { get; set; }
        public int TotalClass { get; set; }
        public int TotalAdmission { get; set; }
        public decimal TotalFeeCollect { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}