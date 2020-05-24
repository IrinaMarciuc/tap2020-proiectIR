using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.Core.Ingredients;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;
namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer
{
    public class WhatsInMyFridgeContext: DbContext
    {
       
        private string connectionString;
        public WhatsInMyFridgeContext()
        {
        }
        public WhatsInMyFridgeContext(DbContextOptions<WhatsInMyFridgeContext> options):base (options)
        {
        }


        public WhatsInMyFridgeContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "Data Source=DESKTOP-GAKRRLP;Initial Catalog=FridgeContents;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
