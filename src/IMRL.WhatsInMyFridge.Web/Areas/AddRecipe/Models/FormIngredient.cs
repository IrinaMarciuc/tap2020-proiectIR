using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMRL.WhatsInMyFridge.Web.Areas.AddRecipe.Models
{
    public class FormIngredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }

    }
}
