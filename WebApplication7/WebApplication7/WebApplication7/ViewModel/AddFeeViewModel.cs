using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddFeeViewModel
    {
        private static readonly SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();

        // ✅ CREATE or UPDATE Fee (with duplicate check)
        public static AllResponseMessage SaveFee(AddFeeModel model)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.FeeName))
                {
                    resp.Status = false;
                    resp.Message = "Invalid Fee details.";
                    return resp;
                }

                // Duplicate name check (case-insensitive)
                bool exists = DataContext.tblFeeMasters
                    .Any(g => g.FeeName.ToLower().Trim() == model.FeeName.ToLower().Trim()
                           && g.FeeID != model.FeeID);

                if (exists)
                {
                    resp.Status = false;
                    resp.Message = "A Fee with this name already exists.";
                    return resp;
                }

                tblFeeMaster Fee;

                if (model.FeeID == 0)
                {
                    // Create new Fee
                    Fee = new tblFeeMaster
                    {
                        FeeName = model.FeeName.Trim(),
                        Status = true
                    };

                    DataContext.tblFeeMasters.InsertOnSubmit(Fee);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Fee added successfully.";
                }
                else
                {
                    // Update existing Fee
                    Fee = DataContext.tblFeeMasters.FirstOrDefault(v => v.FeeID == model.FeeID);

                    if (Fee != null)
                    {
                        Fee.FeeName = model.FeeName.Trim();
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Fee updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Fee not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while saving Fee: " + ex.Message;
            }

            return resp;
        }

        // ✅ GET ALL Fee
        public static List<AddFeeModel> GetAllFeeList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from g in db.tblFeeMasters
                            orderby g.FeeName ascending
                            select new AddFeeModel
                            {
                                FeeID = g.FeeID,
                                FeeName = g.FeeName,
                                Status = Convert.ToBoolean(g.Status)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Fee list: " + ex.Message, ex);
            }
        }

        // ✅ LOAD Fee by ID
        public static AddFeeModel EditFeeById(int id)
        {
            AddFeeModel model = new AddFeeModel();

            try
            {
                var Fee = DataContext.tblFeeMasters.FirstOrDefault(s => s.FeeID == id);
                if (Fee != null)
                {
                    model.FeeID = Fee.FeeID;
                    model.FeeName = Fee.FeeName;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while loading Fee: " + ex.Message, ex);
            }

            return model;
        }

        //✅ DELETE Fee
        public static AllResponseMessage DeleteFee(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    // ✅ Check in tblFeeStructure
                    bool usedInFeeStructure = db.tblFeeStructureMasters
                                        .Any(x => x.FeeNameID == id);

                    if (usedInFeeStructure)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this Fee Type because it is used in the processing of Fee Structure data.";
                        return resp;
                    }

                    // ✅ Delete Fee Type (ONLY if not used anywhere)
                    var Fee = db.tblFeeMasters.FirstOrDefault(r => r.FeeID == id);

                    if (Fee != null)
                    {
                        db.tblFeeMasters.DeleteOnSubmit(Fee);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Fee Type deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Fee Type not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while deleting Fee Type: " + ex.Message;
            }

            return resp;
        }

        // ✅ TOGGLE Fee Status (Active / Inactive)
        public static AllResponseMessage FeeStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var Fee = DataContext.tblFeeMasters.FirstOrDefault(e => e.FeeID == id);
                if (Fee != null)
                {
                    Fee.Status = !Fee.Status;
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Fee status updated successfully.";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Fee not found.";
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