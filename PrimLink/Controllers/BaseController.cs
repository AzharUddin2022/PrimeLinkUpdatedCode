using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using PrimLink.LoggingFiles.Interface;
using Component;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Model.Common.Helper;
using Newtonsoft.Json;
using PrimLink.Utility;

namespace PrimLink.Controllers
{
    public class BaseController : Controller
    {
        #region private variables
        readonly ControllerArgument _args;
        public static string CDN_URL = "https://assets.tccmobile.com/public/Ticketing/image/";
        public static string HOME_URL = "";
        public static int MODULE_ID = 0;
        public static string MODULE_NAME = "";
        protected ILog Log => _args.LOGING;
        protected IWebHostEnvironment HostingEnvironment => _args.HOSTINGENVIRONMENT;
        private const string COMMA = ",";
        private const string USER = "User";
        private const string GROUP = "Group";
        private const string GROUP_MODULE = "GroupModule";
        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        private const string UNDER_SCORE = "_";

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        public BaseController(ControllerArgument args)
        {
            _args = args;
            CDN_URL = args.CONFIGURATION.GetSection("AppSettings:CDNUrl").Value;
            HOME_URL = args.CONFIGURATION.GetSection("HomeUrl").Value;
            MODULE_ID = Convert.ToInt32(args.CONFIGURATION.GetSection("ModuleId").Value);
            MODULE_NAME = args.CONFIGURATION.GetSection("Module").Value;

        }
        #endregion
        #region Error
        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        protected IActionResult Error()
        {
            return base.StatusCode((int)HttpStatusCode.NotImplemented);
        }
        #endregion

        #region Render PartialView ToString
        /// <summary>
        /// this method converts view into a string
        /// </summary>
        /// <param name="viewName">partial view name</param>
        /// <param name="model">model to be passed in the view</param>
        /// <param name="partial"></param>
        /// <returns>html string</returns>
        public async Task<string> RenderPartialViewToString(string viewName, object model, bool partial = false)
        {
            var viewEngine = this.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult =
                    viewEngine.FindView(ControllerContext, viewName, false);
                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
}