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
using System.Net;

namespace PrimLink.Controllers
{
    public class SampleInformationController : BaseController
    {
        #region Private variables
        private readonly AppSettings _options;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<SampleInformationController> _logger;
        private readonly IUserService _userService;
        private readonly IUserFormService _userFormService;
        private readonly IApplicationLookupService _lookupService;
        private readonly ISampleInformationService _sampleInformationService;
        private readonly ControllerArgument _args;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        /// <param name="logger"></param>
        /// <param name="webHostEnvironment"></param>
        public SampleInformationController(ControllerArgument args, ILogger<SampleInformationController> logger, IWebHostEnvironment webHostEnvironment) : base(args)
        {
            _logger = logger;
            _args = args;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _userFormService = new UserFormService();
            _lookupService = new ApplicationLookupService();
            _sampleInformationService = new SampleInformationService();
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
                var newSpecification = new SampleInformationModel();
                newSpecification.UserId = userId;
                newSpecification.UserFormId = userFormId;
                newSpecification.IsAdmin = isAdmin;
                if (!isAdmin)
                {
                    newSpecification.IsApproved = false;
                }
                if (userRole == "10003")
                {
                    return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW_INSPECTOR, newSpecification);

                }
                else
                {
                    return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW, newSpecification);

                }
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var specification = _sampleInformationService.GetSampleInformationByUserFormId(userFormId);
                    if (specification != null)
                    {
                        specification.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            specification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW_INSPECTOR, specification);

                        }
                        else
                        {
                            return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW, specification);

                        }
                    }
                    else
                    {
                        var newSpecification = new SampleInformationModel();
                        newSpecification.UserId = userModel.Id;
                        newSpecification.IsAdmin = isAdmin;
                        newSpecification.UserFormId = userFormId;
                        if (!isAdmin)
                        {
                            newSpecification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW_INSPECTOR, newSpecification);

                        }
                        else
                        {
                            return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW, newSpecification);

                        }
                    }

                }
                else
                {
                    var newSpecification = new SampleInformationModel();
                    newSpecification.UserId = userId;
                    newSpecification.UserFormId = userFormId;
                    newSpecification.IsAdmin = isAdmin;
                    if (!isAdmin)
                    {
                        newSpecification.IsApproved = userForm.IsApproved == true ? true : false;
                    }
                    if (userRole == "10003")
                    {
                        return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW_INSPECTOR, newSpecification);

                    }
                    else
                    {
                        return PartialView(ADD_EDIT_SAMPLE_INFORMATION_VIEW, newSpecification);

                    }
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
        public IActionResult InsertUpdateSampleInformation(SampleInformationModel model)
        {
            try
            {
                var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };

                if (model.Id > 0)
                {
                    responseModel.Message = SAMPLE_INFORMATION_UPDATED;
                }
                else
                {
                    responseModel.Message = SAMPLE_INFORMATION_SAVED;
                }
                model.IsCollectSample = model.IsCollectSample == true ? true : false;
                model.IsReferSample = model.IsReferSample == true ? true : false;

                if (model.UserFormId == null || model.UserFormId == 0)
                {
                    var userForm = new UserFormModel();
                    userForm.UserId = model.UserId;
                    userForm = _userFormService.InsertUpdateUserForm(userForm);

                    model.UserFormId = userForm.Id;
                }

                _sampleInformationService.InsertUpdateSampleInformation(model);
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
        private const string VIEW_FOLDER = "~/Views/SampleInformation/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/SampleInformationInspector/";
        private const string ADD_EDIT_SAMPLE_INFORMATION_VIEW = VIEW_FOLDER + "_SampleInformation.cshtml";
        private const string ADD_EDIT_SAMPLE_INFORMATION_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "_SampleInformation.cshtml";
        private const string SAMPLE_INFORMATION_SAVED = "Sample Information saved successfully";
        private const string SAMPLE_INFORMATION_UPDATED = "Sample Information updated successfully";
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
