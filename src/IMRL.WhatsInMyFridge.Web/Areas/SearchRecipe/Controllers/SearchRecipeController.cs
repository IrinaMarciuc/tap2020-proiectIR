using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Services;
using IMRL.WhatsInMyFridge.Web.Areas.SearchRecipe.Models;

namespace IMRL.WhatsInMyFridge.Web.Areas.SearchRecipe.Controllers
{
    public class SearchRecipeController : Controller
    {
        private readonly ISearchRecipeService _searchRecipeService;
        private readonly IReportRecipeService _reportRecipeService;

        public SearchRecipeController(ISearchRecipeService searchRecipeService, IReportRecipeService reportRecipeService)
        {
            _searchRecipeService = searchRecipeService;
            _reportRecipeService = reportRecipeService;
        }

        public async Task<IActionResult> SearchRecipe(SearchRecipeViewModel viewModel)
        {
            if (viewModel.RecipeType == "Fara restrictii")
            {
                viewModel.RecipeType = "Normal";
            }
            var results = await _searchRecipeService.SearchRecipeAsync(viewModel.SearchTerm,viewModel.RecipeType);
            return View(new SearchRecipeViewModel
            {
                SearchTerm = viewModel.SearchTerm,
                Results = results,
            });
        }

        [ActionName("SearchRecipe")]
        [HttpPost]
        public async Task<ActionResult> IndexPost(Guid id)
        {
            string buttonClicked = Request.Form["SubmitButton"];
            if (buttonClicked == "Send")
            {
                string Description = Request.Form["ReportDescription"];
                _reportRecipeService.AddReport(id, Description);

            }
            else if (buttonClicked == "Change")
            {
                var result = await _reportRecipeService.ApproveRecipeAsync(id);

            }
            else if (buttonClicked == "Delete")
            {
                var result = await _reportRecipeService.DeleteRecipeAsync(id);
            }
            else if (buttonClicked == "ChangeType")
            {
                string NewType = Request.Form["RecipeType"];
                if (NewType == "Fara restrictii")
                {
                    NewType = "Normal";
                }
                var result = await _reportRecipeService.ChangeTypeAsync(id, NewType);
            }
            return RedirectToAction("Message");
        }
        public IActionResult Message() {
            return View();
        }
    }
}