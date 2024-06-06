using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Model.Common;
using Model.Common.Utilities;
using Model.Entity;
using OfficeOpenXml;
using PrimLink.Utility;
using Service.Implementation;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class GeneralInformationController : BaseController
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<GeneralInformationController> _logger;
        private readonly IUserService _userService;
        private readonly IApplicationLookupService _lookupService;
        private readonly IGeneralInformationService _generalInformationService;
        private readonly IReferenceService _referenceService;
        private readonly IVendorService _vendorService;
        private readonly IFactoryService _factoryService;
        private readonly IUserFormService _userFormService;
        private readonly ControllerArgument _args;
        private static ReferenceModel referenceModel;
        #endregion

        public GeneralInformationController(ControllerArgument args, ILogger<GeneralInformationController> logger, IWebHostEnvironment webHostEnvironment) : base(args)
        {
            _logger = logger;
            _args = args;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _generalInformationService = new GeneralInformationService();
            _lookupService = new ApplicationLookupService();
            _referenceService = new ReferenceService();
            _vendorService = new VendorService();
            _factoryService = new FactoryService();
            _userFormService = new UserFormService();
        }
        public IActionResult Index(int userId, bool isAdmin, int userFormId)
        {
            var userRole = HttpContext.Session.GetString("role");

            if (userFormId == 0)
            {
                var newGeneralInfo = new GeneralInformationModel();
                newGeneralInfo.UserId = userId;
                newGeneralInfo.UserFormId = userFormId;
                newGeneralInfo.References = new List<ReferenceModel>();
                newGeneralInfo.Vendor = new VendorModel();
                newGeneralInfo.Vendor.IsVendorEmailIncluded = false;
                newGeneralInfo.Vendor.IsVendor = true;
                newGeneralInfo.Factory = new FactoryModel();
                newGeneralInfo.Factory.IsFactoryEmailIncluded = false;
                newGeneralInfo.Factory.IsFactory = true;
                newGeneralInfo.Factory.PayByLC = false;
                newGeneralInfo.IsAdmin = isAdmin;
                if (!isAdmin)
                {
                    newGeneralInfo.IsApproved = false;
                    newGeneralInfo.References.ForEach(item =>
                    {
                        item.IsApproved = false;
                    });
                    newGeneralInfo.Vendor.IsApproved = false;
                    newGeneralInfo.Factory.IsApproved = false;
                }
                return PartialView(ADD_EDIT_GENERAL_INFO_VIEW, newGeneralInfo);
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var generalInfo = _generalInformationService.GetGeneralInformationByUserFormId(userFormId);
                    if (generalInfo != null)
                    {
                        generalInfo.MissionReference = $"PL-0203400-{Convert.ToString(generalInfo.Id):D4}";
                        generalInfo.IsAdmin = isAdmin;
                        generalInfo.References = _referenceService.GetReferenceByGeneralInformationId(generalInfo.Id);
                        generalInfo.Vendor = _vendorService.GetVendorByGeneralInformationId(generalInfo.Id);
                        generalInfo.Factory = _factoryService.GetFactoryByGeneralInformationId(generalInfo.Id);
                        generalInfo.Vendor.IsVendor = true;
                        generalInfo.Factory.IsFactory = true;
                        if (!isAdmin)
                        {
                            generalInfo.IsApproved = userModel.IsApproved == true ? true : false;
                            if (generalInfo.References.Count > 0)
                            {
                                generalInfo.References.ForEach(item =>
                                {
                                    item.IsApproved = userModel.IsApproved == true ? true : false;
                                });
                            }
                            if (generalInfo.Vendor != null)
                            {
                                generalInfo.Vendor.IsVendor = true;
                                generalInfo.Vendor.IsApproved = userModel.IsApproved == true ? true : false;
                            }
                            if (generalInfo.Factory != null)
                            {
                                generalInfo.Factory.IsFactory = true;
                                generalInfo.Factory.IsApproved = userModel.IsApproved == true ? true : false;
                            }


                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_GENERAL_INFO_VIEW_INSPECTOR, generalInfo);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_GENERAL_INFO_VIEW, generalInfo);
                        }
                    }
                    else
                    {
                        var newGeneralInfo = new GeneralInformationModel();
                        newGeneralInfo.UserId = userModel.Id;
                        newGeneralInfo.UserFormId = userFormId;
                        newGeneralInfo.References = new List<ReferenceModel>();
                        newGeneralInfo.Vendor = new VendorModel();
                        newGeneralInfo.Vendor.IsVendorEmailIncluded = false;
                        newGeneralInfo.Vendor.IsVendor = true;
                        newGeneralInfo.Factory = new FactoryModel();
                        newGeneralInfo.Factory.IsFactoryEmailIncluded = false;
                        newGeneralInfo.Factory.IsFactory = true;
                        newGeneralInfo.Factory.PayByLC = false;
                        newGeneralInfo.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            newGeneralInfo.IsApproved = userModel.IsApproved == true ? true : false;
                            newGeneralInfo.References.ForEach(item =>
                            {
                                item.IsApproved = userModel.IsApproved == true ? true : false;
                            });
                            newGeneralInfo.Vendor.IsApproved = userModel.IsApproved == true ? true : false;
                            newGeneralInfo.Factory.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_GENERAL_INFO_VIEW_INSPECTOR, newGeneralInfo);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_GENERAL_INFO_VIEW, newGeneralInfo);
                        }
                    }

                }
                else
                {
                    var newGeneralInfo = new GeneralInformationModel();
                    newGeneralInfo.UserId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
                    newGeneralInfo.UserFormId = userFormId;
                    newGeneralInfo.References = new List<ReferenceModel>();
                    newGeneralInfo.Vendor = new VendorModel();
                    newGeneralInfo.Vendor.IsVendorEmailIncluded = false;
                    newGeneralInfo.Vendor.IsVendor = true;
                    newGeneralInfo.Factory = new FactoryModel();
                    newGeneralInfo.Factory.IsFactoryEmailIncluded = false;
                    newGeneralInfo.Factory.IsFactory = true;
                    newGeneralInfo.Factory.PayByLC = false;
                    newGeneralInfo.IsAdmin = isAdmin;
                    if (!isAdmin)
                    {
                        newGeneralInfo.IsApproved = false;
                        newGeneralInfo.References.ForEach(item =>
                        {
                            item.IsApproved = false;
                        });
                        newGeneralInfo.Vendor.IsApproved = false;
                        newGeneralInfo.Factory.IsApproved = false;
                    }
                    if (userRole == "10003")
                    {
                        return PartialView(ADD_EDIT_GENERAL_INFO_VIEW_INSPECTOR, newGeneralInfo);
                    }
                    else
                    {
                        return PartialView(ADD_EDIT_GENERAL_INFO_VIEW, newGeneralInfo);
                    }
                }
            }
        }

        #region Add/Edit General Information
        /// <summary>
        /// Add/Edit General Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEditGeneralInformation(GeneralInformationModel model)
        {
            try
            {
                var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };

                if (model.Id > 0)
                {
                    responseModel.Message = GENERAL_INFO_UPDATED;
                }
                else
                {
                    responseModel.Message = GENERAL_INFO_SAVED;
                }
                if (referenceModel != null)
                {
                    model.References = ConvertExcelToList(referenceModel.FilePath);
                }
                if (model.UserFormId == 0)
                {
                    var userForm = new UserFormModel();
                    userForm.UserId = model.UserId;
                    userForm = _userFormService.InsertUpdateUserForm(userForm);

                    model.UserFormId = userForm.Id;
                }
                responseModel.IsAdmin = model.IsAdmin;
                model = _generalInformationService.InsertUpdateGeneralInformation(model);
                responseModel.Id = (int)model.UserFormId;
                return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                var path = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH);
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists == true && di.GetFiles().Length > 0)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                referenceModel = null;
            }
        }
        #endregion

        #region Add New Row Level
        /// <summary>
        /// Add New Row Level
        /// </summary>
        /// <param name="iterator"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> AddNewLevel(int iterator = 0)
        {
            try
            {
                var detailModel = new List<ReferenceModel>();
                var referenceDetailModel = new ReferenceModel
                {
                    Id = 0,
                    IsActive = true,
                    i = iterator,
                    LevelNo = iterator + 1
                };
                detailModel.Add(referenceDetailModel);
                //var dataValidationView = await RenderPartialViewToString("_Reference", detailModel, true);
                //return Json(new { Status = HttpStatusCode.OK, Html = dataValidationView, Model = detailModel });
                return PartialView("_Reference", detailModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400 });
            }
        }
        #endregion

        public IActionResult DownloadTemplate()
        {
            DataTable dt = new DataTable("References");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("PO#"),
                                        new DataColumn("SKU#"),
                                        new DataColumn("Name"),
                                        new DataColumn("Quantity"),
                                        new DataColumn("Product Type")
            });

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "References.xlsx");
                }
            }
        }

        public async Task<ActionResult> Async_Save(IEnumerable<IFormFile> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH, fileName);
                    var path = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH);

                    referenceModel = new ReferenceModel();
                    referenceModel.FormFile = file;
                    referenceModel.FileName = fileName;
                    referenceModel.FilePath = physicalPath;
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    // The files are not actually saved in this demo
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            else
            {
                NotFound(ADD_FILES);
            }
            return Content("");
        }
        public ActionResult Async_Remove(string[] fileNames)
        {
            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, DOCUMENTS, fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }
            return Content("");
        }
        public List<ReferenceModel> ConvertExcelToList(string filePath)
        {
            var list = new List<ReferenceModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // assume data is in the first worksheet
                var rowCount = worksheet.Dimension.Rows;

                for (int i = 2; i <= rowCount; i++) // assume data starts from row 2, row 1 contains headers
                {
                    var po = worksheet.Cells[i, 1].Value?.ToString();
                    var sku = worksheet.Cells[i, 2].Value?.ToString();
                    var name = worksheet.Cells[i, 3].Value?.ToString();
                    var quantity = worksheet.Cells[i, 4].Value?.ToString();
                    var ProductType = worksheet.Cells[i, 5].Value?.ToString();

                    list.Add(new ReferenceModel { PO = po, SKU = sku, Name = name, Quantity = Convert.ToInt64(quantity), ProductType = ProductType, LevelNo = i - 1 });
                }
            }

            return list;
        }

      
        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/GeneralInformation/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/GeneralInformationInspector/";
        private const string ADD_EDIT_GENERAL_INFO_VIEW = VIEW_FOLDER + "_GeneralInformation.cshtml";
        private const string ADD_EDIT_GENERAL_INFO_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "_GeneralInformation.cshtml";
        private const string GENERAL_INFO_SAVED = "General Information saved successfully";
        private const string GENERAL_INFO_UPDATED = "General Information updated successfully";
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
    }
}
