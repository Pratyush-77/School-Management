using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.ViewModel;


namespace WebApplication7.Models
{
    public class AllCategoryListsModel
    {
        public static List<SelectListItem> GetAllClass()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblClassMasters
                             where v.Status == true               // Only active clients
                             orderby v.ClassName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.ClassId.ToString(),
                        Text = l.ClassName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }

        public static List<SelectListItem> GetAllSection()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblSectionMasters
                             where v.Status == true               // Only active clients
                             orderby v.SectionName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.SectionID.ToString(),
                        Text = l.SectionName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }


        public static List<SelectListItem> GetAllSession()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblSessionMasters
                             where v.Status == true               // Only active clients
                             orderby v.SessionName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.SessionID.ToString(),
                        Text = l.SessionName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }

        public static List<SelectListItem> GetAllFeeHead()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblFeeMasters
                             where v.Status == true               // Only active clients
                             orderby v.FeeName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.FeeID.ToString(),
                        Text = l.FeeName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }

        public static List<SelectListItem> GetAllExpenseHead()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblExpenseHeadMasters
                             where v.Status == true               // Only active clients
                             orderby v.ExpenseName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.ExpenseID.ToString(),
                        Text = l.ExpenseName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }

        public static List<SelectListItem> GetAllFundType()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblFundMasters
                             where v.Status == true               // Only active clients
                             orderby v.FundName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.FundID.ToString(),
                        Text = l.FundName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }

        public static List<SelectListItem> GetAllFeeName()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblFeeMasters
                             where v.Status == true               // Only active clients
                             orderby v.FeeName ascending      // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.FeeID.ToString(),
                        Text = l.FeeName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }


        public static List<SelectListItem> GetAllStaffSalary()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();
                        
            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblAddStaffs
                             //where v.Status == true               // Only active clients
                             orderby v.AddStaffID  // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.AddStaffID.ToString(),
                        Text = l.EmpName
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }


        public static List<SelectListItem> GetAllCollectFee()
        {
            List<SelectListItem> nlist = new List<SelectListItem>();

            using (var DataContext = new SchoolManagementDBDataContext())
            {
                var blist = (from v in DataContext.tblAdmissions
                                 //where v.Status == true               // Only active clients
                             orderby v.AdmissionID  // Order by client name
                             select v).ToList();

                foreach (var l in blist)
                {
                    SelectListItem slist = new SelectListItem
                    {
                        Value = l.AdmissionID.ToString(),
                        Text = l.AdmissionNo
                    };
                    nlist.Add(slist);
                }
            }

            return nlist;
        }



    }
}