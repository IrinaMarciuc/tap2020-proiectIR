using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace IMRL.WhatsInMyFridge.Services
{
    public interface IAddRecipeService
    {
      void AddRecipeAsync(string RecipeName, string RecipeStatus, string RecipeType, string Link, List<string> Ingredients,
          List<Double> Quantities, List<string> UnitsOfMeasurement);

    }
    public class AddRecipeService : IAddRecipeService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;
        public static string connectionString = "Data Source=DESKTOP-NK0HCAB;Initial Catalog=FridgeContents;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);
        string q;

        public AddRecipeService(IDataRepository dataRepository,IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddIngredient(Guid Id, string Name )
        {
            var ingredient = new Ingredient(Id, Name);
            q = "insert into Ingredients(IngredientId,IngredientName)values('" + ingredient.Id+ "','" + ingredient.name + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
           // _dataRepository.Insert(ingredient);
            //_unitOfWork.Commit();
        }

        public void AddRecipe(Recipe recipe)
        {
            q = "insert into Recipes(RecipeId,Name,Status,RecipeType,Link)values('" + recipe.Id + "','" + recipe.Name + "','"+recipe.Status+ "','" + recipe.RecipeType + "','" + recipe.Link + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            //_dataRepository.Insert(recipe);
           // _unitOfWork.Commit();
        }

        public void AddRecipeAsync(string RecipeName, string RecipeStatus, string RecipeType, string Link, List<string> Ingredients, List<double> Quantities, List<string> UnitsOfMeasurement)
        {
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) {
                var recipe = new Recipe(Guid.NewGuid(), RecipeType, RecipeName, RecipeStatus, Link);
                AddRecipe(recipe);
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Guid IngredientId = getId(Ingredients[i]);
                    AddRecipeIngredient(recipe.Id, IngredientId, Quantities[i], UnitsOfMeasurement[i]);
                }


            }
            con.Close();

        }

        public void AddRecipeIngredient(Guid RecipeId, Guid IngredientId, Double Quantity, string UnitOfMeasurement)
        {
            var recipeIngredient = new RecipeIngredient(RecipeId, IngredientId, Quantity, UnitOfMeasurement);
            q = "insert into RecipeIngredients(RecipeId,IngredientId,Quantity,MeasurementUnit)values('" + recipeIngredient.RecipeId + "','" + recipeIngredient.IngredientId + "','" + recipeIngredient.Quantity + "','" + recipeIngredient.UnitOfMeasurement + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();

            //_dataRepository.Insert(recipeIngredient);
            //_unitOfWork.Commit();
        }
        public Guid getId(string name) {
            Guid id;
        q="select * from Ingredients where IngredientName='"+name+"'";
            using (SqlCommand command = new SqlCommand(q, con))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    String IdString = reader[0].ToString();

                    id = Guid.Parse(IdString);
                    
                    reader.Close();
                }
                else
                {
                    id = Guid.NewGuid();
                    reader.Close();
                    AddIngredient(id, name);
                }    
            }
            return id;

        }
    }
}
