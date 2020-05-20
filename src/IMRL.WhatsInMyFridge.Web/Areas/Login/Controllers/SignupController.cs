using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Web.Areas.Login.Models;
using IMRL.WhatsInMyFridge.Core.Identity;

namespace IMRL.WhatsInMyFridge.Web.Areas.Login.Controllers
{
    public class SignupController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public SignupController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
           _userManager = userManager;
           _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var user = new User { Username = model.Email, Email = model.Email };
            
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user, isPersistent: false);
                   return RedirectToAction("index", "home");
                }
            }
            return Redirect("/");
        }
    }
}