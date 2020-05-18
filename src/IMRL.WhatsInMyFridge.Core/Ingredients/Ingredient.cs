using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Ingredients
{
    public class Ingredient : IIngredient
    {
        public Guid Id;
        public string name { get; set; }
    }
}
