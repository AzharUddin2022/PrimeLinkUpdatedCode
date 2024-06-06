using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Newtonsoft.Json;
using Service.Implementation;
using Service.Interface;
using System.Data;
using System.Linq;
using Model.Common.Utilities;
using Component;
using System;
using Model.Common;
using System.Net;
using Repository.Entity;
using PrimLink.Utility;
using System.Globalization;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;

namespace PrimLink.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public LoginController()
        {
            _userService = new UserService();
        }
        #endregion

        #region Default View
        /// <summary>
        /// Default View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("email");
            var password = HttpContext.Session.GetString("password");
            var role = HttpContext.Session.GetString("role");
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (role == "10001")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (role == "10003")
                {
                    return RedirectToAction("Index", "Inspector");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            UserModel model = new UserModel();
            return View(model);
        }
        #endregion

        #region On Login Submit
        /// <summary>
        /// On Login Submit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel model, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {

                    var allUsers = _userService.GetAllUsers().Where(x => x.Status == "Approved" && (bool)x.IsActive);
                    var userModel = allUsers.Where(x => x.Email != null && x.Email.ToLower() == model.Email.ToLower() && x.Password == EncryptionHelper.Encrypt(model.Password)).FirstOrDefault();
                    if (userModel != null)
                    {
                        HttpContext.Session.SetString("userId", userModel.Id.ToString());
                        //HttpContext.Session.SetString("userName", model.UserName);
                        HttpContext.Session.SetString("email", model.Email.ToLower());
                        HttpContext.Session.SetString("password", model.Password);
                        HttpContext.Session.SetString("role", userModel.Role.ToString());
                        HttpContext.Session.SetString("firstName", userModel.FirstName);
                        HttpContext.Session.SetString("lastName", userModel.LastName == null ? string.Empty : userModel.LastName);
                        TempData["user"] = JsonConvert.SerializeObject(userModel);
                        if (userModel.Role == 10001)
                        {
                            HttpContext.Session.SetString("isAdmin", "true");
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (userModel.Role == 10003)
                        {
                            HttpContext.Session.SetString("isInspector", "true");
                            return RedirectToAction("Index", "Inspector");
                        }
                        else
                        {
                            HttpContext.Session.SetString("isAdmin", "false");
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Email or Password is incorrect";
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }


        }
        #endregion

        #region Sign Up Popup
        /// <summary>
        /// Sign Up Popup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignUpPopup()
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
                model.dropdownBinderModel1 = country.Select(x => new DropdownBinderModel
                {
                    DisplayName = x
                }).ToList();
                return PartialView(SIGN_UP_VIEW, model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region Sign Up User
        /// <summary>
        /// Sign Up User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SignUpUser(UserModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                responseModel.Message = SIGN_UP_SUCCESS;
                model.Status = "Waiting";
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                _userService.InsertUpdateUser(model);

                var body = $"<p>" +
                           //$"{logo}" +
                           $"<p><strong>Dear Admin,</strong></p>" +
                           $"<p>User: [FullName] is waiting for Sign up Approval Request</p>" +
                           $"<p>User Created On: {model.CreatedDate}</p>" +
                           $"<p>Thank you</p><p>PrimLink International</p><p>&nbsp;</p>";
                body = body.Replace("[FullName]", $"{model.FirstName} {model.LastName}");
                Task.Run(() =>
                {
                    EmailToAdmin("report@primlink.com", $"Sign up Approval Request", body);
                });


                return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }
        #endregion

        #region Logout
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("password");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("isAdmin");
            HttpContext.Session.Remove("isInspector");
            return RedirectToAction("Index", "Login");
        }
        #endregion

        public void EmailToAdmin(string toEmail, string subject, string body)
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
        private const string VIEW_FOLDER = "~/Views/Login/";
        private const string SIGN_UP_VIEW = VIEW_FOLDER + "SignUp.cshtml";
        private const string SIGN_UP_SUCCESS = "Sign up successful. Please wait for admin approval. Thank you!";
        private const string SOMETHING_WENT_WRONG = "Something went wrong";
        #endregion
    }
}
