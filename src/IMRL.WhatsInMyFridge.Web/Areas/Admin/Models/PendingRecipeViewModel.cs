using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;

namespace IMRL.WhatsInMyFridge.Web.Areas.Admin.Models
{
    public class PendingRecipeViewModel
    {
        public PendingRecipeViewModel()
        {
            Results = new List<Recipe>();
        }

        public List<Recipe> Results { get; internal set; }
    }
}
