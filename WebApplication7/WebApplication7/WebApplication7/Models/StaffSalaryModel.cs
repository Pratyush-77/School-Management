using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class StaffSalaryModel
    {
        public int StaffSalaryID { get; set; }

        public DateTime Month { get; set; }
        public string Emp { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int TWorkingDays{ get; set; }
        public int LOP{ get; set; }
        public decimal GrossSalary{ get; set; }
        public int PaidDay{ get; set; }
        public string BankName{ get; set; }
        public string BankACNo{ get; set; }
        public string IFSCCode{ get; set; }
        public decimal BasicSalary{ get; set; }
        public decimal HRA{ get; set; }
        public decimal TravelAllowance{ get; set; }
        public decimal ConveyanceAllowance{ get; set; }
        public decimal SpecialAllowance{ get; set; }
        public decimal FoodAllowance{ get; set; }
        public decimal EPFContribution{ get; set; }
        public decimal MedicalAllowance{ get; set; }
        public decimal ProfessionalTax{ get; set; }
        public decimal PFContribution{ get; set; }
        public decimal ESIContribution { get; set; }
        public decimal NetGrossSalary { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPay { get; set; }
        public int LeaveDay { get; set; }
        public decimal DeductSalary { get; set; }
        public decimal NetPayableSalary { get; set; }

        public int EmpID { get; set; }
        public List<SelectListItem> EmployeeSalaryList { get; set; }

    }
}