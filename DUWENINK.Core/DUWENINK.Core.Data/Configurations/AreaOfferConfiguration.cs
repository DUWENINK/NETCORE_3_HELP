using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
    public class AreaOfferConfiguration: BaseConfiguration<AreaOfferEntity>
    {
        public override void Configure(EntityTypeBuilder<AreaOfferEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("AreaOffers");
            builder.Property(x => x.AreaId).HasMaxLength(36);
            builder.Property(x => x.A1OfferPrice).HasMaxLength(36);
            builder.Property(x => x.A2OfferPrice).HasMaxLength(36);
            builder.Property(x => x.A3OfferPrice).HasMaxLength(36);
            builder.Property(x => x.B1OfferPrice).HasMaxLength(36);
            builder.Property(x => x.B2OfferPrice).HasMaxLength(36);
            builder.Property(x => x.C1OfferPrice).HasMaxLength(36);
            builder.Property(x => x.C2OfferPrice).HasMaxLength(36);
            builder.Property(x => x.C3OfferPrice).HasMaxLength(36);
            builder.Property(x => x.C4OfferPrice).HasMaxLength(36);
            builder.Property(x => x.DOfferPrice).HasMaxLength(36);
            builder.Property(x => x.EOfferPrice).HasMaxLength(36);
            builder.Property(x => x.FOfferPrice).HasMaxLength(36);
            builder.Property(x => x.MOfferPrice).HasMaxLength(36);
            builder.Property(x => x.NOfferPrice).HasMaxLength(36);
            builder.Property(x => x.POfferPrice).HasMaxLength(36);
        }
    }



}
