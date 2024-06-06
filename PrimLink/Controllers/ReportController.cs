using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Implementation;
using Service.Interface;
using Model.Common.Utilities;
using System;
using Model.Entity;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Repository.Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using PrimLink.Helper;

namespace PrimLink.Controllers
{
    public class ReportController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<ReportController> _logger;
        private readonly IUserService _userService;
        private readonly IGeneralInformationService _generalInformationService;
        private readonly ISampleInformationService _sampleInformationService;
        private readonly ISpecificationsInstructionService _specificationsInstructionService;
        private readonly IInspectionScopeAndAQLService _inspectionScopeAndAQLService;
        private readonly IInspectorAllocationService _inspectorAllocationService;
        private readonly IVendorService _vendorService;
        private readonly IFactoryService _factoryService;
        private readonly IUserFormService _userFormService;
        private readonly IReferenceService _referenceService;
        private readonly IItemDatumService _itemDatumService;
        private readonly ISamplingInformationService _samplingInformationService;
        private readonly IItemRemarkDatumService _itemRemarkDatumService;
        private readonly IItemAQLDefectsAndRemarkService _itemAQLDefectsAndRemarkService;
        private readonly IAQLDefectService _aQLDefectService;
        private readonly IShipperCartonPackagingService _shipperCartonPackagingService;
        private readonly IInnerPackagingService _innerPackagingService;
        private readonly IRetailPackagingService _retailPackagingService;
        private readonly IItemOverallService _iltemOverallService;
        private readonly IOnSiteTestResultService _onSiteTestResultService;
        private readonly IItemOtherPhotoService _itemOtherPhotoService;
        int ReferenceId = 0;
        //private string connectionString = "Data Source=DESKTOP-42OIRKH;Initial Catalog=PrimLinkDB;user id=sa;password=123;Integrated Security=True;Encrypt=False";
        //private string connectionString = "data source = 10.1.1.241; initial catalog = HibaTest; user id = qa; password=abcd@1234;Integrated Security=True;Encrypt=False;";
        private string connectionString = "data source=10.1.1.241;initial catalog=HibaTest;user id=qa;password=abcd@1234; MultipleActiveResultSets=true;Trusted_Connection=False;";
        #endregion

        public ReportController(ILogger<ReportController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _generalInformationService = new GeneralInformationService();
            _sampleInformationService = new SampleInformationService();
            _specificationsInstructionService = new SpecificationsInstructionService();
            _inspectionScopeAndAQLService = new InspectionScopeAndAQLService();
            _inspectorAllocationService = new InspectorAllocationService();
            _userFormService = new UserFormService();
            _referenceService = new ReferenceService();
            _vendorService = new VendorService();
            _factoryService = new FactoryService();
            _itemDatumService = new ItemDatumService();
            _samplingInformationService = new SamplingInformationService();
            _itemRemarkDatumService = new ItemRemarkDatumService();
            _itemAQLDefectsAndRemarkService = new ItemAQLDefectsAndRemarkService();
            _aQLDefectService = new AQLDefectService();
            _shipperCartonPackagingService = new ShipperCartonPackagingService();
            _innerPackagingService = new InnerPackagingService();
            _retailPackagingService = new RetailPackagingService();
            _iltemOverallService = new ItemOverallService();
            _onSiteTestResultService = new OnSiteTestResultService();
            _itemOtherPhotoService = new ItemOtherPhotoService();


        }

