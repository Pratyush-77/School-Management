using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AdmissionReportViewModel
    {
        //list
        public static List<AdmissionReportModel> getAllAdmissionReportList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from a in db.tblAdmissions
                            join c in db.tblClassMasters on a.ClassID equals c.ClassId
                            join s in db.tblSectionMasters on a.SectionID equals s.SectionID
                            join r in db.tblSessionMasters on a.SessionID equals r.SessionID
                            join f in db.tblFeeStructureMasters on c.ClassId equals f.ClassNameID
                            orderby a.AdmissionID
                            select new AdmissionReportModel
                            {
                                AdmissionNo = a.AdmissionNo,
                                StudentName = a.StudentName,
                                FatherName = a.FatherName,
                                FatherMobileNo = a.FatherMobileNo,
                                Class = c.ClassName,
                                Section = s.SectionName,
                                Session = r.SessionName,
                                Fee = Convert.ToString(f.Amount),
                                AdmissionDate = string.Format("{0:dd-MM-yyyy}",a.AdmissionDate)
                               
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Student List.", ex);
            }
        }
    }
}