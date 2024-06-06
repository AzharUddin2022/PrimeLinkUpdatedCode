using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Model.Common.Utilities;
using Newtonsoft.Json.Serialization;
using PrimLink.Utility;
using Repository.Entity;
using System;
using System.IO;

namespace PrimLink
{
    public class Startup
    {
        #region Public & Private Properties
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }
        private const string DEFAULT_CONNECTION = "DefaultConnection";
        private const string APP_SETTING = "AppSettings";
        private const string APP_SETTINGS_DOT_JSON = "appsettings.json";
        private const string COOKIE_NAME = "CustomSSO:CookieName";
        private const string LOGIN_URL = "/Login/Index";
        private const string LOGOUT_URL = "/Login/Logout";
        private const string APPLICATION_NAME = "PrimLink";
        private const string COLON_WITH_FORWARDSLASH = "://";
        private const string SESSION_TIMEOUT_IN_SECOND = "sessionTimeOutDurationInSeconds";
        #endregion

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile(APP_SETTINGS_DOT_JSON, optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<PrimLinkDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString(DEFAULT_CONNECTION)));
            services.Configure<AppSettings>(options => Configuration.GetSection(APP_SETTING).Bind(options));
            services.AddDistributedMemoryCache();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<PrimLink.LoggingFiles.Interface.ILog>(new PrimLink.LoggingFiles.Implementation.Log(NLog.LogManager.GetLogger(APPLICATION_NAME)));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
			services.AddKendo();
			services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddScoped<ControllerArgument>();
            services.AddHttpClient();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
