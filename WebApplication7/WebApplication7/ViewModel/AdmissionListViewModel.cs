using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AdmissionListViewModel
    {
        //private static readonly SchoolManagementDBDataContext db = new SchoolManagementDBDataContext();
        //List  
        //public static List<AdmissionListModel> getAllAdmissionList()
        //{
        //    try
        //    {
        //        using (var db = new SchoolManagementDBDataContext())
        //        {
        //            return (from g in db.tblAdmissions
        //                    join c in db.tblClassMasters on g.ClassID equals c.ClassId
        //                    join s in db.tblSectionMasters on g.SectionID equals s.SectionID
        //                    join r in db.tblSessionMasters on g.SessionID equals r.SessionID
        //                    join f in db.tblFeeStructureMasters on c.ClassId equals f.ClassNameID
        //                    orderby g.AdmissionID
        //                    select new AdmissionListModel
        //                    {
        //                        AdmissionListID = g.AdmissionID,
        //                        ClassID = (int)g.ClassID,
        //                        SectionID = (int)g.SectionID,
        //                        SessionID = (int)g.SessionID,
        //                        AdmissionNo = g.AdmissionNo,
        //                        StudentName = g.StudentName,
        //                        FatherName = g.FatherName,
        //                        FatherMobileNo = g.FatherMobileNo,
        //                        ClassName = c.ClassName,
        //                        SectionName = s.SectionName,
        //                        SessionName = r.SessionName,
        //                        Fee = Convert.ToString(f.Amount),
        //                        AdmissionDate = string.Format("{0:dd-MM-yyyy}", g.AdmissionDate)
        //                    }).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error while fetching Student List.", ex);
        //    }
        //}

        //delete
        public static AllResponseMessage DeleteAdmission(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                {
                    var data = db.tblAdmissions.SingleOrDefault(x => x.AdmissionID == id);

                    if (data == null)
                    {
                        resp.Status = false;
                        resp.Message = "Record not found";
                        return resp;
                    }

                    db.tblAdmissions.DeleteOnSubmit(data);
                    db.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Admission deleted successfully";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }

            return resp;

        }

    }
}