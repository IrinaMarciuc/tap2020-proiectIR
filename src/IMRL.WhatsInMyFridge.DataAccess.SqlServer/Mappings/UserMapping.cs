using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.Identity;
namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer.Mappings
{
    class UserMapping
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasKey(u => u.Id);
        }
    }
}
