using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.EF.Extensions;
using CaptainShop.Data.Entities;

namespace CaptainShop.Data.EF.Configurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>
    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired()
            .HasColumnType("varchar(128)")
            .HasMaxLength(128);
            // etc.
        }
    }
}
