using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using WebApplication7.ViewModel;

namespace WebApplication7.Controllers
{
    public class AdminController : Controller
    {

        public static SchoolManagementDBDataContext db = new SchoolManagementDBDataContext();
        //public SchoolManagementDBDataContext() :
        //base(global::System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString, mappingSource)
        //{
        //    OnCreated();
        //}
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }


        //..........Add class
        public ActionResult AddClass()
        {
            return View();
        }

        //create
        // ✅ Create or Update Class
        [HttpPost]
        public ActionResult AddClass(AddClassModel model)
        {
            if (model == null)
                return Json(new { result = false, message = "Invalid event data." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddClassViewModel.SaveClass(model);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Get All Class (List)
        public JsonResult GetAddClassList()
        {
            List<AddClassModel> catlist = AddClassViewModel.GetAllClassList();
            return Json(new { data = catlist }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Edit Class by ID (Fetch for edit modal/form)
        [HttpPost]
        public JsonResult EditClass(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid event ID." }, JsonRequestBehavior.AllowGet);

            AddClassModel smodel = AddClassViewModel.EditClassById(id);
            if (smodel != null && smodel.ClassId > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Class not found." }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Delete Class
        [HttpPost]
        public JsonResult DeleteClass(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid event ID." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddClassViewModel.DeleteClass(id);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Change Class Status (Activate/Deactivate)
        [HttpPost]
        public JsonResult ClassStatus(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid Class ID." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddClassViewModel.ClassStatus(id);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }


        //........ Add Section
        [HttpGet]
        public ActionResult AddSection()
        {
            return View();
        }

        //create
        // ✅ Create or Update Section
        [HttpPost]
        public ActionResult AddSection(AddSectionModel cmodel)
        {
            if (cmodel == null)
                return Json(new { result = false, message = "Invalid section data." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddSectionViewModel.SaveSection(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Get All Section (List)
        [HttpGet]
        public JsonResult GetAddSectionList()
        {
            List<AddSectionModel> catlist = AddSectionViewModel.GetAllSectionList();
            return Json(new { data = catlist }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Edit Section by ID (Fetch for edit modal/form)
        [HttpPost]
        public JsonResult EditSection(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid Section ID." }, JsonRequestBehavior.AllowGet);

            AddSectionModel smodel = AddSectionViewModel.EditSectionById(id);
            if (smodel != null && smodel.SectionID > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Section not found." }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Delete Event
        [HttpPost]
        public JsonResult DeleteSection(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid event ID." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddSectionViewModel.DeleteSection(id);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // ✅ Change Event Status (Activate/Deactivate)
        [HttpPost]
        public JsonResult SectionStatus(int id)
        {
            if (id <= 0)
                return Json(new { result = false, message = "Invalid Section ID." }, JsonRequestBehavior.AllowGet);

            AllResponseMessage resp = AddSectionViewModel.SectionStatus(id);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }


        //........Add Session
        [HttpGet]
        public ActionResult AddSession()
        {
            return View();
        }

        // POST: Save Session (Add or Update)
        [HttpPost]
        public ActionResult AddSession(AddSessionModel cmodel)
        {
            AllResponseMessage resp = AddSessionViewModel.SaveSession(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Get all Session
        [HttpGet]
        public JsonResult GetAddSessionList()
        {
            List<AddSessionModel> giftList = AddSessionViewModel.GetAllSessionList();
            return Json(new { data = giftList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fetch Session details for editing
        [HttpPost]
        public JsonResult EditSession(int id)
        {

            if (id <= 0)
                return Json(new { result = false, message = "Invalid Session ID." }, JsonRequestBehavior.AllowGet);

            AddSessionModel smodel = AddSessionViewModel.EditSessionById(id);
            if (smodel != null && smodel.SessionID > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Session not found." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Delete Session
        [HttpPost]
        public JsonResult DeleteSession(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddSessionViewModel.DeleteSession(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Session ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Toggle Session Status (Active/Inactive)
        [HttpPost]
        public JsonResult SessionStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddSessionViewModel.SessionStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Gift ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }


        //.......Expense Head...............
        [HttpGet]
        public ActionResult ExpenseHead()
        {
            return View();
        }

        // POST: Save Expense (Add or Update)
        [HttpPost]
        public ActionResult ExpenseHead(ExpenseHeadModel cmodel)
        {
            AllResponseMessage resp = ExpenseHeadViewModel.SaveExpense(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Get all Expense Head
        [HttpGet]
        public JsonResult GetAddExpenseList()
        {
            List<ExpenseHeadModel> ExpenseList = ExpenseHeadViewModel.GetAllExpenseList();
            return Json(new { data = ExpenseList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fetch Expense Head details for editing
        [HttpPost]
        public JsonResult EditExpense(int id)
        {

            if (id <= 0)
                return Json(new { result = false, message = "Invalid Expense Head ID." }, JsonRequestBehavior.AllowGet);

            ExpenseHeadModel smodel = ExpenseHeadViewModel.EditExpenseById(id);
            if (smodel != null && smodel.ExpenseID > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Expense not found." }, JsonRequestBehavior.AllowGet);

        }

        // POST: Delete Expense Head
        [HttpPost]
        public JsonResult DeleteExpense(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = ExpenseHeadViewModel.DeleteExpense(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Expense ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }



        // POST: Toggle Expense Head Status (Active/Inactive)
        [HttpPost]
        public JsonResult ExpenseStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = ExpenseHeadViewModel.ExpenseStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Expense Head ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }


        //----------ADD FEE TYPE--------
        public ActionResult AddFee()
        {
            return View();
        }

        // POST: Save Fee (Add or Update)
        [HttpPost]
        public ActionResult AddFee(AddFeeModel cmodel)
        {
            AllResponseMessage resp = AddFeeViewModel.SaveFee(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Get all Fee
        [HttpGet]
        public JsonResult GetAddFeeList()
        {
            List<AddFeeModel> FeeList = AddFeeViewModel.GetAllFeeList();
            return Json(new { data = FeeList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fetch Fee details for editing
        [HttpPost]
        public JsonResult EditFee(int id)
        {

            if (id <= 0)
                return Json(new { result = false, message = "Invalid Fee ID." }, JsonRequestBehavior.AllowGet);

            AddFeeModel smodel = AddFeeViewModel.EditFeeById(id);
            if (smodel != null && smodel.FeeID > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Fee not found." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Delete Fee
        [HttpPost]
        public JsonResult DeleteFee(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddFeeViewModel.DeleteFee(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Session ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Toggle Fee Status (Active/Inactive)
        [HttpPost]
        public JsonResult FeeStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddFeeViewModel.FeeStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fee ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }




        //---------- FEE STRUCTURE--------
        public ActionResult FeeStructure()
        {
            FeeStructureModel me = new FeeStructureModel();

            me.ClassNameList = AllCategoryListsModel.GetAllClass();
            me.FeeNameList = AllCategoryListsModel.GetAllFeeName();
            return View(me);
        }

        // POST: Save Fee Structure (Add or Update)
        [HttpPost]
        public ActionResult FeeStructure(FeeStructureModel cmodel)
        {
            AllResponseMessage resp = FeeStructureViewModel.SaveFeeStructure(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Get all Fee Structure
        [HttpGet]
        public JsonResult GetAddFeeStructureList()
        {
            List<FeeStructureModel> FeeStructureList = FeeStructureViewModel.GetAllFeeStructureList();
            return Json(new { data = FeeStructureList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fetch Fee Structure details for editing
        //[HttpPost]
        //public JsonResult EditFeeStructure(int id)
        //{

        //    if (id <= 0)
        //        return Json(new { result = false, message = "Invalid Fee Structure ID." }, JsonRequestBehavior.AllowGet);

        //    FeeStructureModel smodel = FeeStructureViewModel.EditFeeStructureById(id);
        //    if (smodel != null && smodel.FeeID > 0)
        //        return Json(smodel, JsonRequestBehavior.AllowGet);

        //    return Json(new { result = false, message = "Fee Structure not found." }, JsonRequestBehavior.AllowGet);
        //}

        // POST: Delete Fee Structure
        //[HttpPost]
        //public JsonResult DeleteFeeStructure(int id)
        //{
        //    if (id > 0)
        //    {
        //        AllResponseMessage resp = FeeStructureViewModel.DeleteFeeStructure(id);
        //        return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { result = false, message = "Invalid Fee Structure ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        //}

        // POST: Toggle Fee Structure Status (Active/Inactive)
        [HttpPost]
        public JsonResult FeeStructureStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = FeeStructureViewModel.FeeStructureStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fee ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }


        //---------- Add Fund--------
        public ActionResult AddFund()
        {
            return View();
        }

        // POST: Save Fund (Add or Update)
        [HttpPost]
        public ActionResult AddFund(AddFundModel cmodel)
        {
            AllResponseMessage resp = AddFundViewModel.SaveFund(cmodel);
            return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Get all Fund
        [HttpGet]
        public JsonResult GetAddFundList()
        {
            List<AddFundModel> FundList = AddFundViewModel.GetAllFundList();
            return Json(new { data = FundList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fetch Fund details for editing
        [HttpPost]
        public JsonResult EditFund(int id)
        {

            if (id <= 0)
                return Json(new { result = false, message = "Invalid Fund ID." }, JsonRequestBehavior.AllowGet);

            AddFundModel smodel = AddFundViewModel.EditFundById(id);
            if (smodel != null && smodel.FundID > 0)
                return Json(smodel, JsonRequestBehavior.AllowGet);

            return Json(new { result = false, message = "Fund not found." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Delete Fund
        [HttpPost]
        public JsonResult DeleteFund(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddFundViewModel.DeleteFund(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fund ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }

        // POST: Toggle Fund Status (Active/Inactive)
        [HttpPost]
        public JsonResult FundStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddFundViewModel.FundStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fund ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }





        //---------- Admission--------
        public ActionResult Admission()
        {
            AdmissionModel me = new AdmissionModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }


        [HttpPost]
        public ActionResult SaveAdmission(AdmissionModel model,
        HttpPostedFileBase AadhaarFrontImage,
        HttpPostedFileBase AadhaarBackImage)
        {
            try
            {
                using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                {

                    string frontImage = "";
                    string backImage = "";

                    // Save Front Image
                    if (AadhaarFrontImage != null)
                    {
                        string fileName = Path.GetFileName(AadhaarFrontImage.FileName);
                        string path = Server.MapPath("~/Uploads/" + fileName);
                        AadhaarFrontImage.SaveAs(path);

                        frontImage = "/Uploads/" + fileName;
                    }

                    // Save Back Image
                    if (AadhaarBackImage != null)
                    {
                        string fileName = Path.GetFileName(AadhaarBackImage.FileName);
                        string path = Server.MapPath("~/Uploads/" + fileName);
                        AadhaarBackImage.SaveAs(path);

                        backImage = "/Uploads/" + fileName;
                    }
                    // Check duplicate admission no
                    bool exists = db.tblAdmissions
                                    .Any(x => x.AdmissionNo == model.AdmissionNo);

                    if (exists)
                    {
                        TempData["ErrorMessage"] = "Duplicate Admission No not allowed!";
                        return RedirectToAction("CreateAdmission");
                    }
                    else
                    {
                        tblAdmission tbl = new tblAdmission()
                        {
                            AdmissionNo = model.AdmissionNo,
                            AdmissionDate = model.AdmissionDate,
                            ClassID = model.ClassID,
                            SectionID = model.SectionID,
                            SessionID = model.SessionID,
                            //ClassName = Convert.ToString(model.ClassList),
                            //SectionName = Convert.ToString(model.SectionList),
                            //SessionName = Convert.ToString(model.SessionList),
                            StudentName = model.StudentName,
                            DOB = model.DOB,
                            MotherTongue = model.MotherTongue,
                            BloodGroup = model.BloodGroup,
                            Gender = model.Gender,
                            AadhaarNo = model.AadhaarNo,
                            AadhaarFrontImage = Convert.ToString(model.AadhaarFrontImage),
                            AadhaarBackImage = Convert.ToString(model.AadhaarBackImage),
                            Nationality = model.Nationality,
                            Religion = model.Religion,
                            Caste = model.Caste,
                            Address = model.Address,
                            State = model.State,
                            FatherName = model.FatherName,
                            FatherOccupation = model.FatherOccupation,
                            FatherMobileNo = model.FatherMobileNo,
                            FatherAnnualIncome = model.FatherAnnualIncome,
                            MotherName = model.MotherName,
                            MotherOccupation = model.MotherOccupation,
                            MotherMobileNo = model.MotherMobileNo,
                            MotherAnnualIncome = model.MotherAnnualIncome
                        };
                        db.tblAdmissions.InsertOnSubmit(tbl);

                        db.SubmitChanges();
                    }
                }

                return Json(new { status = true });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }


        public ActionResult AdmissionList()
        {
            AdmissionListModel me = new AdmissionListModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }

        public ActionResult PromoteStudent()
        {
            PromoteStudentModel me = new PromoteStudentModel();
            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }



        [HttpPost]
        public JsonResult PromoteStudentSave(int admissionId, int classId, int sectionId, int sessionId)
        {
            var student = db.tblAdmissions.FirstOrDefault(x => x.AdmissionID == admissionId);

            if (student != null)
            {
                student.ClassID = classId;
                student.SectionID = sectionId;
                student.SessionID = sessionId;

                db.SubmitChanges();

                return Json(new { result = true, message = "Student Promoted Successfully!" });
            }

            return Json(new { result = false, message = "Promotion Failed!" });
        }

        [HttpPost]
        public JsonResult DeleteAdmissionList(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AdmissionListViewModel.DeleteAdmission(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Expense ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GetAdmissionList(string admissionNo, int? classId, int? sectionId, int? sessionId)
        {
            using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
            {

                var query = db.tblAdmissions.AsQueryable();

                // Admission No Filter
                if (!string.IsNullOrWhiteSpace(admissionNo))
                {
                    query = query.Where(x => x.AdmissionNo.Contains(admissionNo));
                }

                // Class Filter
                if (classId != null && classId > 0)
                {
                    query = query.Where(x => x.ClassID == classId);
                }

                // Section Filter
                if (sectionId != null && sectionId > 0)
                {
                    query = query.Where(x => x.SectionID == sectionId);
                }

                // Session Filter
                if (sessionId != null && sessionId > 0)
                {
                    query = query.Where(x => x.SessionID == sessionId);
                }

                var result = (from a in query
                              join c in db.tblClassMasters on a.ClassID equals c.ClassId
                              join s in db.tblSectionMasters on a.SectionID equals s.SectionID
                              join ses in db.tblSessionMasters on a.SessionID equals ses.SessionID
                              join f in db.tblFeeStructureMasters on c.ClassId equals f.ClassNameID

                              orderby a.AdmissionID
                              select new AdmissionListModel
                              {
                                  AdmissionListID = a.AdmissionID,
                                  ClassID = (int)a.ClassID,
                                  SectionID = (int)a.SectionID,
                                  SessionID = (int)a.SessionID,
                                  AdmissionNo = a.AdmissionNo,
                                  StudentName = a.StudentName,
                                  FatherName = a.FatherName,
                                  FatherMobileNo = a.FatherMobileNo,
                                  ClassName = c.ClassName,
                                  SectionName = s.SectionName,
                                  SessionName = ses.SessionName,
                                  Fee = Convert.ToString(f.Amount),
                                  AdmissionDate = string.Format("{0:dd-MM-yyyy}", a.AdmissionDate)
                              }).ToList();
                return Json(new { data = result }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult CollectFee()
        {
            CollectFeeModel me = new CollectFeeModel();

            me.AdmissionNoList = AllCategoryListsModel.GetAllCollectFee();
            return View(me);
        }

        public JsonResult GetStudentDetails(int admissionID)
        {
            using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
            {
                var student = (from s in db.tblAdmissions
                               join c in db.tblClassMasters on s.ClassID equals c.ClassId
                               join d in db.tblSectionMasters on s.SectionID equals d.SectionID
                               join e in db.tblSessionMasters on s.SessionID equals e.SessionID
                               where s.AdmissionID == admissionID
                               select new
                               {
                                   StudentName = s.StudentName,
                                   ClassName = c.ClassName,
                                   SectionName = d.SectionName,
                                   SessionName = e.SessionName
                               }).FirstOrDefault();

                return Json(student, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult SaveCollectFee(CollectFeeModel model)
        {
            using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
            {
                tblCollectFee obj = new tblCollectFee();

                obj.AdmissionID = model.AdmissionID;
                obj.PaymentMode = model.PaymentMode;
                obj.AmountPaid = model.AmountPaid;
                obj.PaymentsDate = DateTime.Now;

                db.tblCollectFees.InsertOnSubmit(obj);
                db.SubmitChanges();

                return Json(new { success = true });
            }
        }

        

        public ActionResult CollectionList()
        {
            CollectionListModel me = new CollectionListModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            me.FeeHeadList = AllCategoryListsModel.GetAllFeeHead();
            return View(me);
        }

        [HttpGet]
        public JsonResult GetCollectionList()
        {
            List<CollectionListModel> CollectionList = CollectionListViewModel.getAllCollectionList();
            return Json(new { data = CollectionList }, JsonRequestBehavior.AllowGet);
        }




        //public JsonResult GetCollectionList(string PaymentType, int? ClassID, int? SectionID, int? SessionID, int? FeeHeadID)
        //{
        //    var data = db.tblAdmissions.AsQueryable();
        //    var d = db.tblCollectFees.AsQueryable();
        //    var e = db.tblFeeMasters.AsQueryable();

        //    if (!string.IsNullOrEmpty(PaymentType))
        //        d =d.Where(x => x.PaymentMode == PaymentType);

        //    if (ClassID.HasValue)
        //        data = data.Where(x => x.ClassID == ClassID);

        //    if (SectionID.HasValue)
        //        data = data.Where(x => x.SectionID == SectionID);

        //    if (SessionID.HasValue)
        //        data = data.Where(x => x.SessionID == SessionID);

        //    if (FeeHeadID.HasValue)
        //        e = e.Where(x => x.FeeID == FeeHeadID);

        //    return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult DueFee()
        {
            DueFeeModel me = new DueFeeModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }


        public ActionResult IssueCertificate()
        {
            IssueCertificateModel me = new IssueCertificateModel();

            me.AdmissionNoList = AllCategoryListsModel.GetAllCollectFee();
            return View(me);
        }

        
        public JsonResult GetStudentDetail(int admissionId)
        {
            using (var db = new SchoolManagementDBDataContext())
            {
                var data = (from a in db.tblAdmissions
                            join c in db.tblClassMasters on a.ClassID equals c.ClassId
                            join s in db.tblSectionMasters on a.SectionID equals s.SectionID
                            join d in db.tblSessionMasters on a.SessionID equals d.SessionID
                            where a.AdmissionID == admissionId
                            select new
                            {
                                Name = a.StudentName,
                                FatherName = a.FatherName,
                                DOB = string.Format("{0:dd-MM-yyyy}", a.DOB),
                                Session = d.SessionName,
                                Class = c.ClassName,
                                Section = s.SectionName
                            }).FirstOrDefault();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult BonafideCertificate(int admissionId, string issueDate)
        {
            return View();
        }



        public ActionResult AttendanceCertificate(int admissionId, string issueDate)
        {
            return View();
        }

        public ActionResult ConductCertificate(int admissionId, string issueDate)
        {
            return View();
        }

        

        public ActionResult Certificate(int id)
        {
            IssueCertificateModel model = new IssueCertificateModel();

            using (var db = new SchoolManagementDBDataContext())
            {
                var data = (from a in db.tblAdmissions
                            join c in db.tblClassMasters on a.ClassID equals c.ClassId
                            join s in db.tblSessionMasters on a.SessionID equals s.SessionID
                            where a.AdmissionID == id
                            select new IssueCertificateModel
                            {
                                AdmissionID = a.AdmissionID,
                                StudentName = a.StudentName,
                                FatherName = a.FatherName,
                                ClassName = c.ClassName,
                                AcademicYear = s.SessionName,
                                DOB = string.Format("{0:dd-MM-yyyy}", a.DOB),
                                Character = "Good",
                               
                            }).FirstOrDefault();

                model = data;
            }

            return View(model);
        }






        public ActionResult Expenses()
        {
            ExpensesModel me = new ExpensesModel();

            me.ExpenseHeadList = AllCategoryListsModel.GetAllExpenseHead();
            return View(me);
        }

        // for save


        [HttpPost]
        public ActionResult Expenses(ExpensesModel model)
        {
            try
            {
                string fileName = "";

                // Upload file
                if (model.BillImage != null)
                {
                    fileName = Path.GetFileName(model.BillImage.FileName);

                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    string fullPath = Path.Combine(path, fileName);
                    model.BillImage.SaveAs(fullPath);
                }

                using (var db = new SchoolManagementDBDataContext())
                {
                    tblExpense obj = new tblExpense();

                    obj.ExpensesID = model.ExpensesID;
                    obj.ExpenseHeadID = model.ExpenseHeadID;
                    obj.BillDate = Convert.ToDateTime(model.BillDate);
                    obj.BillNo = model.BillNo;
                    obj.BillImage = fileName;
                    obj.Amount = model.Amount;
                    obj.PersonName = model.PersonName;
                    obj.PayMode = model.PayMode;
                    obj.Remark = model.Remark;

                    db.tblExpenses.InsertOnSubmit(obj);
                    db.SubmitChanges();
                }

                return Json(new { Status = true, Message = "Saved Successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }


        [HttpGet]
        public JsonResult GetExpenseList()
        {
            List<ExpensesModel> ExpenseList = ExpensesViewModel.getAllExpenseList();
            return Json(new { data = ExpenseList }, JsonRequestBehavior.AllowGet);
        }

        //POST: Delete Expense
        [HttpPost]
        public JsonResult DeleteExpenses(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = ExpensesViewModel.DeleteExpense(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Expense ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddIncome()
        {
            AddIncomeModel me = new AddIncomeModel();

            me.FundTypeList = AllCategoryListsModel.GetAllFundType();
            return View(me);
        }

        [HttpPost]
        public ActionResult AddIncome(AddIncomeModel model)
        {
            AllResponseMessage resp = new AllResponseMessage();

            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "";

                    // File Upload
                    if (model.TransactionImage != null && model.TransactionImage.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(model.TransactionImage.FileName);

                        string folderPath = Server.MapPath("~/Uploads/");

                        // Create folder if not exists
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        string fullPath = Path.Combine(folderPath, fileName);

                        model.TransactionImage.SaveAs(fullPath);
                    }

                    using (var db = new SchoolManagementDBDataContext())
                    {
                        tblAddIncome obj = new tblAddIncome();

                        obj.FundID = model.FundID;
                        obj.PayDate = Convert.ToDateTime(model.PayDate);
                        obj.TransactionImage = fileName;
                        obj.Amount = Convert.ToInt32(model.Amount);
                        obj.PersonName = model.PersonName;
                        obj.PayMode = model.PayMode;
                        obj.Remark = model.Remark;

                        db.tblAddIncomes.InsertOnSubmit(obj);
                        db.SubmitChanges();
                    }

                    resp.Status = true;
                    resp.Message = "Income Saved Successfully";
                }
                else
                {
                    resp.Status = false;
                    resp.Message = "Model validation failed";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }

            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetIncomeList()
        {
            List<AddIncomeModel> IncomeList = AddIncomeViewModel.getAllIncomeList();
            return Json(new { data = IncomeList }, JsonRequestBehavior.AllowGet);
        }

        //POST: Delete Add Income
        [HttpPost]
        public JsonResult DeleteIncome(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = AddIncomeViewModel.DeleteAddIncome(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fund ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(AddStaffModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
                    {
                        tblAddStaff obj = new tblAddStaff();

                        // ================= BASIC INFO =================

                        obj.EmpName = model.EmpName;
                        obj.EmpFatherName = model.EmpFatherName;
                        obj.Gender = model.Gender;
                        obj.DOB = model.DOB;
                        obj.MobileNo = model.MobileNo;
                        obj.Designation = model.Designation;
                        obj.Email = model.Email;
                        obj.PANNo = model.PANNo;
                        obj.AadhaarNo = model.AadhaarNo;

                        // ================= ADDRESS =================

                        obj.PresentAddress = model.PresentAddress;
                        obj.PresentCityName = model.PresentCityName;
                        obj.PresentDistrictName = model.PresentDistrictName;
                        obj.PresentPincode = model.PresentPincode;

                        obj.CorAddress = model.CorAddress;
                        obj.CorCityName = model.CorCityName;
                        obj.CorDistrictName = model.CorDistrictName;
                        obj.CorPincode = model.CorPincode;

                        // ================= SALARY =================

                        obj.GrossSalary = model.GrossSalary;
                        obj.BasicSalary = model.BasicSalary;
                        obj.HRA = model.HRA;
                        obj.TravelAllowance = model.TravelAllowance;
                        obj.ConveyanceAllowance = model.ConveyanceAllowance;
                        obj.SpecialAllowance = model.SpecialAllowance;
                        obj.FoodAllowance = model.FoodAllowance;

                        obj.EPF = model.EPF;
                        obj.MedicalAllowance = model.MedicalAllowance;
                        obj.ProfessionalTax = model.ProfessionalTax;
                        obj.PFCount = model.PFCount;
                        obj.ESIC = model.ESIC;

                        obj.NetGrossSalary = model.NetGrossSalary;
                        obj.TotalDeduction = model.TotalDeduction;
                        obj.NetPay = model.NetPay;

                        // ================= BANK =================

                        obj.BankHolderName = model.BankHolderName;
                        obj.AccountNo = model.AccountNo;
                        obj.BankName = model.BankName;
                        obj.BranchName = model.BranchName;
                        obj.IFSCCode = model.IFSCCode;
                        obj.Status = true;
                        // ================= FILE UPLOAD =================

                        string path = Server.MapPath("~/Uploads/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        // Profile Image
                        if (model.ProfileImage != null)
                        {
                            string fileName = Path.GetFileName(model.ProfileImage.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.ProfileImage.SaveAs(fullPath);
                            obj.ProfileImage = fileName;
                        }

                        // Aadhaar Front
                        if (model.AadhaarFrontImage != null)
                        {
                            string fileName = Path.GetFileName(model.AadhaarFrontImage.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.AadhaarFrontImage.SaveAs(fullPath);
                            obj.AadhaarFrontImage = fileName;
                        }

                        // Aadhaar Back
                        if (model.AadhaarBackImage != null)
                        {
                            string fileName = Path.GetFileName(model.AadhaarBackImage.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.AadhaarBackImage.SaveAs(fullPath);
                            obj.AadhaarBackImage = fileName;
                        }

                        // PAN Card
                        if (model.PANCard != null)
                        {
                            string fileName = Path.GetFileName(model.PANCard.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.PANCard.SaveAs(fullPath);
                            obj.PANCard = fileName;
                        }

                        // Document
                        if (model.Document != null)
                        {
                            string fileName = Path.GetFileName(model.Document.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.Document.SaveAs(fullPath);
                            obj.Document = fileName;
                            obj.DocumentType = model.DocumentType;
                        }

                        // Passbook
                        if (model.PassbookImage != null)
                        {
                            string fileName = Path.GetFileName(model.PassbookImage.FileName);
                            string fullPath = Path.Combine(path, fileName);
                            model.PassbookImage.SaveAs(fullPath);
                            obj.PassbookImage = fileName;
                        }

                        // ================= SAVE =================

                        db.tblAddStaffs.InsertOnSubmit(obj);
                        db.SubmitChanges();

                        return Json(new { Status = true, Message = "Staff Saved Successfully" });
                    }
                }

                return Json(new { Status = false, Message = "Validation Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }



        public ActionResult StaffList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetStaffList()
        {
            List<StaffListModel> StaffList = StaffListViewModel.getAllStaffList();
            return Json(new { data = StaffList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteStaffList(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = StaffListViewModel.DeleteStaffList(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Expense ID. Deletion failed." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult StaffListStatus(int id)
        {
            if (id > 0)
            {
                AllResponseMessage resp = StaffListViewModel.StaffListStatus(id);
                return Json(new { result = resp.Status, message = resp.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "Invalid Fee ID. Status update failed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StaffSalary()
        {
            StaffSalaryModel me = new StaffSalaryModel();

            me.EmployeeSalaryList = AllCategoryListsModel.GetAllStaffSalary();
            return View(me);
        }

        [HttpGet]
        public JsonResult GetStaffDetails(int empId)
        {
            using (SchoolManagementDBDataContext db = new SchoolManagementDBDataContext())
            {
                var data = db.tblAddStaffs
                    .Where(x => x.AddStaffID == empId)
                    .Select(x => new
                    {
                        x.Designation,
                        x.GrossSalary,
                        x.BasicSalary,
                        x.HRA,
                        x.TravelAllowance,
                        x.ConveyanceAllowance,
                        x.SpecialAllowance,
                        x.FoodAllowance,
                        x.EPF,
                        x.MedicalAllowance,
                        x.ProfessionalTax,
                        x.PFCount,
                        x.ESIC,
                        x.NetGrossSalary,
                        x.TotalDeduction,
                        x.NetPay,
                        x.BankName,
                        x.AccountNo,
                        x.IFSCCode,
                        x.DOB
                    })
                    .FirstOrDefault();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult SalaryList()
        {
            return View();
        }

        public ActionResult AdmissionReport()
        {
            AdmissionReportModel me = new AdmissionReportModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }

        [HttpGet]
        public JsonResult GetAdmissionReportList()
        {
            List<AdmissionReportModel> AdmissionReportList = AdmissionReportViewModel.getAllAdmissionReportList();
            return Json(new { data = AdmissionReportList }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DefaultFeeReport()
        {
            DefaultFeeReportModel me = new DefaultFeeReportModel();

            me.ClassList = AllCategoryListsModel.GetAllClass();
            me.SectionList = AllCategoryListsModel.GetAllSection();
            me.SessionList = AllCategoryListsModel.GetAllSession();
            return View(me);
        }

        public ActionResult ExpensesReport()
        {
            return View();
        }

        
        public ActionResult ProfitandLoss()
        {
            return View();
        }
    }
}