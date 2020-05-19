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
            builder.ToTable("RecipeIngredients")
                .HasKey(_ => _.RecipeId);
            builder.HasKey(_ => _.IngredientId);
            builder.Property(_ => _.Quantity).HasColumnName("Quantity");
            builder.Property(_ => _.UnitOfMeasurement).HasColumnName("MeasurementUnit");
        }
    }
}
