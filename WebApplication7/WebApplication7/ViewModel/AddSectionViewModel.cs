using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddSectionViewModel
    {

        public static SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();
        //create 
        public static AllResponseMessage SaveSection(AddSectionModel pmodel)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                // Trim and validate Section Name
                string SectionName = pmodel.SectionName?.Trim();
                if (string.IsNullOrEmpty(SectionName))
                {
                    resp.Status = false;
                    resp.Message = "Section name cannot be empty.";
                    return resp;
                }

                // Check for duplicate (case-insensitive)
                bool isDuplicate = DataContext.tblSectionMasters
                    .Any(e => e.SectionName.ToLower() == SectionName.ToLower()
                           && e.SectionID != pmodel.SectionID);

                if (isDuplicate)
                {
                    resp.Status = false;
                    resp.Message = "Section name already exists. Please choose a different name.";
                    return resp;
                }

                // Insert New
                if (pmodel.SectionID== 0)
                {
                    var newSection = new tblSectionMaster
                    {
                        SectionName = SectionName,
                        Status = true,
                    };

                    DataContext.tblSectionMasters.InsertOnSubmit(newSection);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Section added successfully.";
                }
                else
                {
                    // Update Existing
                    var existingSection = DataContext.tblSectionMasters
                        .FirstOrDefault(e => e.SectionID == pmodel.SectionID);

                    if (existingSection != null)
                    {
                        existingSection.SectionName = SectionName;
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Section updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Section not found.";
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
        public static List<AddSectionModel> GetAllSectionList()
        {
            try
            {
                return DataContext.tblSectionMasters
                    .Select(s => new AddSectionModel
                    {
                        SectionID = s.SectionID,
                        SectionName = s.SectionName,
                        Status = s.Status
                    })
                    .OrderBy(e => e.SectionName)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Optional: log exception here
                return new List<AddSectionModel>();
            }
        }

        // ✅ Get a single event by ID (for Edit)
        public static AddSectionModel EditSectionById(int id)
        {
            try
            {
                var r = DataContext.tblSectionMasters.FirstOrDefault(s => s.SectionID == id);
                if (r != null)
                {
                    return new AddSectionModel
                    {
                        SectionID = r.SectionID,
                        SectionName = r.SectionName,
                    };
                }
            }
            catch (Exception ex)
            {
                // Optional: log exception
            }

            return new AddSectionModel(); // return empty model if not found or failed
        }

        public static AllResponseMessage SectionStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var cst = (from r in DataContext.tblSectionMasters
                           where r.SectionID == id
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
                    resp.Message = "Section not found.";
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

        // ✅ Delete Section by ID
        public static AllResponseMessage DeleteSection(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {


                    // ✅ Check in tblAdmission
                    bool usedInAdmission = db.tblAdmissions
                                             .Any(x => x.SectionID == id);

                    if (usedInAdmission)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this section because it is used in Admission.";
                        return resp;
                    }

                    // ✅ Delete Section (ONLY if not used anywhere)
                    var Section = db.tblSectionMasters.FirstOrDefault(r => r.SectionID == id);

                    if (Section != null)
                    {
                        db.tblSectionMasters.DeleteOnSubmit(Section);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Section deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Section not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while deleting Section: " + ex.Message;
            }

            return resp;
        }
    }
}