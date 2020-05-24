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
        public async Task<IActionResult> AddRecipe(AddRecipeViewModel model)
        {
            var status = "Pending";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (User.IsInRole("Admin")) {
                status = "Approved";
            }
            _addRecipeService.AddRecipeAsync(model.RecipeName,status,model.RecipeType,model.Link,model.Ingredients,model.Quantities,model.UnitsOfMeasurement);
            return RedirectToAction("Index", "Home");
        }

    }
}