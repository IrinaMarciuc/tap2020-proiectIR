using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Models
{
    public class AddRecipeViewModel
    {
        string RecipeName { get; set; }
        string Link { get; set; }
        string RecipeType { get; set; }
        public List<FormIngredient> Ingredients { get; set; } 
    }
}
