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

        public SearchRecipeController(ISearchRecipeService searchRecipeService)
        {
            _searchRecipeService = searchRecipeService;
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

    }
}