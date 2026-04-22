using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class StaffListViewModel
    {
        //list
        public static List<StaffListModel> getAllStaffList()
        {
            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    return (from a in db.tblAddStaffs
                            orderby a.AddStaffID
                            select new StaffListModel
                            {
                                Id = a.AddStaffID,
                                StaffName = a.EmpName,
                                StaffType = a.Designation,
                                FatherName = a.EmpFatherName,
                                DOB = string.Format("{0:dd-MM-yyyy}",a.DOB),
                                Mobile = a.MobileNo,
                                Email = a.Email,
                                Address = a.PresentAddress,
                                ProfileImage = a.ProfileImage,
                                Status = Convert.ToBoolean(a.Status)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching Staff List.", ex);
            }
        }


        //status
        public static AllResponseMessage StaffListStatus(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (var db = new SchoolManagementDBDataContext())
                {
                    var mapping = db.tblAddStaffs.FirstOrDefault(x => x.AddStaffID == id);

                    if (mapping == null)
                    {
                        resp.Status = false;
                        resp.Message = "Mapping not found.";
                        return resp;
                    }

                    mapping.Status = !mapping.Status;
                    db.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Status updated successfully.";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = "Error updating status: " + ex.Message;
            }

            return resp;
        }


        //delete
        public static AllResponseMessage DeleteStaffList(int id)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                {
                    var data = db.tblAddStaffs.SingleOrDefault(x => x.AddStaffID == id);

                    if (data == null)
                    {
                        resp.Status = false;
                        resp.Message = "Record not found";
                        return resp;
                    }

                    db.tblAddStaffs.DeleteOnSubmit(data);
                    db.SubmitChanges();

                    resp.Status = true;
                    resp.Message = "Staff deleted successfully";
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