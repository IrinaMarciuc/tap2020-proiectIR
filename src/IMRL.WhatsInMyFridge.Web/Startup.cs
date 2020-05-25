using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using IMRL.WhatsInMyFridge.Services;
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
                var connString = config.GetConnectionString("Fridge");
                return new WhatsInMyFridgeContext(connString);
            });
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IUserPasswordStore<User>, UserStore>();
            services.AddTransient<IAddRecipeService, AddRecipeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISearchRecipeService, SearchRecipeService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddMvc();
            services.AddIdentityCore<User>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            services.AddAuthentication();

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


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null, "SearchRecipe/SearchRecipe", new { area = "SearchRecipe", controller = "SearchRecipe", action = "SearchRecipe" });
                endpoints.MapControllerRoute(null, "AddRecipe/AddRecipe", new { area = "AddRecipe", controller = "AddRecipe", action = "AddRecipe" });
                endpoints.MapControllerRoute(
                   name: "Logout",
                   pattern: "{controller=Account}/{action=Logout}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
