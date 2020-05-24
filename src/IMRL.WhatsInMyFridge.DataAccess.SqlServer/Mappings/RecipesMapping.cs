using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.Recipes;

namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer.Mappings
{
    class RecipesMapping:IEntityTypeConfiguration<Recipe>
    {

        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");
            builder.Property(_ => _.Id).HasColumnName("RecipeId");
            builder.Property(_ => _.Name).HasColumnName("Name");
            builder.Property(_ => _.Link).HasColumnName("Link");
            builder.Property(_ => _.Status).HasColumnName("Status");
            builder.Property(_ => _.RecipeType).HasColumnName("RecipeType");

        }
    }
}
