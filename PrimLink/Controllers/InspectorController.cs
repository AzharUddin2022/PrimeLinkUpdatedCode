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

namespace PrimLink.Controllers
{
    public class InspectorController : Controller
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<InspectorController> _logger;
        private readonly IUserService _userService;
        private readonly IGeneralInformationService _generalInformationService;
        private readonly ISampleInformationService _sampleInformationService;
        private readonly ISpecificationsInstructionService _specificationsInstructionService;
        private readonly IInspectionScopeAndAQLService _inspectionScopeAndAQLService;
        private readonly IUserFormService _userFormService;
        private readonly IInspectorAllocationService _inspectorAllocationService;

        #endregion

        public InspectorController(ILogger<InspectorController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _generalInformationService = new GeneralInformationService();
            _sampleInformationService = new SampleInformationService();
            _specificationsInstructionService = new SpecificationsInstructionService();
            _inspectionScopeAndAQLService = new InspectionScopeAndAQLService();
            _userFormService = new UserFormService();
            _inspectorAllocationService = new InspectorAllocationService();
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("userId");
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
        public IActionResult GetUserFormGrid([DataSourceRequest] DataSourceRequest request, int userId)
        {
            var inspectorAllocated = _inspectorAllocationService.GetAllInspectorAllocations();
            var formIds = inspectorAllocated.Where(x => x.InspectorId == userId).Select(y => y.UserFormId).ToList();
            var userIds = inspectorAllocated.Where(x => x.InspectorId == userId).Select(y => y.UserId).ToList();
            var forms = _generalInformationService.GetAllGeneralInformations().Where(x => userIds.Contains(x.UserId)).ToList();
            var inspector = _userService.GetUserById(userId);
            var client = _userService.GetAllUsers().Where(x => userIds.Contains(x.Id)).FirstOrDefault();
            var userform = _userFormService.GetAllUserForms().Where(x => formIds.Contains(x.Id)).Select(x => new UserFormModel
            {
                Id = x.Id,
                InspectorName = inspector == null ? string.Empty : inspector.FirstName + " " + inspector.LastName,
                ClientName = client == null ? string.Empty : client.FirstName + " " + client.LastName,
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
            }).ToList();
            var usersGrid = userform.ToDataSourceResult(request);
            return Json(usersGrid);
        }
    }
}
