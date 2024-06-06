using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using PrimLink.LoggingFiles.Interface;
using Model.Entity;

namespace PrimLink.Utility
{
    public class ControllerArgument
    {

        internal readonly IHttpContextAccessor CONTEXT;
        internal readonly IConfiguration CONFIGURATION;
        internal readonly IWebHostEnvironment HOSTINGENVIRONMENT;
        internal readonly ILog LOGING;
        internal readonly int USERID;
        internal readonly string USERNAME;
        private UserModel _user;

        #region Internal Properties
        internal UserModel USEROBJ
        {
            get
            {
                if (_user == null)
                {
                    _user = null;
                }
                return _user;
            }
        }

        #endregion

        public ControllerArgument(IHttpContextAccessor context, IConfiguration configuration, ILog log, IWebHostEnvironment hostingEnvironment)
        {
            CONTEXT = context;
            CONFIGURATION = configuration;
            LOGING = log;
            HOSTINGENVIRONMENT = hostingEnvironment;
            USERID = Convert.ToInt32(context.HttpContext.User.FindFirstValue(ClaimTypes.Name));
            USERNAME = context.HttpContext.User.FindFirstValue(ClaimTypes.Actor);
        }
    }
}
