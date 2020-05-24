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
        public Guid IngredientId { get; set; }

        public string UnitOfMeasurement { get; set; }
        public Double Quantity { get; set; }
        public Guid Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeIngredient(Guid RecipeId, Guid IngredientId, Double Quantity, string UnitOfMeasurement) {
            this.RecipeId = RecipeId;
            this.IngredientId = IngredientId;
            this.Quantity = Quantity;
            this.UnitOfMeasurement = UnitOfMeasurement;
        }
          
    }
}
