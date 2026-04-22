using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class FeeStructureViewModel
    {
        private static readonly SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();

        // ✅ CREATE or UPDATE Fee Structure (with duplicate check)
        public static AllResponseMessage SaveFeeStructure(FeeStructureModel model)
{
    AllResponseMessage resp = new AllResponseMessage();

    try
    {
                if (model == null)
                {
                    resp.Status = false;
                    resp.Message = "Model is null.";
                    return resp;
                }
                bool exists = DataContext.tblFeeStructureMasters
            .Any(g => g.FeeNameID == model.FeeNameID
                   && g.ClassNameID == model.ClassNameID
                   && g.FeeID != model.FeeID);

        if (exists)
        {
            resp.Status = false;
            resp.Message = "Fee Structure already exists.";
            return resp;
        }

        tblFeeStructureMaster feeStructure;

        if (model.FeeID == 0)
        {
            feeStructure = new tblFeeStructureMaster
            {
                
                ClassNameID = model.ClassNameID,
                FeeNameID = model.FeeNameID,
                Amount = model.Amount,
                Status = true
            };

            DataContext.tblFeeStructureMasters.InsertOnSubmit(feeStructure);
            DataContext.SubmitChanges();

            resp.Status = true;
            resp.Message = "Fee Structure added successfully.";
        }
        else
        {
            feeStructure = DataContext.tblFeeStructureMasters
                .FirstOrDefault(v => v.FeeID == model.FeeID);

            if (feeStructure != null)
            {
               
                feeStructure.ClassNameID = model.ClassNameID;
                feeStructure.FeeNameID = model.FeeNameID;
                feeStructure.Amount = model.Amount;

                DataContext.SubmitChanges();

                resp.Status = true;
                resp.Message = "Fee Structure updated successfully.";
            }
            else
            {
                resp.Status = false;
                resp.Message = "Fee Structure not found.";
            }
        }
    }
    catch (Exception ex)
    {
        resp.Status = false;
        resp.Message = ex.Message;
    }

    return resp;
}


        // ✅ GET ALL Fee Structure
        public static List<FeeStructureModel> GetAllFeeStructureList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from g in db.tblFeeStructureMasters 
                            join c in db.tblClassMasters on g.ClassNameID equals c.ClassId 
                            join f in db.tblFeeMasters on g.FeeNameID equals f.FeeID
                            orderby g.FeeID ascending
                            select new FeeStructureModel
                            {
                                FeeID = g.FeeID,
                                FeeName = f.FeeName,
                                ClassName = c.ClassName,
                                FeeNameID = (int)g.FeeNameID,
                                ClassNameID = (int)g.ClassNameID,
                                Amount = (int)g.Amount,
                                Status = Convert.ToBoolean(g.Status)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Fee Structure list: " + ex.Message, ex);
            }
        }

        //// ✅ LOAD Fee Structure by ID
        //public static FeeStructureModel EditFeeStructureById(int id)
        //{
        //    FeeStructureModel model = new FeeStructureModel();

        //    try
        //    {
        //        var FeeStructure = DataContext.tblFeeStructureMasters.FirstOrDefault(s => s.FeeID == id);
        //        if (FeeStructure != null)
        //        {
        //            model.FeeID = FeeStructure.FeeID;
        //            model.FeeNameID = (int)FeeStructure.FeeNameID;
                    
        //            model.Amount = (int)FeeStructure.Amount;
        //            model.ClassNameID = (int)FeeStructure.ClassNameID;
        //            model.FeeNameID = (int)FeeStructure.FeeNameID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error while loading Fee Structure: " + ex.Message, ex);
        //    }

        //    return model;
        //}

        // ✅ DELETE Fee Structure
        //public static AllResponseMessage DeleteFeeStructure(int id)
        //{
        //    AllResponseMessage resp = new AllResponseMessage();

        //    try
        //    {
        //        using (var db = new SchoolManagementDBDataContext())
        //        {
                    
        //            // ✅ Delete Fee Structure (ONLY if not used anywhere)
        //            var FeeStructure = db.tblFeeStructureMasters.FirstOrDefault(r => r.FeeID== id);

        //            if (FeeStructure != null)
        //            {
        //                db.tblFeeStructureMasters.DeleteOnSubmit(FeeStructure);
        //                db.SubmitChanges();

        //                resp.Status = true;
        //                resp.Message = "Fee Structure deleted successfully.";
        //            }
        //            else
        //            {
        //                resp.Status = false;
        //                resp.Message = "Fee Structure not found.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.Status = false;
        //        resp.Message = "Error while deleting Fee Structure: " + ex.Message;
        //    }

        //    return resp;
        //}

        // ✅ TOGGLE Fee Status (Active / Inactive)
        public static AllResponseMessage FeeStructureStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var FeeStructure = DataContext.tblFeeStructureMasters.FirstOrDefault(e => e.FeeID == id);
                if (FeeStructure != null)
                {
                    FeeStructure.Status = !FeeStructure.Status;
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Fee Structure status updated successfully.";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Fee Structure not found.";
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