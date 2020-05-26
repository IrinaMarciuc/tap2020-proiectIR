using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using Microsoft.Data.SqlClient;
namespace IMRL.WhatsInMyFridge.Services
{
    public interface IPendingRecipeService
    {
        Task<List<Recipe>> ApproveRecipeAsync(Guid RecipeId);
        Task<List<Recipe>> RejectRecipeAsync(Guid RecipeId);
        Task<List<Recipe>> FindPendingRecipes();

    }
    public class PendingRecipeService : IPendingRecipeService {
        public Task<List<Recipe>> FindPendingRecipes()
        {
            throw new NotImplementedException();
        }


        Task<List<Recipe>> IPendingRecipeService.ApproveRecipeAsync(Guid RecipeId)
        {
            throw new NotImplementedException();
        }

        Task<List<Recipe>> IPendingRecipeService.RejectRecipeAsync(Guid RecipeId)
        {
            throw new NotImplementedException();
        }
    }


}
