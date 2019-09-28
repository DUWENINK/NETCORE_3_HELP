using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
   public class SmtpConfiguration : IEntityTypeConfiguration<SmtpEntity>
    {
        public void Configure(EntityTypeBuilder<SmtpEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.Property(e => e.CreateDateTime).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.FromUserMail).IsRequired();
            builder.Property(e => e.FromUserName).IsRequired();
            builder.Property(e => e.Host).IsRequired();
            builder.Property(e => e.PassWord).IsRequired();
            builder.Property(e => e.Port).IsRequired();
            builder.Property(e => e.UseDefaultCredentials).IsRequired();
            builder.Property(e => e.Remark);
            builder.ToTable("Smtp");
        }
    }
}
