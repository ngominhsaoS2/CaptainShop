﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.EF.Extensions;
using CaptainShop.Data.Entities;

namespace CaptainShop.Data.EF.Configurations
{
    class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
