using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;

namespace IMRL.WhatsInMyFridge.Web.Areas.SearchRecipe.Models
{
    public class SearchRecipeViewModel
    {
            public SearchRecipeViewModel()
            {
                Results = new List<Recipe>();
            }

            public string SearchTerm { get; set; }
            public string RecipeType { get; set; }

            public List<Recipe> Results { get; internal set; }
        }
    }
