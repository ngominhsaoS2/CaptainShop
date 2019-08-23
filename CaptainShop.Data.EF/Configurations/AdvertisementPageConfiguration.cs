using CaptainShop.Data.EF.Extensions;
using CaptainShop.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Configurations
{
    public class AdvertisementPageConfiguration : DbEntityConfiguration<AdvertisementPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}
