using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class CollectionListViewModel
    {
        public static List<CollectionListModel> getAllCollectionList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {

                    return (from a in db.tblAdmissions
                            join c in db.tblCollectFees on a.AdmissionID equals c.AdmissionID
                            join d in db.tblClassMasters on a.ClassID equals d.ClassId
                            orderby a.AdmissionID
                            select new CollectionListModel
                            {
                                PaymentDate = string.Format("{0:dd-MM-yyyy}",c.PaymentsDate),
                                AdmissionNo = a.AdmissionNo,
                                StudentName = a.StudentName,
                                ClassName = d.ClassName,
                                PaymentMode = c.PaymentMode,
                                PaidAmount = (decimal)c.AmountPaid,
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