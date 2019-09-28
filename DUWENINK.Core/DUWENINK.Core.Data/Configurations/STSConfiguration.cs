using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
    public class STSConfiguration : IEntityTypeConfiguration<STSEntity>
    {
        public void Configure(EntityTypeBuilder<STSEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.Property(e => e.FromGroup).IsRequired();
            builder.Property(e => e.FromQQ).IsRequired();
            builder.Property(e => e.Message).IsRequired();
            builder.Property(e => e.CreateDateTime).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.ToTable("STS");
        }
    }
}
