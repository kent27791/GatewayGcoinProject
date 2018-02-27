using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure.Core.Configuration;
using Framework.Module.Core.Extentions;
using Framework.Module.Core.Models;
using Framework.WebHost.Extentions;
using Framework.WebHost.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Framework.WebHost
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ISettings _settings;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _settings = configuration.GetCustomizedSettings();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;

            services.LoadInstalledModules(_hostingEnvironment.ContentRootPath);

            services.AddCustomizedDataStore(_settings);
            services.AddCustomizedIdentity();
            services.AddCustomizedAuthentication(_settings);
            services.AddCustomizedAuthorization();
            services.AddCustomizedMvc(GlobalConfiguration.Modules);
            services.AddCustomizedCors();
            services.AddCustomizedAutoMapper();
            services.AddCustomizedSwagger();

            services.AddScoped<SignInManager<User>, CoreSignInManager<User>>();
            services.AddScoped<IWorkContext, WorkContext>();
            services.AddScoped<ISettings, MySettings>(factory => _configuration.GetCustomizedSettings());
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            return services.Build(_configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            //app.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}"); //authentication return 404.
            app.UseCustomizedStaticFiles(env);
            app.UseCustomizedIdentity();
            app.UseCustomizedMvc();
            app.UseCustomizedCors();
            app.UseCustomizedSwagger();
        }
    }
}
