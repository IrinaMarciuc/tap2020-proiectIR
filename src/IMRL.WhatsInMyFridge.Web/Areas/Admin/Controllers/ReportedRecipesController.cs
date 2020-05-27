using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Services;
using IMRL.WhatsInMyFridge.Web.Areas.Admin.Models;
using System.Net;

namespace IMRL.WhatsInMyFridge.Web.Areas.Admin.Controllers
{
    public class ReportedRecipesController : Controller
    {
        private readonly IReportRecipeService _reportRecipeService;

        public ReportedRecipesController(IReportRecipeService reportRecipeService)
        {
            _reportRecipeService = reportRecipeService;
        }
        public async Task<IActionResult> FindReportedRecipes(PendingRecipeViewModel viewModel)
        {
            var results = await _reportRecipeService.FindReportedRecipesAsync();

            return View(new PendingRecipeViewModel
            {
                Results = results
            });
        }
        [ActionName("FindReportedRecipes")]
        [HttpPost]
        public async Task<ActionResult> FindReportedRecipesPost(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("FindReportedRecipes");
            }

            string buttonClicked = Request.Form["SubmitButton"];
            if (buttonClicked == "Change")
            {
                var result = await _reportRecipeService.ApproveRecipeAsync(id);

            }
            else if (buttonClicked == "Delete")
            {
                var result = await _reportRecipeService.DeleteRecipeAsync(id);
            }
            else if (buttonClicked == "ChangeType")
            {
                string NewType= Request.Form["RecipeType"];
                var result = await _reportRecipeService.ChangeTypeAsync(id,NewType);
            }
            //Save Record and Redirect
            return RedirectToAction("FindReportedRecipes");
        }
    }
}