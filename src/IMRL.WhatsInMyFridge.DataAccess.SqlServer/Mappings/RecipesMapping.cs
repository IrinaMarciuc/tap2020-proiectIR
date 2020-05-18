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
            builder.ToTable("Recipes")
                .HasKey(_ => _.Id);
            builder.Property(_ => _.name).HasColumnName("Name");
            builder.Property(_ => _.link).HasColumnName("Link");
            builder.Property(_ => _.status).HasColumnName("Status");


            builder.HasDiscriminator<int>("RecipeTypeId")
                .HasValue<Normal>(1)
                .HasValue<Vegan>(2)
                .HasValue<Vegetarian>(3);


        }
    }
}
