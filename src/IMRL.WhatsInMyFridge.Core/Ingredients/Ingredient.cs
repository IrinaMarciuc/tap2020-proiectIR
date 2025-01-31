﻿using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Ingredients
{
    public class Ingredient : IEntityBase, IIngredient
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public Ingredient(Guid Id, string name) {
            this.name = name;
            this.Id = Id;
        }
    }
}
