using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class ExpenseHeadViewModel
    {
        public static SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();
        //create 
        public static AllResponseMessage SaveExpense(ExpenseHeadModel pmodel)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                // Trim and validate Expense Name
                string ExpenseName = pmodel.ExpenseName?.Trim();
                if (string.IsNullOrEmpty(ExpenseName))
                {
                    resp.Status = false; 
                    resp.Message = "Expense Head name cannot be empty.";
                    return resp;
                }

                // Check for duplicate (case-insensitive)
                bool isDuplicate = DataContext.tblExpenseHeadMasters
                    .Any(e => e.ExpenseName.ToLower() == ExpenseName.ToLower()
                           && e.ExpenseID != pmodel.ExpenseID);

                if (isDuplicate)
                {
                    resp.Status = false;
                    resp.Message = "Expense Head name already exists. Please choose a different name.";
                    return resp;
                }

                // Insert New
                if (pmodel.ExpenseID == 0)
                {
                    var newExpense = new tblExpenseHeadMaster
                    {
                        ExpenseName = ExpenseName,
                        Status = true,
                    };

                    DataContext.tblExpenseHeadMasters.InsertOnSubmit(newExpense);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Expense Head added successfully.";
                }
                else
                {
                    // Update Existing
                    var existingExpense = DataContext.tblExpenseHeadMasters
                        .FirstOrDefault(e => e.ExpenseID == pmodel.ExpenseID);

                    if (existingExpense != null)
                    {
                        existingExpense.ExpenseName = ExpenseName;
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Expense Head updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Expense Head not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error: " + ex.Message;
            }

            return resp;
        }

        // ✅ Get all Expense Head
        public static List<ExpenseHeadModel> GetAllExpenseList()
        {
            try
            {
                return DataContext.tblExpenseHeadMasters
                    .Select(s => new ExpenseHeadModel
                    {
                        ExpenseID = s.ExpenseID,
                        ExpenseName = s.ExpenseName,
                        Status = s.Status
                    })
                    .OrderBy(e => e.ExpenseName)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Optional: log exception here
                return new List<ExpenseHeadModel>();
            }
        }

        // ✅ Get a single Expense Head by ID (for Edit)
        public static ExpenseHeadModel EditExpenseById(int id)
        {
            try
            {
                var r = DataContext.tblExpenseHeadMasters.FirstOrDefault(s => s.ExpenseID == id);
                if (r != null)
                {
                    return new ExpenseHeadModel
                    {
                        ExpenseID = r.ExpenseID,
                        ExpenseName = r.ExpenseName,
                    };
                }
            }
            catch (Exception ex)
            {
                // Optional: log exception
            }

            return new ExpenseHeadModel(); // return empty model if not found or failed
        }


        //......Status
        public static AllResponseMessage ExpenseStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var cst = (from r in DataContext.tblExpenseHeadMasters
                           where r.ExpenseID == id
                           select r).FirstOrDefault();

                if (cst != null)
                {
                    cst.Status = !cst.Status; // toggle status
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Status changed successfully.";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Expense Head not found.";
                }
            }
            catch (Exception ex)
            {
                // Optional: log the exception
                // Logger.LogError(ex);

                resp.Status = false;
                resp.Message = "An error occurred while changing status." + ex.Message;
            }

            return resp;
        }

        //✅ Delete Expense Head by ID
        public static AllResponseMessage DeleteExpense(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {


                    // ✅ Check in tblExpenses
                    bool usedInExpenses = db.tblExpenses
                                             .Any(x => x.ExpenseHeadID == id);

                    if (usedInExpenses)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this section because it is used in Expenses.";
                        return resp;
                    }

                    // ✅ . Delete Section (ONLY if not used anywhere)
                    var Expense = db.tblExpenseHeadMasters.FirstOrDefault(r => r.ExpenseID == id);

                    if (Expense != null)
                    {
                        db.tblExpenseHeadMasters.DeleteOnSubmit(Expense);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Expenses deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Expenses not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while deleting Expenses: " + ex.Message;
            }

            return resp;
        }
    }
}