        public IActionResult Index(int userId, bool isAdmin, int userFormId)
        {
            string inspectorName = string.Empty;
            var userRole = HttpContext.Session.GetString("role");
            if (userFormId == 0)
            {
                var newSpecification = new InspectionScopeAndAQLModel();
                newSpecification.UserId = userId;
                newSpecification.UserFormId = userFormId;
                newSpecification.IsAdmin = isAdmin;
                if (!isAdmin)
                {
                    newSpecification.IsApproved = false;
                }
                if (userRole == "10003")
                {
                    return PartialView(ADD_EDIT_REPORT_VIEW_INSPECTOR, newSpecification);
                }
                else
                {
                    return PartialView(ADD_EDIT_REPORT_VIEW, newSpecification);
                }
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    var inspector = _inspectorAllocationService.GetInspectorAllocationByUserFormId(userFormId);
                    if (inspector != null)
                    {
                        var inspectorModel = _userService.GetUserById(Convert.ToInt32(inspector.InspectorId));
                        inspectorName = inspectorModel.FirstName + " " + inspectorModel.LastName;
                    }
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var generalInfo = _generalInformationService.GetGeneralInformationByUserFormId(userFormId);
                    if (generalInfo != null)
                    {
                        generalInfo.References = _referenceService.GetReferenceByGeneralInformationId(generalInfo.Id);
                        generalInfo.IsAdmin = isAdmin;
                        generalInfo.AllocatedTo = inspectorName;
                        if (!isAdmin)
                        {
                            generalInfo.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_REPORT_VIEW_INSPECTOR, generalInfo);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_REPORT_VIEW, generalInfo);
                        }
                    }
                    else
                    {
                        var newSpecification = new InspectionScopeAndAQLModel();
                        newSpecification.UserId = userId;
                        newSpecification.UserFormId = userFormId;
                        newSpecification.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            newSpecification.IsApproved = userForm.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_REPORT_VIEW_INSPECTOR, newSpecification);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_REPORT_VIEW, newSpecification);
                        }
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        #region Get View Report
        /// <summary>
        /// Get View Report
        /// </summary>
        /// <returns></returns>
        public IActionResult GetViewReport(int id)
        {
            var reference = _referenceService.GetReferenceById(id);
            if (reference != null)
            {
                var generalInfo = _generalInformationService.GetGeneralInformationById((int)reference.GeneralInformationId);
                if (generalInfo != null)
                {
                    var vendor = _vendorService.GetVendorByGeneralInformationId(generalInfo.Id);
                    var factory = _factoryService.GetFactoryByGeneralInformationId(generalInfo.Id);
                    var sampleInfo = _sampleInformationService.GetSampleInformationByUserFormId((int)generalInfo.UserFormId);
                    var specificationInst = _specificationsInstructionService.GetSpecificationsInstructionByUserFormId((int)generalInfo.UserFormId);
                    var inspection = _inspectionScopeAndAQLService.GetInspectionScopeAndAQLByUserFormId((int)generalInfo.UserFormId);
                }
            }
            return View(VIEW_REPORT_VIEW);
            //return View(COMING_SOON_VIEW);
        }
        #endregion

        #region Get Fill Report
        /// <summary>
        /// Get Fill Report
        /// </summary>
        /// <returns></returns>
        public IActionResult GetFillReport(int id)
        {
            //return View(COMING_SOON_VIEW);
            return View(FILL_REPORT_VIEW);
        }
        #endregion

        #region Get Admin View Report
        /// <summary>
        /// Get Admin View Report
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAdminViewReport(int id)
        {
            return View(COMING_SOON_VIEW);
            //return View(VIEW_REPORT_VIEW);
        }
        #endregion

        #region Get Admin Fill Report
        /// <summary>
        /// Get Admin Fill Report
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAdminFillReport(int id)
        {
            //return View(COMING_SOON_VIEW);
            return View(FILL_REPORT_VIEW);
        }
        #endregion

        public IActionResult ViewFillReport(int id)
        {
            ReportModel model = new ReportModel();

            DataSet ds = GetAllData(id);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null)
                {
                    List<ImportantRemark> obj = new List<ImportantRemark>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        obj.Add(new ImportantRemark { Id = (int)row["Id"], ReferenceId = (int)row["ReferenceId"], RemarkType = row["RemarkType"].ToString(), Description = row["Description"].ToString(), FilePath = row["FilePath"].ToString() });
                    }

                    model.listImportantRemark = obj;
                }

                if (ds.Tables[1] != null)
                {
                    List<CustomerSpecialCheckpoint> obj = new List<CustomerSpecialCheckpoint>();
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        obj.Add(new CustomerSpecialCheckpoint { Id = (int)row["Id"], ReferenceId = (int)row["ReferenceId"], Type = row["Type"].ToString(), Result = row["Result"].ToString(), Description = row["Description"].ToString(), FilePath = row["FilePath"].ToString(), OverallResult = row["OverallResult"].ToString() });
                    }

                    model.listCustomerSpecialCheckpoint = obj;
                }

                if (ds.Tables[2] != null)
                {
                    List<SamplingInformation> obj = new List<SamplingInformation>();
                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        obj.Add(new SamplingInformation { Id = (int)row["Id"], ReferenceId = (int)row["ReferenceId"], PONumber = row["PONumber"].ToString(), ModelNumber = row["ModelNumber"].ToString(), SampleSizeFromPackedCTNS = Convert.ToDecimal(row["SampleSizeFromPackedCTNS"]), SampleSizeFromFinishedUnPacked = Convert.ToDecimal(row["SampleSizeFromFinishedUnPacked"]), InspectedCartonCTN = Convert.ToDecimal(row["InspectedCartonCTN"]), InspectedCartonNumber = row["InspectedCartonNumber"].ToString(), TotalSampleSizePackedCTNS = (int)row["TotalSampleSizePackedCTNS"], TotalSampleSizeFinishedUnpacked = (int)row["TotalSampleSizeFinishedUnpacked"], TotalInspectedCartonCTN = (int)row["TotalInspectedCartonCTN"], FactoryAllowsDrawingSamples = row["FactoryAllowsDrawingSamples"].ToString(), QuantityAvailableForSampling = row["QuantityAvailableForSampling"].ToString() });
                    }

                    model.listSamplingInformation = obj;
                }

                if (ds.Tables[3] != null)
                {
                    List<InspectionStandardResult> obj = new List<InspectionStandardResult>();
                    foreach (DataRow row in ds.Tables[3].Rows)
                    {
                        obj.Add(new InspectionStandardResult { ID = (int)row["ID"], POorModelNo = row["POorModelNo"].ToString(), PictureNo = Convert.ToInt32(row["PictureNo"]), PhotoPath = row["PhotoPath"].ToString(), DefectDescription = row["DefectDescription"].ToString(), Critical = Convert.ToInt32(row["Critical"]), Major = Convert.ToInt32(row["Major"]), Minor = Convert.ToInt32(row["Minor"]), SampleSizeCritical = Convert.ToInt32(row["SampleSizeCritical"]), SampleSizeMajor = Convert.ToInt32(row["SampleSizeMajor"]), SampleSizeMinor = Convert.ToInt32(row["SampleSizeMinor"]), TotalFoundDefectsCritical = Convert.ToInt32(row["TotalFoundDefectsCritical"]), TotalFoundDefectsMajor = Convert.ToInt32(row["TotalFoundDefectsMajor"]), TotalFoundDefectsMinor = Convert.ToInt32(row["TotalFoundDefectsMinor"]), AQLAllowedDefectsCritical = Convert.ToInt32(row["AQLAllowedDefectsCritical"]), AQLAllowedDefectsMajor = Convert.ToInt32(row["AQLAllowedDefectsMajor"]), AQLAllowedDefectsMinor = Convert.ToInt32(row["AQLAllowedDefectsMinor"]), AQLResults = row["AQLResults"].ToString(), GeneralDefectNotIncludedAQLResultAbove = row["GeneralDefectNotIncludedAQLResultAbove"].ToString(), GeneralDefectDescription = row["GeneralDefectDescription"].ToString(), NonConformityFound = row["NonConformityFound"].ToString(), NonConformityRemark = row["NonConformityRemark"].ToString() });
                    }

                    model.listInspectionStandardResult = obj;
                }

                if (ds.Tables[4] != null)
                {
                    List<YourProduct> obj = new List<YourProduct>();
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        obj.Add(new YourProduct { Id = (int)row["Id"], ReferenceId = (int)row["ReferenceId"], Path = row["Path"].ToString() });
                    }

                    model.listYourProduct = obj;
                }

            }

            return View(VIEW_FILLREPORT_VIEW, model);
        }


        [DisableRequestSizeLimit]
        [HttpPost]
        public ActionResult SaveReport1(List<ItemDatumModel> ItemData, List<SamplingInformationModel> SamplingInformationData, List<ItemRemarkDatumModel> ItemRemarkListData, List<ItemAQLDefectsAndRemarkModel> ItemAQLDefect, List<AQLDefectModel> AQLDefect, List<ShipperCartonPackagingModel> ShipperCartonPackaging, List<InnerPackagingModel> InnerPackaging, List<RetailPackagingModel> RetailPackaging, List<ItemOverallModel> ItemOverall, List<OnSiteTestResultModel> OnSiteTestResult, List<ItemOtherPhotoModel> ItemOtherPhotos, List<InspectionStandardResult> InspectionStandardResults, string id, IEnumerable<IFormFile> files)
        {
            ReferenceId = Convert.ToInt32(id);
            // string id = Request.Form["id"];
            SaveItemData(ItemData);
            SaveSamplingInformation(SamplingInformationData);
            SaveItemRemarkListData(ItemRemarkListData);
            SaveItemAQLDefect(ItemAQLDefect);
            SaveAQLDefect(AQLDefect);
            SaveShipperCartonPackaging(ShipperCartonPackaging);
            SaveInnerPackaging(InnerPackaging);
            SaveRetailPackaging(RetailPackaging);
            SaveItemOverall(ItemOverall);
            SaveOnSiteTestResult(OnSiteTestResult);
            //SaveItemOtherPhotos(ItemOtherPhotos);



            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            foreach (var formFile in Request.Form.Files)
            {
                if (formFile.Length > 0)
                {
                    // Access file properties
                    string fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    string path = Path.Combine(uploadsDirectory, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }



            return View();

        }

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/Report/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/ReportInspector/";
        private const string VIEW_FOLDER_COMING_SOON = "~/Views/ComingSoon/";
        private const string COMING_SOON_VIEW = VIEW_FOLDER_COMING_SOON + "Index.cshtml";
        private const string ADD_EDIT_REPORT_VIEW = VIEW_FOLDER + "Index.cshtml";
        private const string VIEW_REPORT_VIEW = VIEW_FOLDER + "ViewReport.cshtml";
        private const string VIEW_FILLREPORT_VIEW = VIEW_FOLDER + "ViewFillReport.cshtml";

        private const string FILL_REPORT_VIEW = VIEW_FOLDER + "FillReport.cshtml";
        private const string ADD_EDIT_REPORT_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "Index.cshtml";
        private const string VIEW_REPORT_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "ViewReport.cshtml";
        private const string FILL_REPORT_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "FillReport.cshtml";
        private const string REPORT_SAVED = "Report Information saved successfully";
        private const string REPORT_UPDATED = "Report Information updated successfully";
        private const string IMAGE_PATH_SPLIT = "/";
        private const string TEMP_FILE_PATH = "temp_files";
        private const string FOLDER = "Lease";
        private const string REQUIRED_FIELD = "Required field";
        private const string FILE_PATH = "images";
        private const string UPDATE_URL = "AzureBlobSetup:UploadURL";
        private const string DELETE_URL = "AzureBlobSetup:DeleteURL";
        private const string ACCESS_TOKEN = "AzureBlobSetup:AccessToken";
        private const string MIME_TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private const string FILE_EXTENSION = "pdf";
        private const string ADD_FILES = "AddFiles";
        private const string IMAGES = "images";
        private const string DOCUMENTS = "documents";
        private const string JPEG_SERVER_PATH = "data:image/jpeg;base64,";
        private const string PNG_SERVER_PATH = "data:image/png;base64,";
        private const string JPG = ".jpg";
        private const string JPEG = ".jpeg";
        #endregion


        [DisableRequestSizeLimit]
        [HttpPost]
        //public ActionResult SaveReport(List<YourProduct> YourProducts, List<ImportantRemark> ImportantRemarks, List<CustomerSpecialCheckpoint> customerSpecialCheckPoints, List<SamplingInformation> SamplingInformation2, List<DefectPhoto> DefectPhotos, List<InspectionStandardResult> InspectionStandardResults, List<BookingRequirementsResult> BookingRequirementsResults, string id, IEnumerable<IFormFile> files)
        public ActionResult SaveReport(List<BookingRequirementsResult> BookingRequirementsResults, string id, IEnumerable<IFormFile> files)
        {
            ReferenceId = Convert.ToInt32(id);
            SaveBookingRequirementsResults(BookingRequirementsResults);

            //SaveImportantRemarks(ImportantRemarks);
            //SaveCustomerSpecialCheckPoints(customerSpecialCheckPoints);
            //SaveSamplingInformation(SamplingInformation2);
            //SaveInspectionStandardResults(InspectionStandardResults);


            //SaveBookingRequirementsResults(BookingRequirementsResults);
            //SaveYourProduct(YourProducts);
            //SaveDefectPhotos(DefectPhotos);

            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            foreach (var formFile in Request.Form.Files)
            {
                if (formFile.Length > 0)
                {
                    // Access file properties
                    string fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    string path = Path.Combine(uploadsDirectory, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }



            return View();
        }


        public DataSet GetAllData(int refrenceID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllData";
            cmd.Parameters.Add("@refrenceID", SqlDbType.Int).Value = refrenceID;
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.Connection = conn;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);
                adpt.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Dispose();
            }
        }

        //
        public void SaveYourProduct(List<YourProduct> yourProducts)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (YourProduct yourProduct in yourProducts)
                {
                    SqlCommand command;

                    if (yourProduct.Id > 0)
                    {
                        // Update existing record
                        string updateQuery = @"UPDATE YourProduct 
                                       SET ReferenceId = @ReferenceId, 
                                           Path = @Path
                                       WHERE Id = @Id";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@Path", (object)yourProduct.Path ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", yourProduct.Id);
                    }
                    else
                    {
                        // Insert new record
                        string insertQuery = @"INSERT INTO YourProduct (ReferenceId, Path) 
                                       VALUES (@ReferenceId, @Path)";
                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@Path", (object)yourProduct.Path ?? DBNull.Value);
                    }

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }


        public void SaveImportantRemarks(List<ImportantRemark> importantRemarks)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (ImportantRemark importantRemark in importantRemarks)
                {
                    SqlCommand command;

                    if (importantRemark.Id > 0)
                    {
                        // Update existing record
                        string updateQuery = @"UPDATE ImportantRemarks 
                           SET ReferenceId = @ReferenceId, 
                               RemarkType = @RemarkType, 
                               Description = @Description, 
                               FilePath = @FilePath, 
                               CreatedBy = @CreatedBy, 
                               CreatedDate = @CreatedDate 
                           WHERE Id = @Id";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@RemarkType", (object)importantRemark.RemarkType ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)importantRemark.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FilePath", (object)importantRemark.FilePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedBy", (object)importantRemark.CreatedBy ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedDate", (object)importantRemark.CreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", importantRemark.Id);
                    }
                    else
                    {
                        // Insert new record
                        string insertQuery = @"INSERT INTO ImportantRemarks (ReferenceId, RemarkType, Description, FilePath, CreatedBy, CreatedDate) 
                           VALUES (@ReferenceId, @RemarkType, @Description, @FilePath, @CreatedBy, @CreatedDate)";
                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@RemarkType", (object)importantRemark.RemarkType ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)importantRemark.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FilePath", (object)importantRemark.FilePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedBy", (object)importantRemark.CreatedBy ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedDate", (object)importantRemark.CreatedDate ?? DBNull.Value);
                    }


                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }


        public void SaveCustomerSpecialCheckPoints(List<CustomerSpecialCheckpoint> customerSpecialCheckpoints)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (CustomerSpecialCheckpoint customerSpecialCheckpoint in customerSpecialCheckpoints)
                {
                    SqlCommand command;

                    if (customerSpecialCheckpoint.Id > 0)
                    {
                        // Update existing record
                        string updateQuery = @"UPDATE CustomerSpecialCheckpoints 
                   SET ReferenceId = @ReferenceId, 
                       Type = @Type, 
                       Result = @Result, 
                       Description = @Description, 
                       FilePath = @FilePath, 
                       OverallResult = @OverallResult, 
                       CreatedBy = @CreatedBy, 
                       CreatedDate = @CreatedDate 
                   WHERE Id = @Id";
                        command = new SqlCommand(updateQuery, connection);
                        //command.Parameters.AddWithValue("@ReferenceId", (object)customerSpecialCheckpoint.ReferenceId ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@Type", (object)customerSpecialCheckpoint.Type ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Result", (object)customerSpecialCheckpoint.Result ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)customerSpecialCheckpoint.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FilePath", (object)customerSpecialCheckpoint.FilePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OverallResult", (object)customerSpecialCheckpoint.OverallResult ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedBy", (object)customerSpecialCheckpoint.CreatedBy ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedDate", (object)customerSpecialCheckpoint.CreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", customerSpecialCheckpoint.Id);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(customerSpecialCheckpoint.Result))
                        {
                            // Insert new record
                            string insertQuery = @"INSERT INTO CustomerSpecialCheckpoints (ReferenceId, Type, Result, Description, FilePath, OverallResult, CreatedBy, CreatedDate) 
                            VALUES (@ReferenceId, @Type, @Result, @Description, @FilePath, @OverallResult, @CreatedBy, @CreatedDate)";
                            command = new SqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                            command.Parameters.AddWithValue("@Type", (object)customerSpecialCheckpoint.Type ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Result", (object)customerSpecialCheckpoint.Result ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Description", (object)customerSpecialCheckpoint.Description ?? DBNull.Value);
                            command.Parameters.AddWithValue("@FilePath", (object)customerSpecialCheckpoint.FilePath ?? DBNull.Value);
                            command.Parameters.AddWithValue("@OverallResult", (object)customerSpecialCheckpoint.OverallResult ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedBy", (object)customerSpecialCheckpoint.CreatedBy ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedDate", (object)customerSpecialCheckpoint.CreatedDate ?? DBNull.Value);

                            // Execute the command
                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
        }


        public void SaveSamplingInformation(List<SamplingInformation> SamplingInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (SamplingInformation sampInfo in SamplingInformation)
                {
                    SqlCommand command;

                    if (sampInfo.Id > 0)
                    {
                        // Update existing record
                        //string updateQuery = @"UPDATE DefectPhotos 
                        //               SET ReferenceId = @ReferenceId, 
                        //                   PONumber = @PONumber,
                        //                   ModelNumber = @ModelNumber,
                        //                   SampleSizeFromPackedCTNS = @SampleSizeFromPackedCTNS,
                        //                   SampleSizeFromFinishedUnPacked = @SampleSizeFromFinishedUnPacked,
                        //                   InspectedCartonCTN = @InspectedCartonCTN,
                        //                   InspectedCartonNumber = @InspectedCartonNumber,
                        //                   SampleSizeFromPackedCTNSTotal = @SampleSizeFromPackedCTNSTotal,
                        //                   SampleSizeFromFinishedUnPackedTotal = @SampleSizeFromFinishedUnPackedTotal,
                        //                   InspectedCartonCTNTotal = @InspectedCartonCTNTotal,
                        //                   TotalSampleSizePackedCTNS = @TotalSampleSizePackedCTNS,
                        //                   TotalSampleSizeFinishedUnpacked = @TotalSampleSizeFinishedUnpacked,
                        //                   TotalInspectedCartonCTN = @TotalInspectedCartonCTN,
                        //                   FactoryAllowsDrawingSamples = @FactoryAllowsDrawingSamples,
                        //                   QuantityAvailableForSampling = @QuantityAvailableForSampling
                        //               WHERE Id = @Id";
                        //command = new SqlCommand(updateQuery, connection);
                        //command.Parameters.AddWithValue("@ReferenceId", sampInfo.ReferenceId);
                        //command.Parameters.AddWithValue("@Path", defectPhoto.Path);
                        // Add parameters for other fields
                    }
                    else
                    {
                        // Insert new record
                        string insertQuery = @"INSERT INTO SamplingInformation (ReferenceId, PONumber, ModelNumber, SampleSizeFromPackedCTNS, SampleSizeFromFinishedUnPacked, InspectedCartonCTN, InspectedCartonNumber, TotalSampleSizePackedCTNS, TotalSampleSizeFinishedUnpacked, TotalInspectedCartonCTN, FactoryAllowsDrawingSamples, QuantityAvailableForSampling) 
                                       VALUES (@ReferenceId, @PONumber, @ModelNumber, @SampleSizeFromPackedCTNS, @SampleSizeFromFinishedUnPacked, @InspectedCartonCTN, @InspectedCartonNumber, @TotalSampleSizePackedCTNS, @TotalSampleSizeFinishedUnpacked, @TotalInspectedCartonCTN, @FactoryAllowsDrawingSamples, @QuantityAvailableForSampling)";

                        //string insertQuery = @"INSERT INTO SamplingInformation (ReferenceId, PONumber, ModelNumber, SampleSizeFromPackedCTNS, SampleSizeFromFinishedUnPacked, InspectedCartonCTN) 
                        //               VALUES (@ReferenceId, @PONumber, @ModelNumber, @SampleSizeFromPackedCTNS, @SampleSizeFromFinishedUnPacked, @InspectedCartonCTN)";
                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@PONumber", sampInfo.PONumber);
                        command.Parameters.AddWithValue("@ModelNumber", sampInfo.ModelNumber);
                        command.Parameters.AddWithValue("@SampleSizeFromPackedCTNS", sampInfo.SampleSizeFromPackedCTNS ?? 0);
                        command.Parameters.AddWithValue("@SampleSizeFromFinishedUnPacked", sampInfo.SampleSizeFromFinishedUnPacked ?? 0);
                        command.Parameters.AddWithValue("@InspectedCartonCTN", sampInfo.InspectedCartonCTN ?? 0);
                        command.Parameters.AddWithValue("@InspectedCartonNumber", sampInfo.InspectedCartonNumber);
                        //command.Parameters.AddWithValue("@SampleSizeFromPackedCTNSTotal", sampInfo.TotalSampleSizePackedCTNS);
                        //command.Parameters.AddWithValue("@SampleSizeFromFinishedUnPackedTotal", sampInfo.TotalSampleSizeFinishedUnpacked);
                        //command.Parameters.AddWithValue("@InspectedCartonCTNTotal", sampInfo.TotalInspectedCartonCTN);
                        command.Parameters.AddWithValue("@TotalSampleSizePackedCTNS", sampInfo.TotalSampleSizePackedCTNS ?? 0);
                        command.Parameters.AddWithValue("@TotalSampleSizeFinishedUnpacked", sampInfo.TotalSampleSizeFinishedUnpacked ?? 0);
                        command.Parameters.AddWithValue("@TotalInspectedCartonCTN", sampInfo.TotalInspectedCartonCTN ?? 0);
                        command.Parameters.AddWithValue("@FactoryAllowsDrawingSamples", sampInfo.FactoryAllowsDrawingSamples);
                        command.Parameters.AddWithValue("@QuantityAvailableForSampling", sampInfo.QuantityAvailableForSampling);
                        command.ExecuteNonQuery();

                    }

                }
            }
        }



        public void SaveInspectionStandardResults(List<InspectionStandardResult> InspectionStandardResults)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (InspectionStandardResult sampInfo in InspectionStandardResults)
                {
                    SqlCommand command;

                    if (sampInfo.ID > 0)
                    {
                        // Update existing record
                        //string updateQuery = @"UPDATE DefectPhotos 
                        //               SET ReferenceId = @ReferenceId, 
                        //                   PONumber = @PONumber,
                        //                   ModelNumber = @ModelNumber,
                        //                   SampleSizeFromPackedCTNS = @SampleSizeFromPackedCTNS,
                        //                   SampleSizeFromFinishedUnPacked = @SampleSizeFromFinishedUnPacked,
                        //                   InspectedCartonCTN = @InspectedCartonCTN,
                        //                   InspectedCartonNumber = @InspectedCartonNumber,
                        //                   SampleSizeFromPackedCTNSTotal = @SampleSizeFromPackedCTNSTotal,
                        //                   SampleSizeFromFinishedUnPackedTotal = @SampleSizeFromFinishedUnPackedTotal,
                        //                   InspectedCartonCTNTotal = @InspectedCartonCTNTotal,
                        //                   TotalSampleSizePackedCTNS = @TotalSampleSizePackedCTNS,
                        //                   TotalSampleSizeFinishedUnpacked = @TotalSampleSizeFinishedUnpacked,
                        //                   TotalInspectedCartonCTN = @TotalInspectedCartonCTN,
                        //                   FactoryAllowsDrawingSamples = @FactoryAllowsDrawingSamples,
                        //                   QuantityAvailableForSampling = @QuantityAvailableForSampling
                        //               WHERE Id = @Id";
                        //command = new SqlCommand(updateQuery, connection);
                        //command.Parameters.AddWithValue("@ReferenceId", sampInfo.ReferenceId);
                        //command.Parameters.AddWithValue("@Path", defectPhoto.Path);
                        // Add parameters for other fields
                    }
                    else
                    {
                        string insertQuery = @"INSERT INTO InspectionStandardResults(POorModelNo,PictureNo,PhotoPath,DefectDescription,Critical,Major,Minor,SampleSizeCritical,SampleSizeMajor,SampleSizeMinor,TotalFoundDefectsCritical,TotalFoundDefectsMajor,TotalFoundDefectsMinor,AQLAllowedDefectsCritical,AQLAllowedDefectsMajor,AQLAllowedDefectsMinor,AQLResults,GeneralDefectNotIncludedAQLResultAbove,GeneralDefectDescription,NonConformityFound,NonConformityRemark)
                        VALUES(@POorModelNo,@PictureNo,@PhotoPath,@DefectDescription,@Critical,@Major,@Minor,@SampleSizeCritical,@SampleSizeMajor,
                         @SampleSizeMinor,@TotalFoundDefectsCritical,@TotalFoundDefectsMajor,@TotalFoundDefectsMinor,@AQLAllowedDefectsCritical,
                         @AQLAllowedDefectsMajor,@AQLAllowedDefectsMinor,@AQLResults,@GeneralDefectNotIncludedAQLResultAbove,@GeneralDefectDescription,@NonConformityFound,@NonConformityRemark)";

                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@POorModelNo", sampInfo.POorModelNo);
                        command.Parameters.AddWithValue("@PictureNo", sampInfo.PictureNo);
                        command.Parameters.AddWithValue("@PhotoPath", sampInfo.PhotoPath);
                        command.Parameters.AddWithValue("@DefectDescription", sampInfo.DefectDescription);
                        command.Parameters.AddWithValue("@Critical", sampInfo.Critical ?? 0);
                        command.Parameters.AddWithValue("@Major", sampInfo.Major ?? 0);
                        command.Parameters.AddWithValue("@Minor", sampInfo.Minor ?? 0);
                        command.Parameters.AddWithValue("@SampleSizeCritical", sampInfo.SampleSizeCritical ?? 0);
                        command.Parameters.AddWithValue("@SampleSizeMajor", sampInfo.SampleSizeMajor ?? 0);
                        command.Parameters.AddWithValue("@SampleSizeMinor", sampInfo.SampleSizeMinor ?? 0);
                        command.Parameters.AddWithValue("@TotalFoundDefectsCritical", sampInfo.TotalFoundDefectsCritical ?? 0);
                        command.Parameters.AddWithValue("@TotalFoundDefectsMajor", sampInfo.TotalFoundDefectsMajor ?? 0);
                        command.Parameters.AddWithValue("@TotalFoundDefectsMinor", sampInfo.TotalFoundDefectsMinor ?? 0);
                        command.Parameters.AddWithValue("@AQLAllowedDefectsCritical", sampInfo.AQLAllowedDefectsCritical ?? 0);
                        command.Parameters.AddWithValue("@AQLAllowedDefectsMajor", sampInfo.AQLAllowedDefectsMajor ?? 0);
                        command.Parameters.AddWithValue("@AQLAllowedDefectsMinor", sampInfo.AQLAllowedDefectsMinor ?? 0);

                        command.Parameters.AddWithValue("@AQLResults", sampInfo.AQLResults);
                        command.Parameters.AddWithValue("@GeneralDefectNotIncludedAQLResultAbove", sampInfo.GeneralDefectNotIncludedAQLResultAbove);
                        command.Parameters.AddWithValue("@GeneralDefectDescription", sampInfo.GeneralDefectDescription);

                        command.Parameters.AddWithValue("@NonConformityFound", sampInfo.NonConformityFound);
                        command.Parameters.AddWithValue("@NonConformityRemark", sampInfo.NonConformityRemark);
                        command.ExecuteNonQuery();

                        // Add parameters for other fields
                    }


                    // Execute the command

                }
            }
        }

        public void SaveDefectPhotos(List<DefectPhoto> DefectPhotos)
        {
            //InspectionStandardResult obj = new InspectionStandardResult();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (DefectPhoto defectPhoto in DefectPhotos)
                {
                    SqlCommand command;

                    if (defectPhoto.Id > 0)
                    {
                        // Update existing record
                        string updateQuery = @"UPDATE DefectPhotos 
                                       SET ReferenceId = @ReferenceId, 
                                           Path = @Path
                                       WHERE Id = @Id";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@Path", (object)defectPhoto.Path ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", defectPhoto.Id);
                    }
                    else
                    {
                        // Insert new record
                        string insertQuery = @"INSERT INTO DefectPhotos (ReferenceId, Path,DefectType, LevelName ,LevelNo) 
                                       VALUES (@ReferenceId, @Path,@DefectType, @LevelName ,@LevelNo)";
                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@Path", (object)defectPhoto.Path ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DefectType", (object)defectPhoto.DefectType ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LevelName", (object)defectPhoto.LevelName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LevelNo", (object)defectPhoto.LevelNo ?? DBNull.Value);

                    }

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }

        #region Old Code

        public void SaveItemData(List<ItemDatumModel> ItemData)
        {

            if (ItemData.Count > 0)
            {

                ItemDatumModel mod = new ItemDatumModel();
                foreach (var data in ItemData)
                {
                    mod.UnitsOrCarton = data.UnitsOrCarton;
                    mod.PackedUnits = data.PackedUnits;
                    mod.PackedCartons = data.PackedCartons;
                    mod.FinishedUnpacked = data.FinishedUnpacked;
                    mod.NotFinishedUnits = data.NotFinishedUnits;
                    mod.OverallResult = data.OverallResult;
                    _itemDatumService.InsertUpdateItemDatum(mod);

                }

            }
        }

        public void SaveSamplingInformation(List<SamplingInformationModel> SamplingInformationData)
        {
            if (SamplingInformationData.Count > 0)
            {

                SamplingInformationModel mod = new SamplingInformationModel();
                foreach (var data in SamplingInformationData)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.TotalCartonsNum = data.TotalCartonsNum;
                    mod.SelectedCartonsNum = data.SelectedCartonsNum;
                    _samplingInformationService.InsertUpdateSamplingInformation(mod);
                }

            }
        }

        public void SaveItemRemarkListData(List<ItemRemarkDatumModel> ItemRemarkListData)
        {
            string fileName = string.Empty;
            if (ItemRemarkListData.Count > 0)
            {

                ItemRemarkDatumModel mod = new ItemRemarkDatumModel();
                foreach (var data in ItemRemarkListData)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.ItemRemarkStatus = data.ItemRemarkStatus;
                    mod.ItemRemarkComments = data.ItemRemarkComments;
                    fileName = Path.GetFileName(data.FilePath);
                    mod.FilePath = fileName;
                    _itemRemarkDatumService.InsertUpdateItemRemarkDatum(mod);
                }

            }

        }

        public void SaveItemAQLDefect(List<ItemAQLDefectsAndRemarkModel> ItemAQLDefect)
        {
            string fileName = string.Empty;
            if (ItemAQLDefect.Count > 0)
            {

                ItemAQLDefectsAndRemarkModel mod = new ItemAQLDefectsAndRemarkModel();
                foreach (var data in ItemAQLDefect)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.LotSize = data.LotSize;
                    mod.InspectionLevel = data.InspectionLevel;

                    mod.SampleSizeCritical = data.SampleSizeCritical;
                    mod.SampleSizeMajor = data.SampleSizeMajor;
                    mod.SampleSizeMinor = data.SampleSizeMinor;

                    mod.AQLCritical = data.AQLCritical;
                    mod.AQLMajor = data.AQLMajor;
                    mod.AQLMinor = data.AQLMinor;


                    mod.MaxDefectsAllowedCritical = data.MaxDefectsAllowedCritical;
                    mod.MaxDefectsAllowedMajor = data.MaxDefectsAllowedMajor;
                    mod.MaxDefectsAllowedMinor = data.MaxDefectsAllowedMinor;

                    mod.DefectsAllowedCritical = data.DefectsAllowedCritical;
                    mod.DefectsAllowedMajor = data.DefectsAllowedMajor;
                    mod.DefectsAllowedMinor = data.DefectsAllowedMinor;
                    mod.AQLResult = data.AQLResult;

                    _itemAQLDefectsAndRemarkService.InsertUpdateItemAQLDefectsAndRemark(mod);
                }

            }
        }
        public void SaveAQLDefect(List<AQLDefectModel> AQLDefect)
        {
            if (AQLDefect.Count > 0)
            {

                AQLDefectModel mod = new AQLDefectModel();
                foreach (var data in AQLDefect)
                {
                    mod.ReferenceId = ReferenceId;
                    mod.Defects = data.Defects;
                    mod.RemarkContent = data.RemarkContent;
                    mod.Major = data.Major;
                    mod.Critical = data.Critical;
                    mod.Minor = data.Minor;
                    mod.Filename = Path.GetFileName(data.Filename);
                    _aQLDefectService.InsertUpdateAQLDefect(mod);
                }

            }
        }
        public void SaveShipperCartonPackaging(List<ShipperCartonPackagingModel> ShipperCartonPackaging)
        {
            if (ShipperCartonPackaging.Count > 0)
            {

                ShipperCartonPackagingModel mod = new ShipperCartonPackagingModel();
                foreach (var data in ShipperCartonPackaging)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.ShipperCartonDimensionsResult = data.ShipperCartonDimensionsResult;
                    mod.ShipperCartonDimensionsMeasuredData = data.ShipperCartonDimensionsMeasuredData;
                    mod.ShipperCartonWeightResult = data.ShipperCartonWeightResult;
                    mod.ShipperCartonWeightMeasuredData = data.ShipperCartonWeightMeasuredData;
                    mod.ShipperCartonMarkingsLabelingResult = data.ShipperCartonMarkingsLabelingResult;
                    mod.PackagingMethodAssortmentResult = data.PackagingMethodAssortmentResult;
                    _shipperCartonPackagingService.InsertUpdateShipperCartonPackaging(mod);
                }

            }
        }
        public void SaveInnerPackaging(List<InnerPackagingModel> InnerPackaging)
        {
            if (InnerPackaging.Count > 0)
            {

                InnerPackagingModel mod = new InnerPackagingModel();
                foreach (var data in InnerPackaging)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.InnerPackagingMarkingsLabeling = data.InnerPackagingMarkingsLabeling;
                    mod.InnerPackagingMethodAssortmentResult = data.InnerPackagingMethodAssortmentResult;
                    _innerPackagingService.InsertUpdateInnerPackaging(mod);
                }


                //


            }

        }



        public void SaveRetailPackaging(List<RetailPackagingModel> RetailPackaging)
        {
            if (RetailPackaging.Count > 0)
            {

                RetailPackagingModel mod = new RetailPackagingModel();
                foreach (var data in RetailPackaging)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.RetailPackagingPrintings = data.RetailPackagingPrintings;
                    mod.RetailPackagingUserInstructions = data.RetailPackagingUserInstructions;
                    mod.RetailPackagingMethods = data.RetailPackagingMethods;
                    _retailPackagingService.InsertUpdateRetailPackaging(mod);
                }


                //


            }

        }

        public void SaveItemOverall(List<ItemOverallModel> ItemOverall)
        {
            if (ItemOverall.Count > 0)
            {

                ItemOverallModel mod = new ItemOverallModel();
                foreach (var data in ItemOverall)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.ItemOverallDimensionsResult = data.ItemOverallDimensionsResult;
                    mod.ItemOverallDimensionsMeasuredData = data.ItemOverallDimensionsMeasuredData;
                    mod.OtherDimensionsResult = data.OtherDimensionsResult;
                    mod.OtherDimensionsMeasuredData = data.OtherDimensionsMeasuredData;
                    mod.ItemNetWeightResult = data.ItemNetWeightResult;
                    mod.ItemNetWeightMeasuredData = data.ItemNetWeightMeasuredData;
                    mod.ItemColor = data.ItemColor;
                    mod.GeneralConstructionAndMaterial = data.GeneralConstructionAndMaterial;

                    _iltemOverallService.InsertUpdateItemOverall(mod);
                }


                //


            }

        }

        public void SaveOnSiteTestResult(List<OnSiteTestResultModel> OnSiteTestResult)
        {
            if (OnSiteTestResult.Count > 0)
            {

                OnSiteTestResultModel mod = new OnSiteTestResultModel();
                foreach (var data in OnSiteTestResult)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.TestDescription = data.TestDescription;
                    mod.SampleSize = data.SampleSize;
                    mod.Results = data.Results;
                    mod.ResultComments = data.ResultComments;
                    mod.FilePath = Path.GetFileName(data.FilePath);
                    _onSiteTestResultService.InsertUpdateOnSiteTestResult(mod);
                }

            }

        }


        public void SaveItemOtherPhotos(List<ItemOtherPhotoModel> ItemOtherPhotos)
        {
            if (ItemOtherPhotos.Count > 0)
            {

                ItemOtherPhotoModel mod = new ItemOtherPhotoModel();
                foreach (var data in ItemOtherPhotos)
                {
                    mod.ReferenceId = ReferenceId;// data.ReferenceId;
                    mod.FilePath = Path.GetFileName(data.FilePath);
                    _itemOtherPhotoService.InsertUpdateItemOtherPhoto(mod);
                }

            }
        }

        public void SaveBookingRequirementsResults(List<BookingRequirementsResult> BookingRequirementsResult)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (BookingRequirementsResult bookInfo in BookingRequirementsResult)
                {
                    SqlCommand command;

                    if (bookInfo.ID > 0)
                    {

                    }
                    else
                    {
                        string insertQuery = @"INSERT INTO BookingRequirementsResults(ReferenceId,PONumber,ModelNumber,OrderQtyUnits,UnitOrCartoons,AQFinishedAndPackedUnits,AQFinishedAndPackedCartons,AQFinishedButNotPackedUnits,AQNotFinishedPackedUnits,Results,ResultsORRemarks,FilePath,AQTotalFinishedAndPackedUnits,AQTotalFinishedAndPackedCartons,AQTotalFinishedButNotPackedUnits,AQTotalNotFinishedPackedUnits) 
                                                VALUES(@ReferenceId,@PONumber,@ModelNumber,@OrderQtyUnits,@UnitOrCartoons,@AQFinishedAndPackedUnits,@AQFinishedAndPackedCartons,@AQFinishedButNotPackedUnits,@AQNotFinishedPackedUnits,@Results,@ResultsORRemarks,@FilePath,@AQTotalFinishedAndPackedUnits,@AQTotalFinishedAndPackedCartons,@AQTotalFinishedButNotPackedUnits,@AQTotalNotFinishedPackedUnits)";

                        command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        command.Parameters.AddWithValue("@ModelNumber", "1243");
                        command.Parameters.AddWithValue("@PONumber", bookInfo.ModelNumber);
                        command.Parameters.AddWithValue("@OrderQtyUnits", bookInfo.OrderQtyUnits);
                        command.Parameters.AddWithValue("@UnitOrCartoons", bookInfo.UnitOrCartoons);
                        command.Parameters.AddWithValue("@AQFinishedAndPackedUnits", bookInfo.AQFinishedAndPackedUnits);
                        command.Parameters.AddWithValue("@AQFinishedAndPackedCartons", bookInfo.AQFinishedAndPackedCartons);
                        command.Parameters.AddWithValue("@AQFinishedButNotPackedUnits", bookInfo.AQFinishedButNotPackedUnits);
                        command.Parameters.AddWithValue("@AQNotFinishedPackedUnits", bookInfo.AQNotFinishedPackedUnits);
                        command.Parameters.AddWithValue("@Results", bookInfo.Results);
                        command.Parameters.AddWithValue("@ResultsORRemarks", bookInfo.ResultsORRemarks);
                        command.Parameters.AddWithValue("@FilePath", bookInfo.FilePath);
                        command.Parameters.AddWithValue("@AQTotalFinishedAndPackedUnits", bookInfo.AQTotalFinishedAndPackedUnits);
                        command.Parameters.AddWithValue("@AQTotalFinishedAndPackedCartons", bookInfo.AQTotalFinishedAndPackedCartons);
                        command.Parameters.AddWithValue("@AQTotalFinishedButNotPackedUnits", bookInfo.AQTotalFinishedButNotPackedUnits);
                        command.Parameters.AddWithValue("@AQTotalNotFinishedPackedUnits", bookInfo.AQTotalNotFinishedPackedUnits);
                        command.ExecuteNonQuery();

                    }
                }
            }
        }


        #endregion
    }
}

