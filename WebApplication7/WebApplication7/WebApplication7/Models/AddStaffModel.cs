using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AddStaffModel
    {
        public int AddStaffID { get; set; }

        public string EmpName { get; set; }

        public string EmpFatherName { get; set; }

        public string Gender { get; set; }

        public DateTime DOB{ get; set; }

        public string MobileNo { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }

        public string PANNo { get; set; }

        public string AadhaarNo { get; set; }

        public string PresentAddress { get; set; }

        public string PresentCityName { get; set; }

        public string PresentDistrictName { get; set; }

        public int PresentPincode { get; set; }

        public string CorAddress { get; set; }

        public string CorCityName { get; set; }

        public string CorDistrictName { get; set; }

        public int CorPincode { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal HRA { get; set; }

        public decimal EPF { get; set; }

        public decimal MedicalAllowance { get; set; }

        public decimal TravelAllowance { get; set; }

        public decimal ConveyanceAllowance { get; set; }

        public decimal ProfessionalTax { get; set; }
        
        public decimal PFCount { get; set; }
        
        public decimal SpecialAllowance { get; set; }
        public decimal FoodAllowance { get; set; }
        public decimal ESIC { get; set; }
        public decimal NetGrossSalary { get; set; }
        public decimal NetPay { get; set; }
        public decimal TotalDeduction { get; set; }

        public HttpPostedFileBase ProfileImage { get; set; }
        public string ProfileImg { get; set; }

        public HttpPostedFileBase AadhaarFrontImage{ get; set; }
        public HttpPostedFileBase AadhaarBackImage { get; set; }
        public HttpPostedFileBase PANCard { get; set; }
        public string DocumentType { get; set; }
        public HttpPostedFileBase Document { get; set; }
        public string BankHolderName{ get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public HttpPostedFileBase PassbookImage { get; set; }
        


    }
}