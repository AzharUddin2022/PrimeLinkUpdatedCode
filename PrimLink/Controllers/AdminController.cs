using Component;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class AdminController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<AdminController> _logger;
        private readonly IUserService _userService;
        private readonly IApplicationLookupService _lookupService;
        #endregion

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _lookupService = new ApplicationLookupService();
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
            var allUsers = _userService.GetAllUsers().Where(x => x.Status == "Approved" && (bool)x.IsActive);
            var userModel = allUsers.Where(x => x.Email != null && x.Email.ToLower() == email.ToLower() && x.Password == EncryptionHelper.Encrypt(password)).FirstOrDefault();
            if (userModel != null)
            {
                if (userModel.Role == 10001)
                {
                    ViewBag.Users = allUsers.Where(x => x.Role == 10002 && (bool)x.IsActive).Count();
                    ViewBag.Inspectors = allUsers.Where(x => x.Role == 10003 && (bool)x.IsActive).Count();
                    ViewBag.FirstName = HttpContext.Session.GetString("firstName");
                    ViewBag.LastName = HttpContext.Session.GetString("lastName");
                    ViewBag.Email = email;
                    userModel.IsAdmin = userModel.Role == 10001 ? true : false;
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SignUpRequests()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //var userName = HttpContext.Session.GetString("userName");
            var email = HttpContext.Session.GetString("email");
            var password = HttpContext.Session.GetString("password");
            var allUsers = _userService.GetAllUsers().Where(x => x.Status == "Approved" && (bool)x.IsActive);
            var userModel = allUsers.Where(x => x.Email != null && x.Email.ToLower() == email.ToLower() && x.Password == EncryptionHelper.Encrypt(password)).FirstOrDefault();
            if (userModel != null)
            {
                if (userModel.Role == 10001)
                {
                    ViewBag.Users = allUsers.Where(x => x.Role == 10002 && (bool)x.IsActive).Count();
                    ViewBag.Inspectors = allUsers.Where(x => x.Role == 10003 && (bool)x.IsActive).Count();
                    ViewBag.FirstName = HttpContext.Session.GetString("firstName");
                    ViewBag.LastName = HttpContext.Session.GetString("lastName");
                    ViewBag.Email = email;
                    userModel.IsAdmin = userModel.Role == 10001 ? true : false;
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GetUserGrid([DataSourceRequest] DataSourceRequest request)
        {
            var users = _userService.GetAllUsers().Where(x => (bool)x.IsActive && x.Status == "Approved").Select(x => new UserModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsActive = x.IsActive,
                Role = x.Role,
                RoleName = x.Role == 10001 ? "Admin" : x.Role == 10002 ? "Client" : x.Role == 10003 ? "Inspector" : string.Empty,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                Timezone = x.Timezone,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                UserName = x.UserName
            }).ToList();
            var usersGrid = users.ToDataSourceResult(request);
            return Json(usersGrid);
        }

        public ActionResult GetUserRequestGrid([DataSourceRequest] DataSourceRequest request)
        {
            var users = _userService.GetAllUsers().Where(x => (bool)x.IsActive && x.Status == "Waiting").Select(x => new UserModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsActive = x.IsActive,
                Role = x.Role,
                Company = x.Company,
                Country = x.Country,
                RoleName = x.Role == 10001 ? "Admin" : x.Role == 10002 ? "Client" : x.Role == 10003 ? "Inspector" : string.Empty,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                Timezone = x.Timezone,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                UserName = x.UserName
            }).ToList();
            var usersGrid = users.ToDataSourceResult(request);
            return Json(usersGrid);
        }

        #region Add/Edit User Popup
        /// <summary>
        /// Add/Edit User Popup
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddEditUser(int Id)
        {
            try
            {
                UserModel model = new UserModel();
                if (Id > 0)
                {
                    model = _userService.GetUserById(Id);
                    model.dropdownBinderModel = _lookupService.GetAllRoles().Where(x => x.SeqKey != 10001).Select(x => new DropdownBinderModel
                    {
                        Id = x.SeqKey,
                        DisplayName = x.Name
                    }).ToList();
                    model.Password = EncryptionHelper.Decrypt(model.Password);
                    return PartialView(ADD_EDIT_USER_VIEW, model);
                }
                else
                {
                    model.dropdownBinderModel = _lookupService.GetAllRoles().Where(x => x.SeqKey != 10001).Select(x => new DropdownBinderModel
                    {
                        Id = x.SeqKey,
                        DisplayName = x.Name
                    }).ToList();
                    return PartialView(ADD_EDIT_USER_VIEW, model);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region Add/Edit User
        /// <summary>
        /// Add/Edit User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEditUser(UserModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                if (model.Id > 0)
                {
                    responseModel.Message = USER_UPDATED;
                }
                else
                {
                    responseModel.Message = USER_SAVED;
                }
                model.Status = "Approved";
                _userService.InsertUpdateUser(model);
                return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }
        #endregion

        #region Add/Edit User Popup
        /// <summary>
        /// Add/Edit User Popup
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddEditUserRequest(int Id, string Status)
        {
            try
            {
                List<string> country = new List<string>();
                UserModel model = new UserModel();
                CultureInfo[] getCulture = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (var item in getCulture)
                {
                    RegionInfo regionInfo = new RegionInfo(item.LCID);
                    if (!country.Contains(regionInfo.EnglishName))
                    {
                        country.Add(regionInfo.EnglishName);
                    }
                }
                country.Sort();
                if (Id > 0)
                {
                    model = _userService.GetUserById(Id);
                    model.Status = Status;
                    model.dropdownBinderModel = _lookupService.GetAllRoles().Where(x => x.SeqKey != 10001).Select(x => new DropdownBinderModel
                    {
                        Id = x.SeqKey,
                        DisplayName = x.Name
                    }).ToList();
                    model.dropdownBinderModel1 = country.Select(x => new DropdownBinderModel
                    {
                        DisplayName = x
                    }).ToList();
                    model.Password = EncryptionHelper.Decrypt(model.Password);
                    return PartialView(ADD_EDIT_USER_REQUEST_VIEW, model);
                }
                else
                {
                    model.dropdownBinderModel = _lookupService.GetAllRoles().Where(x => x.SeqKey != 10001).Select(x => new DropdownBinderModel
                    {
                        Id = x.SeqKey,
                        DisplayName = x.Name
                    }).ToList();
                    
                    model.dropdownBinderModel1 = country.Select(x => new DropdownBinderModel
                    {
                        DisplayName = x
                    }).ToList();
                    model.Status = Status;
                    return PartialView(ADD_EDIT_USER_REQUEST_VIEW, model);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region Add/Edit User
        /// <summary>
        /// Add/Edit User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEditUserRequest(UserModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                if (model.Id > 0)
                {
                    responseModel.Message = USER_UPDATED;
                }
                else
                {
                    responseModel.Message = USER_SAVED;
                }
                _userService.InsertUpdateUser(model);

                if (model.Status == "Approved")
                {
                    var body = $"<p>" +
                                               //$"{logo}" +
                                               $"<p><strong>Dear [FullName],</strong></p>" +
                                               $"<p>Your sign up approval request is approved by Admin</p>" +
                                               $"<p>User Created On: {DateTime.Now}</p>" +
                                               $"<p>Thank you</p><p>PrimLink International</p><p>&nbsp;</p>";
                    body = body.Replace("[FullName]", $"{model.FirstName} {model.LastName}");
                    Task.Run(() =>
                    {
                        Email(model.Email, $"Sign up Approval Request", body);
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

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult DeleteUser(int Id)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Delete };
            try
            {
                if (Id > 0)
                {
                    _userService.DeleteUser(Id, 1);
                }
                responseModel.Message = USER_DELETED;
                return StatusCode((int)HttpStatusCode.OK, new { Status = HttpStatusCode.OK, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }

        #region Is Email Already Exist
        /// <summary>
        /// Duplicate Email is not allowed
        /// </summary>
        /// Author: Muhammad Areeb Aslam
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult IsEmailAlreadyExist(UserModel model)
        {
            bool val = _userService.IsEmailAlreadyExist(model.Email, model.Id);
            return Json(val);
        }
        #endregion

        #region Is Username Already Exist
        /// <summary>
        /// Duplicate Username is not allowed
        /// </summary>
        /// Author: Muhammad Areeb Aslam
        /// <param name="model"></param>
        /// <returns></returns>
        //public ActionResult IsUsernameAlreadyExist(UserModel model)
        //{
        //    bool val = _userService.IsUsernameAlreadyExist(model.UserName, model.Id);
        //    return Json(val);
        //}
        #endregion

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/Admin/";
        private const string ADD_EDIT_USER_VIEW = VIEW_FOLDER + "AddEditUser.cshtml";
        private const string ADD_EDIT_USER_REQUEST_VIEW = VIEW_FOLDER + "AddEditUserRequest.cshtml";
        private const string REQUEST_USER_VIEW = VIEW_FOLDER + "SignUpRequests.cshtml";
        private const string USER_SAVED = "User saved successfully";
        private const string USER_UPDATED = "User updated successfully";
        private const string USER_DELETED = "User deleted successfully";
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
