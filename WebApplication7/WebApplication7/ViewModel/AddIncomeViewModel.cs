using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddIncomeViewModel
    {
        //list
        public static List<AddIncomeModel> getAllIncomeList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from a in db.tblAddIncomes
                            join f in db.tblFundMasters on a.FundID equals f.FundID
                            orderby a.FundID
                            select new AddIncomeModel
                            {
                                IncomeID = a.IncomeID,
                                FundID = (int)f.FundID,
                                FundName = f.FundName,
                                PersonName = a.PersonName,
                                Amount = (int)a.Amount,
                                PayMode = a.PayMode,
                                Remark = a.Remark,
                                TransactionImg = a.TransactionImage,
                                PayDate = string.Format("{0:dd-MM-yyyy}", a.PayDate)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Student List.", ex);
            }
        }


        //delete
        public static AllResponseMessage DeleteAddIncome(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                {
                    var data = db.tblAddIncomes.SingleOrDefault(x => x.IncomeID == id);

                    if (data == null)
                    {
                        resp.Status = false;
                        resp.Message = "Record not found";
                        return resp;
                    }

                    db.tblAddIncomes.DeleteOnSubmit(data);
                    db.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Income deleted successfully";
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