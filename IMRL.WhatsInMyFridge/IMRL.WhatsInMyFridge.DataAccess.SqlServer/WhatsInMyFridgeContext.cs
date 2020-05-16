using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using IMRL.WhatsInMyFridge.Core.Recipes;
namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer
{
    class WhatsInMyFridgeContext: DbContext
    {
        private string connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=FridgeContents;Integrated Security=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
