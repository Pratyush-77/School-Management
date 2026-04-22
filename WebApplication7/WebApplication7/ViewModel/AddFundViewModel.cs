using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddFundViewModel
    {
        private static readonly SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();

        // ✅ CREATE or UPDATE Fund (with duplicate check)
        public static AllResponseMessage SaveFund(AddFundModel model)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.FundName))
                {
                    resp.Status = false;
                    resp.Message = "Invalid Fund details.";
                    return resp;
                }

                // Duplicate name check (case-insensitive)
                bool exists = DataContext.tblFundMasters
                    .Any(g => g.FundName.ToLower().Trim() == model.FundName.ToLower().Trim()
                           && g.FundID != model.FundID);

                if (exists)
                {
                    resp.Status = false;
                    resp.Message = "A Fund with this name already exists.";
                    return resp;
                }

                tblFundMaster Fund;

                if (model.FundID == 0)
                {
                    // Create new Fund
                    Fund = new tblFundMaster
                    {
                        FundName = model.FundName.Trim(),
                        Status = true
                    };

                    DataContext.tblFundMasters.InsertOnSubmit(Fund);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Fund added successfully.";
                }
                else
                {
                    // Update existing Fund
                    Fund = DataContext.tblFundMasters.FirstOrDefault(v => v.FundID == model.FundID);

                    if (Fund != null)
                    {
                        Fund.FundName = model.FundName.Trim();
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Fund updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Fund not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while saving Fund: " + ex.Message;
            }

            return resp;
        }

        // ✅ GET ALL Fee
        public static List<AddFundModel> GetAllFundList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from g in db.tblFundMasters
                            orderby g.FundName ascending
                            select new AddFundModel
                            {
                                FundID = g.FundID,
                                FundName = g.FundName,
                                Status = Convert.ToBoolean(g.Status)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Fund list: " + ex.Message, ex);
            }
        }

        // ✅ LOAD Fund by ID
        public static AddFundModel EditFundById(int id)
        {
            AddFundModel model = new AddFundModel();

            try
            {
                var Fund = DataContext.tblFundMasters.FirstOrDefault(s => s.FundID == id);
                if (Fund != null)
                {
                    model.FundID = Fund.FundID;
                    model.FundName = Fund.FundName;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while loading Fund: " + ex.Message, ex);
            }

            return model;
        }

        // ✅ DELETE Fund
        public static AllResponseMessage DeleteFund(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    // ✅ Check in tblAddIncome
                    bool usedInAddIncome = db.tblAddIncomes
                                        .Any(x => x.FundID == id);

                    if (usedInAddIncome)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this Fund type because it is used in the processing of Add Income data.";
                        return resp;
                    }

                    // ✅ Delete Fund Type (ONLY if not used anywhere)
                    var Fund = db.tblFundMasters.FirstOrDefault(r => r.FundID == id);

                    if (Fund != null)
                    {
                        db.tblFundMasters.DeleteOnSubmit(Fund);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Fund Type deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Fund Type not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while deleting Fund Type: " + ex.Message;
            }

            return resp;
        }

        // ✅ TOGGLE Fund Status (Active / Inactive)
        public static AllResponseMessage FundStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var Fund = DataContext.tblFundMasters.FirstOrDefault(e => e.FundID == id);
                if (Fund != null)
                {
                    Fund.Status = !Fund.Status;
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Fund status updated successfully.";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Fund not found.";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while updating status: " + ex.Message;
            }

            return resp;

        }
    }
}