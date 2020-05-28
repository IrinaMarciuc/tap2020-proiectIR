using System.Collections.Generic;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Models
{
    public class AddRecipeViewModel
    {
        public string RecipeName { get; set; }
        public string Link { get; set; }
        public string RecipeType { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Quantities { get; set; }
        public List<string> UnitsOfMeasurement { get; set; }
    }
}
