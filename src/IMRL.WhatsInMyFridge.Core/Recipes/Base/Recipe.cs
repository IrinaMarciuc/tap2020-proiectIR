using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Recipes.Base
{
    public abstract class Recipe : IRecipe
    {
        public Guid Id;
        public string name { get; protected set; }
        public string status { get; protected set; }
        public string link { get; protected set; }
    }
}