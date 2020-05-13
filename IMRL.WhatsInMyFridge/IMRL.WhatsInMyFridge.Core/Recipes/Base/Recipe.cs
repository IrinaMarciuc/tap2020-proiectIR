using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Recipes.Base
{
    public abstract class Recipe : IRecipe
    {
        public string name { get; protected set; }
        public string link { get; protected set; }
    }
}