using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Implementation;
using Service.Interface;
using System.Linq;
using Model.Common.Utilities;
using System;
using Model.Common;
using System.Net;
using Kendo.Mvc.UI;
using Model.Entity;
using Kendo.Mvc.Extensions;
using MailKit.Net.Smtp;
using MimeKit;
using PrimLink.Utility;
using Repository.Entity;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class HomeController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IGeneralInformationService _generalInformationService;
        private readonly ISampleInformationService _sampleInformationService;
        private readonly ISpecificationsInstructionService _specificationsInstructionService;
        private readonly IInspectionScopeAndAQLService _inspectionScopeAndAQLService;
        private readonly IUserFormService _userFormService;

        #endregion

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _generalInformationService = new GeneralInformationService();
            _sampleInformationService = new SampleInformationService();
            _specificationsInstructionService = new SpecificationsInstructionService();
            _inspectionScopeAndAQLService = new InspectionScopeAndAQLService();
            _userFormService = new UserFormService();
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("userId");
            var isAdmin = HttpContext.Session.GetString("isAdmin");
            //var userName = HttpContext.Session.GetString("userName");
            //var password = HttpContext.Session.GetString("password");
            if (!string.IsNullOrEmpty(userId))
            {
                var userModel1 = _userService.GetUserById(Convert.ToInt32(userId));
                ViewBag.FirstName = HttpContext.Session.GetString("firstName");
                ViewBag.LastName = HttpContext.Session.GetString("lastName");
                ViewBag.Email = HttpContext.Session.GetString("email");
                if (userModel1 != null)
                {
                    return View(userModel1);
                }
                else
                {
                    var userForms = new UserModel();
                    userForms.Id = Convert.ToInt32(userId);
                    return View(userForms);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult UserForm(int Id, int userFormId, bool isAdmin)
        {
            var userId = HttpContext.Session.GetString("userId");
            //var userName = HttpContext.Session.GetString("userName");
            //var password = HttpContext.Session.GetString("password");
            if (!string.IsNullOrEmpty(userId))
            {
                var userModel = _userService.GetUserById(Id);
                var userForm = _userFormService.GetUserFormById(userFormId);
                ViewBag.FirstName = HttpContext.Session.GetString("firstName");
                ViewBag.LastName = HttpContext.Session.GetString("lastName");
                ViewBag.Email = HttpContext.Session.GetString("email");
                ViewBag.Role = HttpContext.Session.GetString("role");
                if (userModel != null)
                {
                    userModel.UserFormId = userFormId;
                    userModel.IsAdmin = isAdmin;
                    userModel.IsApproved = userForm == null ? false : userForm.IsApproved == true ? true : false;
                    userModel.RoleName = ViewBag.Role == "10001" ? "Admin" : ViewBag.Role == "10002" ? "Client" : "Inspector";

                    return View(userModel);
                }
                else
                {
                    var user = new UserModel();
                    user.Id = Convert.ToInt32(userId);
                    user.UserFormId = userFormId;
                    user.IsAdmin = isAdmin;
                    user.IsApproved = false;
                    return View(user);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Approved(int Id, bool IsAdmin, int userFormId)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            var userModel = _userService.GetUserById(Id);
            var userForm = _userFormService.GetUserFormById(userFormId);
            var generalInfo = _generalInformationService.GetGeneralInformationByUserFormId(userFormId);
            if (userModel != null)
            {
                if (IsAdmin == false)
                {
                    responseModel.Message = "Form is approved and sent to Admin.";
                    responseModel.IsAdmin = false;
                    userModel.Password = EncryptionHelper.Decrypt(userModel.Password);
                    _userService.InsertUpdateUser(userModel);


                    var form = new UserFormModel();
                    form.Id = userForm.Id;
                    form.UserId = Id;
                    form.IsApproved = true;
                    _userFormService.InsertUpdateUserForm(form);

                    var body = $"<p>" +
                           //$"{logo}" +
                           $"<p><strong>Dear Admin,</strong></p>" +
                           $"<p>Here is the email of [FullName] for Form Approval Request</p>" +
                           $"<p>Form Id: {userFormId}</p>" +
                           $"<p>Form Created On: {generalInfo.CreatedDate}</p>" +
                           $"<p>Thank you</p><p>PrimLink International</p><p>&nbsp;</p>";
                    body = body.Replace("[FullName]", $"{userModel.FirstName} {userModel.LastName}");
                    EmailToAdmin("report@primlink.com", $"Form Approval Request: {userFormId}", body, userModel.FirstName + " " + userModel.LastName);

                }
                else
                {
                    // email shoot
                    responseModel.IsAdmin = true;
                    if (userForm != null)
                    {
                        userModel.Password = EncryptionHelper.Decrypt(userModel.Password);
                        userModel.IsApproved = true;
                        _userService.InsertUpdateUser(userModel);
                        var clientEmail = userModel.Email;

                        if (generalInfo != null)
                        {
                            var factory = generalInfo.Factory;
                            var body = $"<p>" +
                                         //$"{logo}" +
                                         $"<p><strong>Please note an inspection scheduled, follow the below link to access:</strong></p>" +
                                         $"<p>Link of system: <a href=\"https://primlinkintl.com/Home/UserForm?Id={Id}&userFormId={userFormId}&IsAdmin=false\">Click Here</a></p>" +
                                         $"<p><strong>Order details:</strong> (PL-0203400-{generalInfo.Id:D4})</p>" +
                                         $"<p>Inspection date: {generalInfo.CreatedDate}</p>" +
                                         $"<p>Product name: {generalInfo.ProductCategory}</p>" +
                                         $"<p>Quantity ordered: {generalInfo.References?.Sum(item => item.Quantity)}</p>" +
                                         $"<p>Man-days: 1.00</p>" +
                                         $"<p>AQF internal reference: 0203400-{generalInfo.Id:D4}</p>" +
                                         $"<p><strong>Factory details:</strong></p>" +
                                         $"<ul><li>Name: {factory.FactoryPreset}</li><li>Address: {factory.Address}</li></ul>" +
                                         $"<p>Thank you</p><p>PrimLink International</p><p>&nbsp;</p>";
                            Task.Run(() =>
                            {
                                Email(clientEmail, $"Form Approved: {userFormId}", body);
                            });

                            var vendor = generalInfo.Vendor;
                            if (vendor != null)
                            {
                                if (vendor.IsVendorEmailIncluded == true)
                                {
                                    if (!string.IsNullOrWhiteSpace(vendor.Email))
                                    {
                                        Task.Run(() =>
                                        {
                                            Email(vendor.Email, "Mission Approved", body);
                                        });
                                    }

                                }

                            }

                            
                            if (factory != null)
                            {
                                if (factory.IsFactoryEmailIncluded == true)
                                {
                                    if (!string.IsNullOrWhiteSpace(factory.Email))
                                    {
                                        Task.Run(() =>
                                        {
                                            Email(factory.Email, "Mission Approved", body);
                                        });
                                        
                                    }

                                }
                            }
                        }

                    }
                }

            }
            return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
        }

        public IActionResult GetUserFormGrid([DataSourceRequest] DataSourceRequest request, int userId)
        {
            var forms = _generalInformationService.GetAllGeneralInformations().Where(x => x.UserId == userId).ToList();
            var user = _userService.GetUserById(userId);
            var userform = _userFormService.GetAllUserForms().Where(x => x.UserId == userId).Select(x => new UserFormModel
            {
                Id = x.Id,
                InspectorName = user == null ? string.Empty : user.FirstName + " " + user.LastName,
                MissionReference = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : $"PL-0203400-{Convert.ToString(forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().Id):D4}",
                ProductLine = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ProductLine,
                ProductCategory = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ProductCategory,
                QuantityUnit = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().QuantityUnit,
                DestinationCountry = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().DestinationCountry,
                ServiceDate = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? null : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ServiceDate,
                ShipmentDate = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? null : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ShipmentDate,
                Approved = x.IsApproved == true ? "Yes" : "No",
                IsActive = x.IsActive,
                IsApproved = x.IsApproved == true ? true : false,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UserId = x.UserId,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
            }).OrderByDescending(x => x.Id).ToList();
            var usersGrid = userform.ToDataSourceResult(request);
            return Json(usersGrid);
        }

        public IActionResult GetUserFormGridAdmin([DataSourceRequest] DataSourceRequest request, int userId)
        {
            var forms = _generalInformationService.GetAllGeneralInformations().Where(x => x.UserId == userId).ToList();
            var user = _userService.GetUserById(userId);
            var userform = _userFormService.GetAllUserForms().Where(x => x.UserId == userId && x.IsApproved == true).Select(x => new UserFormModel
            {
                Id = x.Id,
                MissionReference = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : $"PL-0203400-{Convert.ToString(forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().Id):D4}",
                InspectorName = user == null ? string.Empty : user.FirstName + " " + user.LastName,
                ProductLine = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ProductLine,
                ProductCategory = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ProductCategory,
                QuantityUnit = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().QuantityUnit,
                DestinationCountry = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? string.Empty : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().DestinationCountry,
                ServiceDate = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? null : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ServiceDate,
                ShipmentDate = forms.Where(f => f.UserFormId == x.Id).FirstOrDefault() == null ? null : forms.Where(f => f.UserFormId == x.Id).FirstOrDefault().ShipmentDate,
                Approved = x.IsApproved == true ? "Yes" : "No",
                IsActive = x.IsActive,
                IsApproved = x.IsApproved == true ? true : false,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UserId = x.UserId,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
            }).OrderByDescending(x => x.Id).ToList();
            var usersGrid = userform.ToDataSourceResult(request);
            return Json(usersGrid);
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult DeleteForm(int Id)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Delete };
            try
            {
                if (Id > 0)
                {
                    _userFormService.DeleteUserForm(Id, 1);
                }
                responseModel.Message = "Form Deleted!";
                return StatusCode((int)HttpStatusCode.OK, new { Status = HttpStatusCode.OK, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = "Something Went Wrong!";
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

        public void EmailToAdmin(string toEmail, string subject, string body, string toName)
        {
            if (toEmail != null)
            {
                ConfigurationModel model = new ConfigurationModel();
                model.TLS = true;
                model.SenderEmail = "report@primlink.com";
                model.FromAddress = "report@primlink.com";
                model.Server = "mail.primlink.com";
                model.Port = 465;
                model.SenderName = toName;
                model.UserName = "report@primlink.com";
                model.Password = "report@primlink.com2023";
                model.Domain = "office";
                EmailUtility.SendEmail(toEmail, subject, body, model);
            }
        }
    }
}
