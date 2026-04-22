using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class IssueCertificateViewModel
    {
        public static IssueCertificateModel GetCertificateData(int admissionId)
        {
            using (var db = new SchoolManagementDBDataContext())
            {
                var data = (from a in db.tblAdmissions
                            join c in db.tblClassMasters
                            on a.ClassID equals c.ClassId
                            join s in db.tblSessionMasters on a.SessionID equals s.SessionID
                            where a.AdmissionID == admissionId
                            select new IssueCertificateModel
                            {
                                AdmissionID = a.AdmissionID,
                                StudentName = a.StudentName,
                                FatherName = a.FatherName,
                                ClassName = c.ClassName,
                                AcademicYear = s.SessionName,
                                Character = "Good"
                            }).FirstOrDefault();

                return data;
            }
        }
    }
}