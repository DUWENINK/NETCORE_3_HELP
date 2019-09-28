using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Configurations
{
    public class JobConfiguration : BaseConfiguration<JobEntity>
    {
        public override void Configure(EntityTypeBuilder<JobEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Jobs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.JobReciveType).IsRequired();
            builder.Property(x => x.ReviceAccount).HasMaxLength(36).IsRequired();
            builder.Property(x => x.MessageContext).IsRequired();
            builder.Property(x => x.IsSend).HasMaxLength(20);
            builder.Property(x => x.DeliverTime).IsRequired(false);
        }

    }
}
