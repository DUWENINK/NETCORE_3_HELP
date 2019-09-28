using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Configurations
{
   public class FileCollectionConfiguration : BaseConfiguration<FileCollectionEntity>
    {
        public override void Configure(EntityTypeBuilder<FileCollectionEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FileCollections");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.CpuId).IsRequired();
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FilePath).IsRequired();
            builder.Property(x => x.UserFilePath).IsRequired();
        }


    }
}
