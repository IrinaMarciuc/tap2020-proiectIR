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
            var results = await _searchRecipeService.SearchRecipeAsync(viewModel.SearchTerm,viewModel.RecipeType);

            return View(new SearchRecipeViewModel
            {
                SearchTerm = viewModel.SearchTerm,
                Results = results
            });
        }

        [ActionName("SearchRecipe")]
        [HttpPost]
        public async Task<ActionResult> IndexPost(string button, Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            string buttonClicked = Request.Form["SubmitButton"];
            string Description = Request.Form["ReportDescription"];
            if (buttonClicked == "Send")
            {
                _reportRecipeService.AddReport(id, Description);

            }
            return RedirectToAction("Message");
        }
        public IActionResult Message() {
            return View();
        }
    }
}