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
       
        private string connectionString;

        public WhatsInMyFridgeContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString=this.connectionString ?? System.Configuration.ConfigurationManager.ConnectionStrings["WhatsInMyFridge"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
