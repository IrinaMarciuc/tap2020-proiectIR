using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Models
{
    public class AddRecipeViewModel
    {
        public string RecipeName { get; set; }
        public string Link { get; set; }
        public string RecipeType { get; set; }
        public List<string> Ingredients { get; set; }
        public List<Double> Quantities { get; set; }
        public List<string> UnitsOfMeasurement { get; set; }
    }
}
