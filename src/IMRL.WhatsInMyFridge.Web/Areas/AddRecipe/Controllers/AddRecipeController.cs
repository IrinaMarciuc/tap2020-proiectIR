using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Services;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using IMRL.WhatsInMyFridge.DataAccess.SqlServer.Mappings;
using IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Models;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Controllers
{
    public class AddRecipeController : Controller
    {
        private readonly IAddRecipeService _addRecipeService;

        public AddRecipeController(IAddRecipeService addRecipeService)
        {
            _addRecipeService = addRecipeService;
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRecipe(AddRecipeViewModel model)
        {
            return View();
        }

    }
}