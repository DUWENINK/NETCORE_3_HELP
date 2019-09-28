/*******************************************************************************
* Copyright (C) DUWENINK.Com
* 
* Author: DUWENINK
* Create Date: 2015/8/21
* Description: Automated building by service@DUWENINK.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using DUWENINK.Core.Data.Configurations;
using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace DUWENINK.Core.Data
{
    /// <summary>
    /// DUWENINKContext
    /// </summary>
    public class DUWENINKContext : DbContext
    {

        /// <summary>
        /// DUWENINKContext
        /// </summary>
        public DUWENINKContext(DbContextOptions<DUWENINKContext> options) :
            base(options)
        {

        }


        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //添加FluentAPI配置
            var typesToRegister = typeof(SystemConfigConfiguration).Assembly.GetTypes()
                .Where(q => q.GetInterface(typeof(SystemConfigConfiguration).FullName) != null && !q.FullName.StartsWith("DUWENINK.Core.Data.Configurations.BaseConfiguration"));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSets

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<RoleEntity> Roles { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<MenuEntity> Menus { get; set; }

        /// <summary>
        /// 用户角色关系
        /// </summary>
        public DbSet<UserRoleEntity> UserRoles { get; set; }

        /// <summary>
        /// 角色菜单关系
        /// </summary>
        public DbSet<RoleMenuEntity> RoleMenus { get; set; }

        /// <summary>
        /// 路径码
        /// </summary>
        public DbSet<PathCodeEntity> PathCodes { get; set; }

        /// <summary>
        /// 页面访问记录
        /// </summary>
        public DbSet<PageViewEntity> PageViews { get; set; }

        /// <summary>
        /// 登录日志
        /// </summary>
        public DbSet<LoginLogEntity> LoginLogs { get; set; }

        /// <summary>
        /// 系统配置
        /// </summary>
        public DbSet<SystemConfigEntity> SystemConfigs { get; set; } 

        /// <summary>
        /// 区域
        /// </summary>
        public DbSet<AreaEntity> Areas { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<DepartmentEntity> Departments { get; set; }

        /// <summary>
        /// 访问数据统计
        /// </summary>
        public DbSet<SiteViewEntity> SiteViews { get; set; }

        /// <summary>
        /// 站内信
        /// </summary>
        public DbSet<MessageEntity> Messages { get; set; }

        /// <summary>
        /// 站内信接收人
        /// </summary>
        public DbSet<MessageReceiverEntity> MessageReceivers { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<STSEntity> STSs { get; set; }
        /// <summary>
        /// 邮件客户端
        /// </summary>
        public DbSet<SmtpEntity> Smtps { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public DbSet<ProjectEntity> Projects { get; set; }
        /// <summary>
        /// 定时任务
        /// </summary>

        public DbSet<JobEntity> Jobs { get; set; }

        /// <summary>
        /// 地区对应的票价(单价)
        /// </summary>
        public DbSet<AreaOfferEntity> AreaOffers { get; set; }
        /// <summary>
        /// 主要数据
        /// </summary>
        public DbSet<DriverLicenseOfferEntity> DriverLicenseOffers { get; set; }

        /// <summary>
        /// 用户的文件列表
        /// </summary>
        public DbSet<FileCollectionEntity> FileCollections { get; set; }

        /// <summary>
        /// 用户的文件列表
        /// </summary>
        public DbSet<VaeEntity> Vaes { get; set; }

        /// <summary>
        /// 字典组列表
        /// </summary>
        public DbSet<ItemGroupEntity> ItemGroups { get; set; }


        /// <summary>
        /// 字典项列表
        /// </summary>
        public DbSet<ItemEntity> Items { get; set; }


        #endregion
    }
}
