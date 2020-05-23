using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Recipes.Base
{
    public abstract class Recipe : IRecipe, IEntityBase
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string name { get; protected set; }
        public string status { get; protected set; }
        public string link { get; protected set; }

        public virtual IList<RecipeIngredient> RecipeIngredient{ get; set; }

        public Recipe(Guid _Id,int _TypeId,string _name,string _status,string _link)
        {
            this.Id = _Id;
            this.TypeId = _TypeId;
            this.name = _name;
            this.status = _status;
            this.link = _link;
        }
    }
}