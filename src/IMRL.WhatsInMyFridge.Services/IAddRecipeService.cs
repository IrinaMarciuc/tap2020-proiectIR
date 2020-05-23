using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;

namespace IMRL.WhatsInMyFridge.Services
{
    public interface IAddRecipeService
    {
      void AddRecipeAsync(Recipe recipe);
      void AddIngredientAsync(Ingredient ingredient);
      void AddRecipeIngridientAsync(RecipeIngredient recipeIngredient);

    }
    public class AddRecipeService : IAddRecipeService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddRecipeService(IDataRepository dataRepository,IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddIngredientAsync(Ingredient ingredient)
        {
            _dataRepository.Insert(ingredient);
            _unitOfWork.Commit();
        }

        public void AddRecipeAsync(Recipe recipe)
        {
            _dataRepository.Insert(recipe);
            _unitOfWork.Commit();
        }

        public void AddRecipeIngridientAsync(RecipeIngredient recipeIngredient)
        {
            _dataRepository.Insert(recipeIngredient);
            _unitOfWork.Commit();
        }
    }
}
