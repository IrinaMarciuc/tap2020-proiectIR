using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using Microsoft.Data.SqlClient;

namespace IMRL.WhatsInMyFridge.Services
{
    public interface ISearchRecipeService
    {
        Task<List<Recipe>> SearchRecipeAsync(string IngredientName,string RecipeType);
    }

    public class SearchRecipeService : ISearchRecipeService
    {
        public static string connectionString = "Data Source=DESKTOP-GAKRRLP;Initial Catalog=FridgeContents;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(connectionString);
        string q;
        string IngredientQuery;
        public Task<List<Recipe>> SearchRecipeAsync(string IngredientName,string RecipeType)
        {
            
            var RecipeList = new List<Recipe>();
            if (String.IsNullOrEmpty(IngredientName))
            {
                return Task.FromResult(RecipeList);
            }
            else
            {
                con.Open();
                Guid IngredientId = getId(IngredientName);

                if (RecipeType == "normal")
                {
                    q = "select * from RecipeIngredients ri join Recipes r on r.RecipeId = ri.RecipeId where ri.IngredientId = '" + IngredientId + "'and r.Status='Approved' ";
                }
                else if (RecipeType == "vegetarian")
                {
                    q = "select * from RecipeIngredients ri join Recipes r on r.RecipeId = ri.RecipeId where (ri.IngredientId = '" + IngredientId + "' and (r.RecipeType='Vegan' or r.RecipeType='Vegetarian')and r.Status='Approved') ";
                }
                else
                {
                    q = "select * from RecipeIngredients ri join Recipes r on r.RecipeId = ri.RecipeId where (ri.IngredientId = '" + IngredientId + "' and r.RecipeType='Vegan' and r.Status='Approved') ";
                }
                using (SqlCommand command = new SqlCommand(q, con))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe(Guid.Parse(reader[0].ToString()), reader[5].ToString(), reader[8].ToString(),reader["RecipeType"].ToString());
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
                                RecipeIngredient recipeIngredient = new RecipeIngredient(reader[5].ToString(), reader[2].ToString(), reader[3].ToString());
                                recipe.RecipeIngredients.Add(recipeIngredient);

                            }
                            reader.Close();
                        }
                    }
                }
                con.Close();
                return Task.FromResult(RecipeList);
            }
        }

        public Guid getId(string name)
        {
            Guid id;
            q = "select * from Ingredients where IngredientName='" + name + "'";
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

                }
            }
            return id;

        }
    }
}
