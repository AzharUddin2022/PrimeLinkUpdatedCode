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
using Newtonsoft.Json;
using PrimLink.Utility;
using Service.Implementation;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrimLink.Controllers
{
    public class AttachmentsController : BaseController
    {
        #region Private variables
        private readonly AppSettings _options;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<AttachmentsController> _logger;
        private readonly IUserService _userService;
        private readonly IGeneralInformationService _generalInformationService;
        private readonly ISampleInformationService _sampleInformationService;
        private readonly ISpecificationsInstructionService _specificationsInstructionService;
        private readonly IInspectionScopeAndAQLService _inspectionScopeAndAQLService;
        private readonly IUserFormService _userFormService;
        private readonly IClientAttachmentService _clientAttachmentService;
        private readonly ControllerArgument _args;

        #endregion

        public AttachmentsController(ControllerArgument args, ILogger<AttachmentsController> logger, IWebHostEnvironment webHostEnvironment) : base(args)
        {
            _args = args;
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _userService = new UserService();
            _generalInformationService = new GeneralInformationService();
            _sampleInformationService = new SampleInformationService();
            _specificationsInstructionService = new SpecificationsInstructionService();
            _inspectionScopeAndAQLService = new InspectionScopeAndAQLService();
            _userFormService = new UserFormService();
            _clientAttachmentService = new ClientAttachmentService();
        }
        public IActionResult Index(int userId, bool isAdmin, int userFormId)
        {
            var userRole = HttpContext.Session.GetString("role");
            if (userFormId == 0)
            {
                var newSpecification = new ClientAttachmentModel();
                newSpecification.UserId = userId;
                newSpecification.UserFormId = userFormId;
                newSpecification.IsAdmin = isAdmin;
                if (!isAdmin)
                {
                    newSpecification.IsApproved = false;
                }
                if (userRole == "10003")
                {
                    return PartialView(INDEX_ATTACHMENTS_VIEW_INSPECTOR, newSpecification);

                }
                else
                {
                    return PartialView(INDEX_ATTACHMENTS_VIEW, newSpecification);

                }
            }
            else
            {
                var userModel = _userService.GetUserById(Convert.ToInt32(userId));
                var userForm = _userFormService.GetUserFormById(userFormId);
                if (userModel != null)
                {
                    userModel.IsApproved = userForm.IsApproved == true ? true : false;
                    var specification = _clientAttachmentService.GetClientAttachmentByUserFormId(userFormId).FirstOrDefault();
                    if (specification != null)
                    {
                        specification.IsAdmin = isAdmin;
                        if (!isAdmin)
                        {
                            specification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(INDEX_ATTACHMENTS_VIEW_INSPECTOR, specification);

                        }
                        else
                        {
                            return PartialView(INDEX_ATTACHMENTS_VIEW, specification);

                        }
                    }
                    else
                    {
                        var newSpecification = new ClientAttachmentModel();
                        newSpecification.UserId = userModel.Id;
                        newSpecification.IsAdmin = isAdmin;
                        newSpecification.UserFormId = userFormId;
                        if (!isAdmin)
                        {
                            newSpecification.IsApproved = userModel.IsApproved == true ? true : false;
                        }
                        if (userRole == "10003")
                        {
                            return PartialView(INDEX_ATTACHMENTS_VIEW_INSPECTOR, newSpecification);

                        }
                        else
                        {
                            return PartialView(INDEX_ATTACHMENTS_VIEW, newSpecification);

                        }
                    }

                }
                else
                {
                    var newSpecification = new ClientAttachmentModel();
                    newSpecification.UserId = userId;
                    newSpecification.UserFormId = userFormId;
                    newSpecification.IsAdmin = isAdmin;
                    if (!isAdmin)
                    {
                        newSpecification.IsApproved = userForm.IsApproved == true ? true : false;
                    }
                    if (userRole == "10003")
                    {
                        return PartialView(INDEX_ATTACHMENTS_VIEW_INSPECTOR, newSpecification);

                    }
                    else
                    {
                        return PartialView(INDEX_ATTACHMENTS_VIEW, newSpecification);

                    }
                }
            }
        }

        public ActionResult GetAttachmentsGrid([DataSourceRequest] DataSourceRequest request, int userId, int userFormId)
        {
            var attachments = _clientAttachmentService.GetClientAttachmentByUserIdAndUserFormId(userId, userFormId).Select(x => new ClientAttachmentModel
            {
                Id = x.Id,
                UserId = x.UserId,
                UserFormId = x.UserFormId,
                FileName = x.FileName,
                FileType = x.FileType,
                FilePath = x.FilePath,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
            var attachmentsGrid = attachments.ToDataSourceResult(request);
            return Json(attachmentsGrid);
        }

        [HttpGet]
        public IActionResult AddEditAttachment(int UserId, int UserFormId)
        {
            try
            {
                ClientAttachmentModel model = new ClientAttachmentModel();
                model.UserId = UserId;
                model.UserFormId = UserFormId;
                return PartialView(ADD_EDIT_ATTACHMENTS_VIEW, model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region Insert Attachments
        /// <summary>
        /// Insert Attachments
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAttachments()
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                responseModel.Message = ATTACHMENTS_SAVED;
                List<ClientAttachmentModel> modelList = new List<ClientAttachmentModel>();
                var files = Request.Form.Files;
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

                Dictionary<string, string>.ValueCollection values = dict.Values;
                
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


                    ClientAttachmentModel model = new ClientAttachmentModel();
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
                                case "Description":
                                    model.Description = keyValue.Value;
                                    break;
                                case "FileType":
                                    model.FileType = keyValue.Value;
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
                                case "IsActive":
                                    model.IsActive = Convert.ToBoolean(keyValue.Value);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    modelList.Add(new ClientAttachmentModel
                    {
                        UserFormId = model.UserFormId,
                        IsAdmin = model.IsAdmin,
                        UserId = model.UserId,
                        FileName = fileName,
                        FilePath = physicalPath,
                        FileType = model.FileType,
                        Description = model.Description,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    });
                }
                _clientAttachmentService.InsertUpdateClientAttachment(modelList);
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
        public ActionResult DeleteAttachment(int Id)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Delete };
            try
            {
                if (Id > 0)
                {
                    var getAttachment = _clientAttachmentService.GetClientAttachmentById(Id);
                    _clientAttachmentService.DeleteClientAttachment(getAttachment.Id, 1);

                    if (System.IO.File.Exists(getAttachment.FilePath))
                    {
                        System.IO.File.Delete(getAttachment.FilePath);
                    }
                }
                responseModel.Message = ATTACHMENTS_DELETED;
                return StatusCode((int)HttpStatusCode.OK, new { Status = HttpStatusCode.OK, Data = responseModel });
            }
            catch (Exception ex)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }

        public IActionResult DownloadAttachment(int Id)
        {
            try
            {
                var model = _clientAttachmentService.GetClientAttachmentById(Id);
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

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        #region Private Constant
        /// <summary>
        /// Summary: Private constants for page level
        /// </summary>
        private const string VIEW_FOLDER = "~/Views/Attachments/";
        private const string VIEW_FOLDER_INSPECTOR = "~/Views/AttachmentsInspector/";
        private const string INDEX_ATTACHMENTS_VIEW = VIEW_FOLDER + "Index.cshtml";
        private const string INDEX_ATTACHMENTS_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "Index.cshtml";
        private const string ADD_EDIT_ATTACHMENTS_VIEW = VIEW_FOLDER + "AddEditAttachments.cshtml";
        private const string ADD_EDIT_ATTACHMENTS_VIEW_INSPECTOR = VIEW_FOLDER_INSPECTOR + "AddEditAttachments.cshtml";
        private const string ATTACHMENTS_SAVED = "Attachments saved successfully";
        private const string ATTACHMENTS_UPDATED = "Attachments updated successfully";
        private const string ATTACHMENTS_DELETED = "Attachment deleted successfully";
        private const string IMAGE_PATH_SPLIT = "/";
        private const string TEMP_FILE_PATH = "temp_files";
        private const string FOLDER = "Attachments";
        private const string SOMETHING_WENT_WRONG = "Something went wrong";
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
