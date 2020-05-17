using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.Recipes;
using IMRL.WhatsInMyFridge.Core.Ingredients;

namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer.Mappings
{
    class IngredientsMapping : IEntityTypeConfiguration<Ingredient>
    {

        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients")
                .HasKey(_ => _.Id);
            builder.Property(_ => _.name).HasColumnName("Name");


        }
    }
}
