using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Common;
using Model.Common.Utilities;
using Model.Entity;
using PrimLink.Utility;
using Service.Implementation;
using Service.Interface;
using System;
using System.Data;
using System.Net;

namespace PrimLink.Controllers
{
    public class InspectionScopeAndAQLController : BaseController
    {
        #region Private variables
        private readonly AppSettings _options;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<InspectionScopeAndAQLController> _logger;
        private readonly IUserService _userService;
        private readonly IUserFormService _userFormService;
        private readonly IApplicationLookupService _lookupService;
        private readonly IInspectionScopeAndAQLService _inspectionScopeAndAQLRepository;
        private readonly ControllerArgument _args;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        /// <param name="logger"></param>
        /// <param name="webHostEnvironment"></param>
        public InspectionScopeAndAQLController(ControllerArgument args, ILogger<InspectionScopeAndAQLController> logger, IWebHostEnvironment webHostEnvironment) : base(args)
        {
            _logger = logger;
            _args = args;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _userFormService = new UserFormService();
            _lookupService = new ApplicationLookupService();
            _inspectionScopeAndAQLRepository = new InspectionScopeAndAQLService();
        }
        #endregion

        #region Default View
        /// <summary>
        /// Default View
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IActionResult Index(int userId, bool isAdmin, int userFormId)
        {
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
                    return PartialView(ADD_EDIT_INSPECTION_VIEW_INSPECTOR, newSpecification);
                }
                else
                {
                    return PartialView(ADD_EDIT_INSPECTION_VIEW, newSpecification);
                }
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var specification = _inspectionScopeAndAQLRepository.GetInspectionScopeAndAQLByUserFormId(userFormId);
                    if (specification != null)
                    {
                        specification.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            specification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_INSPECTION_VIEW_INSPECTOR, specification);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_INSPECTION_VIEW, specification);
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
                            return PartialView(ADD_EDIT_INSPECTION_VIEW_INSPECTOR, newSpecification);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_INSPECTION_VIEW, newSpecification);
                        }
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }
        #endregion

        #region Add/Edit Sample Information
        /// <summary>
        /// Add/Edit Sample Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertUpdateInspectionScopeAndAQL(InspectionScopeAndAQLModel model)
        {
            try
            {
                var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };

                if (model.Id > 0)
                {
                    responseModel.Message = INSPECTION_UPDATED;
                }
                else
                {
                    responseModel.Message = INSPECTION_SAVED;
                }
                model.IsDimensionCheck = model.IsDimensionCheck == true ? true : false;
                model.IsFunctionCheck = model.IsFunctionCheck == true ? true : false;
                model.IsOnSiteTest = model.IsOnSiteTest == true ? true : false;
                model.IsPkgePackShipCheck = model.IsPkgePackShipCheck == true ? true : false;
                model.IsProductLabelCheck = model.IsProductLabelCheck == true ? true : false;
                model.IsQuantityCheck = model.IsQuantityCheck == true ? true : false;

                if (model.UserFormId == null || model.UserFormId == 0)
                {
                    var userForm = new UserFormModel();
                    userForm.UserId = model.UserId;
                    userForm = _userFormService.InsertUpdateUserForm(userForm);

                    model.UserFormId = userForm.Id;
                }

                _inspectionScopeAndAQLRepository.InsertUpdateInspectionScopeAndAQL(model);
                return StatusCode((int)HttpStatusCode.OK, new { Status = 200, Data = responseModel });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            //finally
            //{
            //    var path = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH);
            //    DirectoryInfo di = new DirectoryInfo(path);
            //    if (di.Exists == true && di.GetFiles().Length > 0)
            //    {
            //        foreach (FileInfo file in di.GetFiles())
            //        {
            //            file.Delete();
            //        }
            //        foreach (DirectoryInfo dir in di.GetDirectories())
            //        {
            //            dir.Delete(true);
            //        }
            //    }
            //}
        }
        #endregion

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/InspectionScopeAndAQL/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/InspectionScopeAndAQLInspector/";
        private const string ADD_EDIT_INSPECTION_VIEW = VIEW_FOLDER + "_InspectionScopeAndAQL.cshtml";
        private const string ADD_EDIT_INSPECTION_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "_InspectionScopeAndAQL.cshtml";
        private const string INSPECTION_SAVED = "Inspection Scope And AQL successfully";
        private const string INSPECTION_UPDATED = "Inspection Scope And AQL updated successfully";
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
