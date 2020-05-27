using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Services;
using IMRL.WhatsInMyFridge.Web.Areas.Admin.Models;
using System.Net;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Controllers
{
    public class PendingRecipeController : Controller
    {
        private readonly IPendingRecipeService _pendingRecipeService;

        public PendingRecipeController(IPendingRecipeService pendingRecipeService)
        {
            _pendingRecipeService = pendingRecipeService;
        }
        public async Task<IActionResult> Index(PendingRecipeViewModel viewModel)
        {
            var results = await _pendingRecipeService.FindPendingRecipes();
            var i = 0;

            return View(new PendingRecipeViewModel
            {
                Results = results
            });
        }
        [ActionName("Index")]
        [HttpPost]
        public async Task<ActionResult> IndexPost(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            string buttonClicked = Request.Form["SubmitButton"];
            if (buttonClicked == "Accept")
            {
                var result = await _pendingRecipeService.ApproveRecipeAsync(id);

            }
            else if (buttonClicked == "Decline")
            {
                var result = await _pendingRecipeService.RejectRecipeAsync(id);
            }
            //Save Record and Redirect
            return RedirectToAction("Index");
        }
    }
}