using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.RecipeIngredients
{
    public class RecipeIngredient :IEntityBase
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Category { get; set; }

        public string UnitOfMeasurement { get; set; }
        public double Quantity { get; set; }
        public Guid Id { get; set; }
    }
}
