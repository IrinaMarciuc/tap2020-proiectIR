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
using IMRL.WhatsInMyFridge.Services.Identity;

namespace IMRL.WhatsInMyFridge.Web.Areas.Login.Controllers
{
    public class SignupController : Controller
    {
        private readonly IUserPasswordStore<User> _userStore;
        private readonly SignInManager<User> _signInManager;
        private readonly CancellationToken cancellationToken = default;
        public SignupController(IUserPasswordStore<User> userStore, SignInManager<User> signInManager)
        {
           _userStore = userStore;
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

            if (ModelState.IsValid)
            {
                var user = new User(model.Email,model.Email,model.Password);
                var result = await _userStore.CreateAsync(user, cancellationToken);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}