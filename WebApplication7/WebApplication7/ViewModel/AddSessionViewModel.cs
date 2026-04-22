using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class AddSessionViewModel
    {
        private static readonly SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();

        // ✅ CREATE or UPDATE Session (with duplicate check)
        public static AllResponseMessage SaveSession(AddSessionModel model)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.SessionName))
                {
                    resp.Status = false;
                    resp.Message = "Invalid gift details.";
                    return resp;
                }

                // Duplicate name check (case-insensitive)
                bool exists = DataContext.tblSessionMasters
                    .Any(g => g.SessionName.ToLower().Trim() == model.SessionName.ToLower().Trim()
                           && g.SessionID != model.SessionID);

                if (exists)
                {
                    resp.Status = false;
                    resp.Message = "A Session with this name already exists.";
                    return resp;
                }

                tblSessionMaster Session;

                if (model.SessionID == 0)
                {
                    // Create new Session
                    Session = new tblSessionMaster
                    {
                        SessionName = model.SessionName.Trim(),
                        Status = true
                    };

                    DataContext.tblSessionMasters.InsertOnSubmit(Session);
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Session added successfully.";
                }
                else
                {
                    // Update existing Session
                    Session = DataContext.tblSessionMasters.FirstOrDefault(v => v.SessionID == model.SessionID);

                    if (Session != null)
                    {
                        Session.SessionName = model.SessionName.Trim();
                        DataContext.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Session updated successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Session not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error while saving Session: " + ex.Message;
            }

            return resp;
        }

        // ✅ GET ALL Session
        public static List<AddSessionModel> GetAllSessionList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from g in db.tblSessionMasters
                            orderby g.SessionName ascending
                            select new AddSessionModel
                            {
                                SessionID = g.SessionID,
                                SessionName = g.SessionName,
                                Status = Convert.ToBoolean(g.Status)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Session list: " + ex.Message, ex);
            }
        }

        // ✅ LOAD Session by ID
        public static AddSessionModel EditSessionById(int id)
        {
            AddSessionModel model = new AddSessionModel();

            try
            {
                var Session = DataContext.tblSessionMasters.FirstOrDefault(s => s.SessionID == id);
                if (Session != null)
                {
                    model.SessionID = Session.SessionID;
                    model.SessionName = Session.SessionName;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while loading Session: " + ex.Message, ex);
            }

            return model;
        }

        // ✅ DELETE Session
        public static AllResponseMessage DeleteSession(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {


                    // ✅  Check in tblAdmission
                    bool usedInAdmission = db.tblAdmissions
                                             .Any(x => x.SessionID == id);

                    if (usedInAdmission)
                    {
                        resp.Status = false;
                        resp.Message = "You are unable to delete this session because it is used in Admission.";
                        return resp;
                    }

                    // ✅ Delete Session (ONLY if not used anywhere)
                    var Session = db.tblSessionMasters.FirstOrDefault(r => r.SessionID == id);

                    if (Session != null)
                    {
                        db.tblSessionMasters.DeleteOnSubmit(Session);
                        db.SubmitChanges();

                        resp.Status = true;
                        resp.Message = "Session deleted successfully.";
                    }
                    else
                    {
                        resp.Status = false;
                        resp.Message = "Session not found.";
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

        // ✅ TOGGLE Gift Status (Active / Inactive)
        public static AllResponseMessage SessionStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                var Session = DataContext.tblSessionMasters.FirstOrDefault(e => e.SessionID == id);
                if (Session != null)
                {
                    Session.Status = !Session.Status;
                    DataContext.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Session status updated successfully.";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Session not found.";
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