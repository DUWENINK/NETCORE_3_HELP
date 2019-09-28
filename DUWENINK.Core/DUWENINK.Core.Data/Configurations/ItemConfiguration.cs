/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemConfiguration
// 文 件 名：    ItemConfiguration
// 创建者：      DUWENINK
// 创建日期：	2019/9/26 11:06:03
// 版本	日期					修改人	
// v0.1	2019/9/26 11:06:03	DUWENINK
//----------------------------------------------------------------*/
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Configurations
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Data.Configurations
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/26 11:06:03
    /// 类名：     ItemConfiguration
    /// </summary>
    public class ItemConfiguration : BaseConfiguration<ItemEntity>
    {
        public override void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.Property(e => e.IsEnabled).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.ItemGroupId).HasMaxLength(36).IsRequired();
            builder.Property(e => e.CreateDateTime).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.ItemText).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ItemCode).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ItemDescription).HasMaxLength(500);
            builder.HasOne(e => e.ItemGroup).WithMany(e => e.Items).HasForeignKey(e => e.ItemGroupId);
            builder.HasOne(e => e.ParentItem)
                .WithMany(e => e.ChildItems)
                .HasForeignKey(e => e.ParentItemId);
            builder.ToTable("Items");
        }
    }
}
