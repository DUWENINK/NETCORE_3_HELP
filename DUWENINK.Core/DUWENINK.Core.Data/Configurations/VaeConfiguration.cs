using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Configurations
{
   public class VaeConfiguration : BaseConfiguration<VaeEntity>
    {
        public override void Configure(EntityTypeBuilder<VaeEntity> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.ContentId).IsRequired();
            builder.Property(e => e.CreateDateTime).IsRequired();
            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.Title).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ContentId).HasMaxLength(300).IsRequired();
            builder.Property(e => e.CreateDateTime).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.ToTable("Vaes");
        }


    }
}
