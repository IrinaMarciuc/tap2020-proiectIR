using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.RecipeIngredients;

namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer.Mappings
{
    class RecipeIngredientMapping : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.ToTable("RecipeIngredients");
            builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            //builder.HasOne(ri => ri.Ingredient).WithMany(ri => ri.RecipeIngredients).HasForeignKey(i => i.IngredientId);
           // builder.HasOne(ri => ri.Recipe).WithMany(ri => ri.RecipeIngredients).HasForeignKey(i => i.RecipeId);
            builder.Property(_ => _.Quantity).HasColumnName("Quantity");
            builder.Property(_ => _.RecipeId).HasColumnName("RecipeId");
            builder.Property(_ => _.IngredientId).HasColumnName("IngredientId");
            builder.Property(_ => _.UnitOfMeasurement).HasColumnName("MeasurementUnit");
        }
    }
}
