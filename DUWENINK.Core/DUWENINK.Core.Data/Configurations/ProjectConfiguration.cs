using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
   public class ProjectConfiguration : BaseConfiguration<ProjectEntity>
    {
        public override void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Projects");
            builder.Property(x => x.ChargePersonId).HasMaxLength(36).IsRequired();
            builder.Property(x => x.FromCustomQQ).HasMaxLength(11);
            builder.Property(x => x.FromCustomServiceQQ).HasMaxLength(11);
            builder.Property(x => x.FromQQGroup).HasMaxLength(11);
            builder.Property(x => x.ProjectQQGroup).HasMaxLength(11);
            builder.Property(x => x.ProjectType).HasMaxLength(2);
            builder.Property(x => x.ProjectTitle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProjectAgreementWorth).IsRequired();
            builder.Property(x => x.ProjectWorth).IsRequired();
            builder.Property(x => x.SettleTime).IsRequired(false);
            builder.Property(x => x.ProjectStartTime).IsRequired(false);
            builder.Property(x => x.ProjectServiceEndTime).IsRequired(false);
            builder.Property(x => x.ProjectStatus).HasMaxLength(2);
            builder.Property(x => x.ProjectEndTime).IsRequired(false);
            builder.Property(x => x.ProjectPath).IsRequired(false);
            builder.Property(x => x.Remarks);
            builder.Property(x => x.SettleInterval);
        }
    }
}
