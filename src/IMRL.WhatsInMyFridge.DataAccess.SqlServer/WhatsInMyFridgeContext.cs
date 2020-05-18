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
    public class WhatsInMyFridgeContext: DbContext
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WhatsInMyFridge"].ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
