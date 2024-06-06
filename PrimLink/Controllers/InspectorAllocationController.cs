using Component;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Common;
using Model.Common.Utilities;
using Model.Entity;
using PrimLink.Utility;
using Repository.Entity;
using Service.Implementation;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class InspectorAllocationController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<InspectorAllocationController> _logger;
        private readonly IUserService _userService;
        private readonly IUserFormService _userFormService;
        private readonly IInspectorAllocationService _inspectorAllocationService;
        private readonly IApplicationLookupService _lookupService;
        private readonly IGeneralInformationService _generalInformationService;

        #endregion

        public InspectorAllocationController(ILogger<InspectorAllocationController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _userFormService = new UserFormService();
            _inspectorAllocationService = new InspectorAllocationService();
            _lookupService = new ApplicationLookupService();
            _generalInformationService = new GeneralInformationService();
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //var userName = HttpContext.Session.GetString("userName");
            var email = HttpContext.Session.GetString("email");
            var password = HttpContext.Session.GetString("password");
            var allUsers = _userService.GetAllUsers();
            var userModel = allUsers.Where(x => x.Email != null && x.Email.ToLower() == email.ToLower() && x.Password == EncryptionHelper.Encrypt(password)).FirstOrDefault();
            if (userModel != null)
            {
                userModel.IsAdmin = userModel.Role == 10001 ? true : false;
                ViewBag.Users = allUsers.Where(x => x.Role == 10002 && (bool)x.IsActive).Count();
                ViewBag.Inspectors = allUsers.Where(x => x.Role == 10003 && (bool)x.IsActive).Count();
                ViewBag.FirstName = HttpContext.Session.GetString("firstName");
                ViewBag.LastName = HttpContext.Session.GetString("lastName");
                ViewBag.Email = email;
                userModel.IsInspector = userModel.Role == 10003 ? true : false;
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GetInspectorGrid([DataSourceRequest] DataSourceRequest request)
        {
            var users = _userService.GetAllUsers().Where(x => (bool)x.IsActive && x.Status == "Approved").ToList();
            var forms = _generalInformationService.GetAllGeneralInformations();
            var inspectors = _inspectorAllocationService.GetAllInspectorAllocations().Select(x => new InspectorAllocationModel
            {
                Id = x.Id,
                InspectorId = x.InspectorId,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UserFormId = x.UserFormId,
                UserName = users.Where(y => y.Id == x.UserId).FirstOrDefault() != null ? users.Where(y => y.Id == x.UserId).FirstOrDefault().FirstName + " " + users.Where(y => y.Id == x.UserId).FirstOrDefault().LastName : string.Empty,
                UserFormName = forms.Where(y => y.UserFormId == x.UserFormId).FirstOrDefault() != null ? forms.Where(y => y.UserFormId == x.UserFormId).FirstOrDefault().ProductCategory + " | " + forms.Where(y => y.UserFormId == x.UserFormId).FirstOrDefault().ServiceDate.Value.ToShortDateString() : string.Empty,
                InspectorName = users.Where(y => y.Id == x.UserId).FirstOrDefault() != null ? users.Where(y => y.Id == x.InspectorId).FirstOrDefault().FirstName + " " + users.Where(y => y.Id == x.InspectorId).FirstOrDefault().LastName : string.Empty
            }).ToList();
            var inspectorsGrid = inspectors.ToDataSourceResult(request);
            return Json(inspectorsGrid);
        }

        #region Add/Edit User Popup
        /// <summary>
        /// Add/Edit User Popup
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddEditInspector(int Id)
        {
            try
            {
                InspectorAllocationModel model = new InspectorAllocationModel();
                model = _inspectorAllocationService.GetInspectorAllocationById(Id);
                
                if (Id > 0)
                {
                    model.dropdownBinderModel = _userService.GetAllUsers().Where(x => x.Role == 10002).Select(x => new DropdownBinderModel
                    {
                        Id = x.Id,
                        DisplayName = x.FirstName + " " + x.LastName
                    }).ToList();
                    model.dropdownBinderModel2 = _userService.GetAllUsers().Where(x => x.Role == 10003).Select(x => new DropdownBinderModel
                    {
                        Id = x.Id,
                        DisplayName = x.FirstName + " " + x.LastName
                    }).ToList();
                    return PartialView(ADD_EDIT_INSPECTOR_VIEW, model);
                }
                else
                {
                    model = new InspectorAllocationModel();
                    model.dropdownBinderModel = _userService.GetAllUsers().Where(x => x.Role == 10002).Select(x => new DropdownBinderModel
                    {
                        Id = x.Id,
                        DisplayName = x.FirstName + " " + x.LastName
                    }).ToList();
                    model.dropdownBinderModel2 = _userService.GetAllUsers().Where(x => x.Role == 10003).Select(x => new DropdownBinderModel
                    {
                        Id = x.Id,
                        DisplayName = x.FirstName + " " + x.LastName
                    }).ToList();
                    return PartialView(ADD_EDIT_INSPECTOR_VIEW, model);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        public JsonResult Cascading_GetForms(int inspectorId, int? userId)
        {
            InspectorAllocationModel model = new InspectorAllocationModel();
            var userFormIds = _inspectorAllocationService.GetAllInspectorAllocations().Where(x => x.UserId == userId).Select(x => x.UserFormId).ToList();
            var forms = _generalInformationService.GetAllGeneralInformations().Where(x => x.UserId == userId).ToList();
            if (inspectorId == 0)
            {
                var getForm = _userFormService.GetAllUserForms().Where(x => x.UserId == userId && !userFormIds.Contains(x.Id) && x.IsApproved == true).ToList();
                model.dropdownBinderModel1 = getForm.Select(x => new DropdownBinderModel
                {
                    Id = x.Id,
                    DisplayName = x.Id + " | " + forms.Where(y => y.UserFormId == x.Id).FirstOrDefault() == null ? "N/A" : forms.Where(y => y.UserFormId == x.Id).FirstOrDefault().ProductCategory + " | " + forms.Where(y => y.UserFormId == x.Id).FirstOrDefault().ServiceDate.Value.ToShortDateString()
                }).ToList();
            }
            else
            {
                var userFormId = _inspectorAllocationService.GetAllInspectorAllocations().Where(x => x.UserId == userId && x.Id == inspectorId).Select(x => x.UserFormId).FirstOrDefault();
                userFormIds.Remove(userFormId);
                model.dropdownBinderModel1 = _userFormService.GetAllUserForms().Where(x => x.UserId == userId && !userFormIds.Contains(x.Id) && x.IsApproved == true).Select(x => new DropdownBinderModel
                {
                    Id = x.Id,
                    DisplayName = x.Id + " | " + forms.Where(y => y.UserFormId == x.Id).FirstOrDefault() == null ? "N/A" : forms.Where(y => y.UserFormId == x.Id).FirstOrDefault().ProductCategory + " | " + forms.Where(y => y.UserFormId == x.Id).FirstOrDefault().ServiceDate.Value.ToShortDateString()
                }).ToList();
            }
            return Json(model.dropdownBinderModel1);
        }

        #region Add/Edit Inspector
        /// <summary>
        /// Add/Edit Inspector
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEditInspector(InspectorAllocationModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                if (model.Id > 0)
                {
                    responseModel.Message = INSPECTOR_UPDATED;
                }
                else
                {
                    responseModel.Message = INSPECTOR_SAVED;
                }
                _inspectorAllocationService.InsertUpdateInspectorAllocation(model);

                var inspector = _userService.GetUserById((int)model.InspectorId);
                var generalInfo = _generalInformationService.GetGeneralInformationByUserFormId((int)model.UserFormId);
                if (inspector != null && !string.IsNullOrWhiteSpace(inspector.Email))
                {
                    var bodyInspector = $"<p>" +
                    //$"{logo}" +
                    $"<p>Dear Pakistan Team Inspector,</p>" +
                    $"<p><strong>Please note a new inspection is allocated to you:</strong></p>" +
                    $"<p><a href=\"https://primlinkintl.com/Home/UserForm?Id={model.UserId}&userFormId={model.UserFormId}&IsAdmin=false\">Link to Mission</a></p>" +
                    $"<p><strong>The Protocol is ready.</strong></p>" +
                    $"<p><a href=\"https://primlinkintl.com\">Full Bridge: Inspection Protocols</a></p>" +
                    $"<p><strong>Order details:</strong></p>" +
                    $"<p><strong>Inspection date:</strong> {generalInfo.CreatedDate}</p>" +
                    $"<p><strong>Product name:</strong> {generalInfo.ProductCategory}</p>" +
                    $"<p><strong>Quantity ordered:</strong> {generalInfo.References?.Sum(item => item.Quantity)}</p>" +
                    $"<p><strong>Man-days:</strong> 1.00</p>" +
                    $"<p><strong>AQF internal reference:</strong> PL-0203400-{model.UserFormId:D4}</p>" +
                    $"<p><strong>Factory details:</strong></p>" +
                    $"<ul><li><strong>Name:</strong> {generalInfo.Factory.FactoryPreset}</li><li><strong>Address:</strong> {generalInfo.Factory.Address}</li></ul>" +
                    $"<p>Attached please find all the documents you need for this inspection.</p>" +
                    $"<p>Please contact the factory the day before the inspection to confirm the service.</p>" +
                    $"<p>Thank you</p><p>PrimLink International</p><p>&nbsp;</p>";
                    Task.Run(() =>
                    {
                        Email(inspector.Email, "Mission Allocation", bodyInspector);
                    });
                }
                return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }
        #endregion

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult DeleteInspector(int Id)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Delete };
            try
            {
                if (Id > 0)
                {
                    _inspectorAllocationService.DeleteInspectorAllocation(Id, 1);
                }
                responseModel.Message = INSPECTOR_DELETED;
                return StatusCode((int)HttpStatusCode.OK, new { Status = HttpStatusCode.OK, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }

        public void Email(string toEmail, string subject, string body)
        {
            if (toEmail != null)
            {
                ConfigurationModel model = new ConfigurationModel();
                model.TLS = true;
                model.SenderEmail = "report@primlink.com";
                model.FromAddress = "report@primlink.com";
                model.Server = "mail.primlink.com";
                model.Port = 465;
                model.SenderName = "PrimLink";
                model.UserName = "report@primlink.com";
                model.Password = "report@primlink.com2023";
                model.Domain = "office";
                EmailUtility.SendEmail(toEmail, subject, body, model);
            }
        }

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/InspectorAllocation/";
        private const string ADD_EDIT_INSPECTOR_VIEW = VIEW_FOLDER + "AddEditInspector.cshtml";
        private const string INSPECTOR_SAVED = "Inspector allocated successfully";
        private const string INSPECTOR_UPDATED = "Inspector allocated successfully";
        private const string INSPECTOR_DELETED = "Inspector deleted successfully";
        private const string SOMETHING_WENT_WRONG = "Something went wrong";
        private const string IMAGE_PATH_SPLIT = "/";
        private const string TEMP_FILE_PATH = "temp_images";
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
