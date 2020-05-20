using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IMRL.WhatsInMyFridge.Core.Identity;
//using IMRL.WhatsInMyFridge.Services;
using IMRL.WhatsInMyFridge.Services.Identity;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using IMRL.WhatsInMyFridge.DataAccess.SqlServer;
using IMRL.WhatsInMyFridge.DataAccess.SqlServer.Repositories;

namespace IMRL.WhatsInMyFridge.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(/*options => options.ResourcesPath = "Resources"*/);
            services.AddControllersWithViews();
            services.AddTransient<WhatsInMyFridgeContext>(_ =>
            {
                var config = _.GetService<IConfiguration>();
                var connString = config.GetConnectionString("WhatsInMyFridge");
                return new WhatsInMyFridgeContext(connString);
            });
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<ICustomersService, CustomersService>();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.AddIdentity<User, Role>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            services.AddAuthentication()
                .AddCookie(opt =>
                {
                    opt.LoginPath = "Account/Login";
                    opt.LogoutPath = "Account/Logout";
                    opt.AccessDeniedPath = "Account/Denied";
                });
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IUserPasswordStore<User>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //var supportedCultures = new[]
            //{
            //    new CultureInfo("ro-RO")
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("ro-RO"),
            //    // Formatting numbers, dates, etc.
            //    SupportedCultures = supportedCultures,
            //    // UI strings that we have localized.
            //    SupportedUICultures = supportedCultures
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null, "Login/Login", new { area = "Login", controller = "Authentication", action = "Login" });                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
