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
        public static string connectionString = "Data Source=DESKTOP-NK0HCAB;Initial Catalog=FridgeContents;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(connectionString);
        string q;
        string IngredientQuery;
        public Task<List<Recipe>> FindPendingRecipes()
        {
            var RecipeList = new List<Recipe>();
            con.Open();
             
            q = "select * from Recipes r where r.Status='Pending' ";
               
                using (SqlCommand command = new SqlCommand(q, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe(Guid.Parse(reader[0].ToString()), reader[3].ToString(), reader[1].ToString(), reader[2].ToString(), reader[4].ToString());
                        RecipeList.Add(recipe);
                    }
                    reader.Close();
                    foreach (var recipe in RecipeList)
                    {
                        IngredientQuery = "select * from RecipeIngredients ri join Ingredients i on i.IngredientId = ri.IngredientId where ri.RecipeId = '" + recipe.Id + "' ";
                        using (SqlCommand cmd = new SqlCommand(IngredientQuery, con))
                        {
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                RecipeIngredient recipeIngredient = new RecipeIngredient(reader[5].ToString(), Double.Parse(reader[2].ToString()), reader[3].ToString());
                                recipe.RecipeIngredients.Add(recipeIngredient);

                            }
                            reader.Close();
                        }
                    }
                }
                else {
                    reader.Close();

                }
            }    
                con.Close();
                return Task.FromResult(RecipeList);
            
        }


        Task<List<Recipe>> IPendingRecipeService.ApproveRecipeAsync(Guid RecipeId)
        {
            con.Open();
            q = "update Recipes  set Status='Approved' where RecipeId='"+RecipeId+"'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            var results = FindPendingRecipes();
            return results;
        }

        Task<List<Recipe>> IPendingRecipeService.RejectRecipeAsync(Guid RecipeId)
        {
            con.Open();
            q = "Delete from RecipeIngredients  where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            q = "Delete from Recipes where RecipeId='" + RecipeId + "'";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            var results = FindPendingRecipes();
            return results;
        }
    }


}
