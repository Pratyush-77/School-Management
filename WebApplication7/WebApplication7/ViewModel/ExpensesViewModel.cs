using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class ExpensesViewModel
    {
        public static List<ExpensesModel> getAllExpenseList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from g in db.tblExpenses
                            join e in db.tblExpenseHeadMasters on g.ExpenseHeadID equals e.ExpenseID
                            orderby g.ExpensesID
                            select new ExpensesModel
                            {
                                ExpensesID = g.ExpensesID,
                                ExpenseHeadID = (int)e.ExpenseID,
                                ExpensesHead = e.ExpenseName,
                                PersonName = g.PersonName,
                                Amount = (int)g.Amount,
                                PayMode = g.PayMode,
                                Remark = g.Remark,
                                BillNo = g.BillNo,
                                BillImg = g.BillImage,
                                BillDate = string.Format("{0:dd-MM-yyyy}", g.BillDate)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Student List.", ex);
            }
        }


        //delete
        public static AllResponseMessage DeleteExpense(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                {
                    var data = db.tblExpenses.SingleOrDefault(x => x.ExpensesID == id);

                    if (data == null)
                    {
                        resp.Status = false;
                        resp.Message = "Record not found";
                        return resp;
                    }

                    db.tblExpenses.DeleteOnSubmit(data);
                    db.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Expense deleted successfully";
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
