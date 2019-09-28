/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemGroupConfiguration
// 文 件 名：    ItemGroupConfiguration
// 创建者：      DUWENINK
// 创建日期：	2019/9/26 11:06:45
// 版本	日期					修改人	
// v0.1	2019/9/26 11:06:45	DUWENINK
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
    /// 创建日期： 2019/9/26 11:06:45
    /// 类名：     ItemGroupConfiguration
    /// </summary>
    public class ItemGroupConfiguration : BaseConfiguration<ItemGroupEntity>
    {
        public override void Configure(EntityTypeBuilder<ItemGroupEntity> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.Property(e => e.ItemGroupDescription).HasMaxLength(500).IsRequired();
            builder.Property(e => e.MultipleSelect).HasDefaultValue(true);
            builder.Property(e => e.ItemGroupCode).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ItemGroupText).HasMaxLength(20).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.ToTable("ItemGroups");
        }
    }
}
