﻿/*******************************************************************************
* Copyright (C) DUWENINK.Com
* 
* Author: DUWENINK
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@DUWENINK.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
    /// <summary>
    /// 部门表表配置
    /// </summary>
    public class DepartmentConfiguration : BaseConfiguration<DepartmentEntity>
    {
        public override void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.ParentId).HasMaxLength(36);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FullName).HasMaxLength(500);
        }
    }
}