public class PackingandProductSpecificationModel
{
    public int id { get; set; }
    public string C1Status { get; set; }
    public string CorugatedPaperPly { get; set; }
    public string Fastening { get; set; }
    public string SealedBy { get; set; }
    public string Strapping { get; set; }
    public string C2Status { get; set; }
    public string C3Status { get; set; }
    public string C4Status { get; set; }
    public string C5Status { get; set; }
    public string C6Status { get; set; }
    public string C7Status { get; set; }
    public string C8Status { get; set; }
    public string C9Status { get; set; }
    public string C10Status { get; set; }
    public string C11Status { get; set; }
    public string C12Status { get; set; }
    public string FileDuvetCore { get; set; }
    public string FileDyedFitted140 { get; set; }
    public string FileDyedFitted160 { get; set; }
    public string FileDyedFitted180 { get; set; }
    public string FileDyedFitted90 { get; set; }
}



public class InspectionStandard
{
    public int PONumber { get; set; }
    public string DefectDescriptionStatus { get; set; }
    public string DefectDescription { get; set; }
    public string Status { get; set; }
    public string GeneralDefectsFound { get; set; }
    public string GeneralDefectsDescription { get; set; }
    public string NonConformityFound { get; set; }
    public string NonConformityRemark { get; set; }
    public string OverallResult { get; set; }

}



//public class ReportModel
//{
//    public List<ImportantRemark> listImportantRemark { get; set; }
//    public List<CustomerSpecialCheckpoint> listCustomerSpecialCheckpoint { get; set; }
//    public List<SamplingInformation> listSamplingInformation { get; set; }
//    public List<InspectionStandardResult> listInspectionStandardResult { get; set; }
//    public List<YourProduct> listYourProduct { get; set; }

//}