using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;


namespace PrimLink.Helper
{
    public static class AppServicesHelper
    {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static HttpContext HttpContext_Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }
        /// <summary>
        /// Configuration settings from appsetting.json.
        /// </summary>
        public static CacheConnectionString Config
        {
            get
            {
                //This works to get file changes.
                var s = services.GetService(typeof(IOptionsMonitor<CacheConnectionString>)) as IOptionsMonitor<CacheConnectionString>;
                CacheConnectionString config = s.CurrentValue;
                config.DefaultConnection = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_CacheConnectionString") == null
                    ? config.DefaultConnection
                    : Environment.GetEnvironmentVariable("CUSTOMCONNSTR_CacheConnectionString");

                return config;
            }
        }
    }
}
