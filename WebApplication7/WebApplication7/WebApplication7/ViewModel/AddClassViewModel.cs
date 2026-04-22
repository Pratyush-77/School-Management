using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddClassViewModel
    {
        public static SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();
        //create 
        public static AllResponseMessage SaveClass(AddClassModel pmodel)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                // Trim and validate Event Name
                string ClassName = pmodel.ClassName?.Trim();
                if (string.IsNullOrEmpty(ClassName))
                {
                    resp.Status = false;
                    resp.Message = "Class name cannot be empty.";
                    return resp;
                }

                // Check for duplicate (case-insensitive)
                bool isDuplicate = DataContext.tblClassMasters
                    .Any(e => e.ClassName.ToLower() == ClassName.ToLower()
                           && e.ClassId != pmodel.ClassId);

                if (isDuplicate)
                {
                    resp.Status = false;
                    resp.Message = "Class name already exists. Please choose a different name.";
                    return resp;
                }

                // Insert New
                if (pmodel.ClassId == 0)
                {
                    var newClass = new tblClassMaster
                    {
                        ClassName = ClassName,
                        Status = true,
                    };

                    DataContext.tblClassMasters.InsertOnSubmit(newClass);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Class added successfully.";
                }
                else
                {
                    // Update Existing
                    var existingClass = DataContext.tblClassMasters
                        .FirstOrDefault(e => e.ClassId == pmodel.ClassId);

                    if (existingClass != null)
                    {
                        existingClass.ClassName = ClassName;
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Class updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Class not found.";
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

        // ✅ Get all events
        public static List<AddClassModel> GetAllClassList()
        {
            try
            {
                return DataContext.tblClassMasters
                    .Select(s => new AddClassModel
                    {
                        ClassId = s.ClassId,
                        ClassName = s.ClassName,
                        Status = s.Status
                    })
                    .OrderBy(e => e.ClassName)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Optional: log exception here
                return new List<AddClassModel>();
            }
        }

        // ✅ Get a single Class by ID (for Edit)
        public static AddClassModel EditClassById(int id)
        {
            try
            {
                var r = DataContext.tblClassMasters.FirstOrDefault(s => s.ClassId == id);
                if (r != null)
                {
                    return new AddClassModel
                    {
                        ClassId = r.ClassId,
                        ClassName = r.ClassName,
                    };
                }
            }
            catch (Exception ex)
            {
                // Optional: log exception
            }

            return new AddClassModel(); // return empty model if not found or failed
        }


        //Status
        public static AllResponseMessage ClassStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var cst = (from r in DataContext.tblClassMasters
                           where r.ClassId == id
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
                    resp.Message = "Class not found.";
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

        //✅ Delete Class by ID
        public static AllResponseMessage DeleteClass(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    // ✅ 1. Check in tblFeeStructure
                    bool usedInFeeStructure = db.tblFeeStructureMasters
                                        .Any(x => x.ClassNameID == id);

                    if (usedInFeeStructure)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this Class because it is used in the processing of Fee Structure data.";
                        return resp;
                    }

                    // ✅ 2. Check in tblAdmission
                    bool usedInAdmission = db.tblAdmissions
                                             .Any(x => x.ClassID == id);

                    if (usedInAdmission)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this class because it is used in Admission.";
                        return resp;
                    }

                    // ✅ . Delete Class (ONLY if not used anywhere)
                    var Class = db.tblClassMasters.FirstOrDefault(r => r.ClassId == id);

                    if (Class != null)
                    {
                        db.tblClassMasters.DeleteOnSubmit(Class);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message ="Class deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Class not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while deleting Class: " + ex.Message;
            }

            return resp;
     }


    }
}
   