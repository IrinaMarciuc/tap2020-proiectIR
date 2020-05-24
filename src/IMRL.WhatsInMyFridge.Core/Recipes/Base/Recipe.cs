using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Recipes.Base
{
    public class Recipe : IRecipe, IEntityBase
    {
        public Guid Id { get; set; }
        public string RecipeType { get; set; }
        public string Name { get; protected set; }
        public string Status { get; protected set; }
        public string Link { get; protected set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }


        public Recipe(Guid Id,string RecipeType,string Name,string Status,string Link)
        {
            this.Id = Id;
            this.RecipeType = RecipeType;
            this.Name = Name;
            this.Status = Status;
            this.Link = Link;
        }
    }
}