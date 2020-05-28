using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMRL.WhatsInMyFridge.Services;
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
            if (model.RecipeType == "Fara restrictii") {
                model.RecipeType = "Normal";
            }
            _addRecipeService.AddRecipeAsync(model.RecipeName,status,model.RecipeType,model.Link,model.Ingredients,model.Quantities,model.UnitsOfMeasurement);
            return RedirectToAction("AddMessage");
        }
        public IActionResult AddMessage()
        {
            return View();
        }

    }
}