using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Reports;
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
        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }
        public Report Report;
       

        public Recipe(Guid Id,string RecipeType,string Name,string Status,string Link)
        {
            this.Id = Id;
            this.RecipeType = RecipeType;
            this.Name = Name;
            this.Status = Status;
            this.Link = Link;
            RecipeIngredients = new List<RecipeIngredient>();
        }
        public Recipe(Guid Id, string RecipeType, string Name, string Status, string Link, Report Report)
        {
            this.Id = Id;
            this.RecipeType = RecipeType;
            this.Name = Name;
            this.Status = Status;
            this.Link = Link;
            this.Report = Report;
            RecipeIngredients = new List<RecipeIngredient>();
        }
        public Recipe(Guid Id, string Name, string Link, string RecipeType)
        {
            this.Id = Id;
            this.Name = Name;
            this.Link = Link;
            this.RecipeType = RecipeType;
            RecipeIngredients = new List<RecipeIngredient>();
        }
    }
}