using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Model.Common;
using Model.Common.Utilities;
using Model.Entity;
using Newtonsoft.Json;
using OfficeOpenXml;
using PrimLink.Utility;
using Service.Implementation;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class SpecificationsInstructionsController : BaseController
    {
        #region Private variables
        private readonly AppSettings _options;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<SpecificationsInstructionsController> _logger;
        private readonly IUserService _userService;
        private readonly IUserFormService _userFormService;
        private readonly IApplicationLookupService _lookupService;
        private readonly ISpecificationsInstructionService _specificationsInstructionService;
        private readonly IAttachmentService _attachmentService;
        private readonly ControllerArgument _args;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        /// <param name="logger"></param>
        /// <param name="webHostEnvironment"></param>
        public SpecificationsInstructionsController(ControllerArgument args, ILogger<SpecificationsInstructionsController> logger, IWebHostEnvironment webHostEnvironment) : base(args)
        {
            _logger = logger;
            _args = args;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _userFormService = new UserFormService();
            _lookupService = new ApplicationLookupService();
            _specificationsInstructionService = new SpecificationsInstructionService();
            _attachmentService = new AttachmentService();
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
                var newSpecification = new SpecificationsInstructionModel();
                newSpecification.UserId = userId;
                newSpecification.UserFormId = userFormId;
                newSpecification.IsAdmin = isAdmin;
                if (!isAdmin)
                {
                    newSpecification.IsApproved = false;
                }
                newSpecification.Attachments = new List<AttachmentModel>();
                if (userRole == "10003")
                {
                    return PartialView(ADD_EDIT_SPECIFICATION_VIEW_INSPECTOR, newSpecification);
                }
                else
                {
                    return PartialView(ADD_EDIT_SPECIFICATION_VIEW, newSpecification);
                }
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var specification = _specificationsInstructionService.GetSpecificationsInstructionByUserFormId(userFormId);
                    if (specification != null)
                    {
                        specification.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            specification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        specification.Attachments = _attachmentService.GetAttachmentBySpecificationsInstructionsId(specification.Id);
                        if (specification.Attachments.Count > 0)
                        {
                            specification.Attachments.ForEach(item =>
                            {
                                item.IsApproved = userModel.IsApproved == true ? true : false;
                            });
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_SPECIFICATION_VIEW_INSPECTOR, specification);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_SPECIFICATION_VIEW, specification);
                        }
                    }
                    else
                    {
                        var newSpecification = new SpecificationsInstructionModel();
                        newSpecification.UserId = userModel.Id;
                        newSpecification.IsAdmin = isAdmin;
                        newSpecification.UserFormId = userFormId;
                        if (!isAdmin)
                        {
                            newSpecification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        newSpecification.Attachments = new List<AttachmentModel>();
                        if (userRole == "10003")
                        {
                            return PartialView(ADD_EDIT_SPECIFICATION_VIEW_INSPECTOR, newSpecification);
                        }
                        else
                        {
                            return PartialView(ADD_EDIT_SPECIFICATION_VIEW, newSpecification);
                        }
                    }

                }
                else
                {
                    var newSpecification = new SpecificationsInstructionModel();
                    newSpecification.UserId = userId;
                    newSpecification.UserFormId = userFormId;
                    newSpecification.IsAdmin = isAdmin;
                    if (!isAdmin)
                    {
                        newSpecification.IsApproved = false;
                    }
                    newSpecification.Attachments = new List<AttachmentModel>();
                    if (userRole == "10003")
                    {
                        return PartialView(ADD_EDIT_SPECIFICATION_VIEW_INSPECTOR, newSpecification);
                    }
                    else
                    {
                        return PartialView(ADD_EDIT_SPECIFICATION_VIEW, newSpecification);
                    }
                }
            }
            
        }
        #endregion

        #region Add/Edit Specifications Instructions
        /// <summary>
        /// Add/Edit Specifications Instructions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertUpdateSpecificationsInstructions()
        {
            try
            {
                var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
                SpecificationsInstructionModel model = new SpecificationsInstructionModel();
                var files = Request.Form.Files;
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

                Dictionary<string, string>.ValueCollection values = dict.Values;
                foreach (var item in values)
                {
                    var objectItem = item;
                    var deserializedObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(objectItem);

                    foreach (var keyValue in deserializedObject)
                    {
                        var keyItem = keyValue.Key;

                        switch (keyItem)
                        {
                            case "Id":
                                var DocId = keyValue.Value == "" ? null : keyValue.Value;
                                model.Id = Convert.ToInt32(DocId);
                                break;
                            case "MeasurementPoints":
                                model.MeasurementPoints = Convert.ToInt32(keyValue.Value);
                                break;
                            case "Sizes":
                                model.Sizes = Convert.ToInt32(keyValue.Value);
                                break;
                            case "UserFormId":
                                model.UserFormId = Convert.ToInt32(keyValue.Value);
                                break;
                            case "UserId":
                                model.UserId = Convert.ToInt32(keyValue.Value);
                                break;
                            case "IsAdmin":
                                model.IsAdmin = Convert.ToBoolean(keyValue.Value);
                                break;
                            case "FinalReportToPerson":
                                model.FinalReportToPerson = Convert.ToBoolean(keyValue.Value);
                                break;
                            case "FinalReportToVendor":
                                model.FinalReportToVendor = Convert.ToBoolean(keyValue.Value);
                                break;
                            case "IsEmailIncluded":
                                model.IsEmailIncluded = Convert.ToBoolean(keyValue.Value);
                                break;
                            case "IsUrgent":
                                model.IsUrgent = Convert.ToBoolean(keyValue.Value);
                                break;
                            case "IsActive":
                                model.IsActive = Convert.ToBoolean(keyValue.Value);
                                break;
                            default:
                                break;
                        }
                    }

                }
                if (model.Id > 0)
                {
                    responseModel.Message = SPECIFICATION_INSTRUCTION_UPDATED;
                }
                else
                {
                    responseModel.Message = SPECIFICATION_INSTRUCTION_SAVED;
                }
                model.IsEmailIncluded = model.IsEmailIncluded == true ? true : false;
                model.IsUrgent = model.IsUrgent == true ? true : false;
                model.FinalReportToPerson = model.FinalReportToPerson == true ? true : false;
                model.FinalReportToVendor = model.FinalReportToVendor == true ? true : false;

                if (model.UserFormId == null || model.UserFormId == 0)
                {
                    var userForm = new UserFormModel();
                    userForm.UserId = model.UserId;
                    userForm = _userFormService.InsertUpdateUserForm(userForm);

                    model.UserFormId = userForm.Id;
                }

                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH, fileName);
                    var path = Path.Combine(WebHostEnvironment.WebRootPath, TEMP_FILE_PATH);
                    var fileExt = Path.GetExtension(fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    model.Attachments.Add(new AttachmentModel
                    {
                        FileName = fileName,
                        FilePath = physicalPath,
                        FileType = fileExt,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    });
                }

                _specificationsInstructionService.InsertUpdateSpecificationsInstruction(model);
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

        public IActionResult DeleteAttachment(int Id)
        {
            try
            {
                _attachmentService.DeleteAttachment(Id, 0);
                return StatusCode((int)HttpStatusCode.OK, new { Status = 200 });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        public IActionResult DownloadAttachment(int Id)
        {
            try
            {
                var model = _attachmentService.GetAttachmentById(Id);
                if (model == null)
                {
                    return NotFound();
                }
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(model.FilePath, FileMode.Open))
                {
                    stream.CopyTo(memoryStream);
                }

                memoryStream.Position = 0;
                return File(memoryStream, "application/octet-stream", Path.GetFileName(model.FilePath));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/SpecificationsInstructions/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/SpecificationsInstructionsInspector/";
        private const string ADD_EDIT_SPECIFICATION_VIEW = VIEW_FOLDER + "_SpecificationsInstructions.cshtml";
        private const string ADD_EDIT_SPECIFICATION_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "_SpecificationsInstructions.cshtml";
        private const string SPECIFICATION_INSTRUCTION_SAVED = "Specifications Instructions saved successfully";
        private const string SPECIFICATION_INSTRUCTION_UPDATED = "Specifications Instructions updated successfully";
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
