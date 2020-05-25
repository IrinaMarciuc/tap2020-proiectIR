using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Web.Models;
using IMRL.WhatsInMyFridge.Web.Models.Account;
using IMRL.WhatsInMyFridge.Services.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace IMRL.WhatsInMyFridge.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserService _UserService;
        public AccountController(IUserService UserService) {
            _UserService = UserService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Check the user name and password  
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            var result = await _UserService.SignInService(model.Username, model.Password);

            if (result== null)
            {
                ModelState.AddModelError(String.Empty, "Invalid login attempt");
                return View(model);  
            }

            else
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.Role, result.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }
            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Check the user name and password  
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            var result = await _UserService.RegisterUserService(model.Username, model.Password);

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.Role, result.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //return RedirectToAction("Login");
            return RedirectToAction("Index", "Home");
        }
    }

    
}
