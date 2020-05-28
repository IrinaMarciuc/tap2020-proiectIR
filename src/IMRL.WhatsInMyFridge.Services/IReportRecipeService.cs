using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.Core.Reports;
using Microsoft.Data.SqlClient;

namespace IMRL.WhatsInMyFridge.Services
{
    public interface IReportRecipeService
    {
        void AddReport(Guid RecipeId, string ReportDescription);
        Task<List<Recipe>> FindReportedRecipesAsync();
        Task<List<Recipe>> ApproveRecipeAsync(Guid RecipeId);
        Task<List<Recipe>> DeleteRecipeAsync(Guid RecipeId);
        Task<List<Recipe>> ChangeTypeAsync(Guid RecipeId, string NewType);

    }
    public class ReportRecipeService : IReportRecipeService
    {
        public static string connectionString = "Data Source=DESKTOP-GAKRRLP;Initial Catalog=FridgeContents;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(connectionString);
        string q, IngredientQuery;
        public void AddReport(Guid RecipeId, string ReportDescription)
        {
            con.Open();
            q = "update Recipes  set Status='Reported' where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            q = "insert into Reports(RecipeId,Description)  values ('" + RecipeId + "','"+ReportDescription+"')";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Task<List<Recipe>> FindReportedRecipesAsync()
        {
            var RecipeList = new List<Recipe>();
            con.Open();

            q = "select * from Recipes r join Reports on Reports.RecipeId=r.RecipeId where r.Status='Reported' ";

            using (SqlCommand command = new SqlCommand(q, con))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Report report = new Report(Guid.Parse(reader[5].ToString()), reader[6].ToString());
                        Recipe recipe = new Recipe(Guid.Parse(reader[0].ToString()), reader[3].ToString(), reader[1].ToString(), reader[2].ToString(), reader[4].ToString(),report);
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
                else
                {
                    reader.Close();

                }
            }
            con.Close();
            return Task.FromResult(RecipeList);

        }
        Task<List<Recipe>> IReportRecipeService.ApproveRecipeAsync(Guid RecipeId)
        {
            DeleteReport(RecipeId);
            con.Open();
            q = "update Recipes  set Status='Approved' where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            var results = FindReportedRecipesAsync();
            return results;
        }
        Task<List<Recipe>> IReportRecipeService.DeleteRecipeAsync(Guid RecipeId)
        {
            DeleteReport(RecipeId);
            con.Open();
            q = "Delete from RecipeIngredients where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            q = "Delete from Recipes where RecipeId='" + RecipeId + "'";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            var results = FindReportedRecipesAsync();
            return results;
        }
        Task<List<Recipe>> IReportRecipeService.ChangeTypeAsync(Guid RecipeId, string NewType)
        {
            DeleteReport(RecipeId);
            con.Open();
            q =  "update Recipes  set Status='Approved',RecipeType='"+NewType+"' where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            var results = FindReportedRecipesAsync();
            return results;
        }
        void DeleteReport(Guid RecipeId)
        {
            con.Open();
            q = "Delete from Reports where RecipeId='" + RecipeId + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
