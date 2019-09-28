using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
    public class DriverLicenseOfferConfiguration : BaseConfiguration<DriverLicenseOfferEntity>
    {
        public override void Configure(EntityTypeBuilder<DriverLicenseOfferEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("DriverLicenseOffers");
            builder.Property(x => x.AcquisitionTime);
            builder.Property(x => x.DriverLicenseType).HasMaxLength(2);
            builder.Property(x => x.SourceAreaId);
            builder.Property(x => x.GoalAreaId);
            builder.Property(x => x.GoalAddress);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.ScoreLeft);
            builder.Property(x => x.SourceTotalPrice);
            builder.Property(x => x.GoalTotalPrice);
            builder.Property(x => x.WeiXinId);
            builder.Property(x => x.Sex);
        }
    }
}
