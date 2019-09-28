using AutoMapper;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Enum;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.System;

namespace DUWENINK.Core.Services
{
    /// <summary>
    /// 模块初始化
    /// </summary>
    public class DUWENINKModuleInitializer : ModuleInitializer
    {
        /// <summary>
        /// 加载AutoMapper配置(AutoMapper映射关系配置)
        /// </summary>
        /// <param name="config"></param>
        public override void LoadAutoMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<UserEntity, UserDto>().ReverseMap();
            config.CreateMap<VaeEntity, VaeNewsDto>().ReverseMap();
            config.CreateMap<UserEntity, UserAddDto>().ReverseMap();
            config.CreateMap<UserEntity, UserUpdateDto>().ForMember(u=>u.DepartmentName,d=>d.MapFrom(dv=>dv.Department.FullName)).ReverseMap();
            config.CreateMap<UserDto, UserUpdateDto>().ReverseMap();
            config.CreateMap<UserRoleEntity, UserRoleDto>().ReverseMap();
            config.CreateMap<RoleEntity, RoleDto>().ReverseMap();
            config.CreateMap<RoleMenuDto, RoleMenuEntity>().ReverseMap();
            config.CreateMap<PageViewEntity, VisitDto>()
                .ForMember(v => v.VisitDate, e => e.MapFrom(pv => pv.CreateDateTime))
                .ReverseMap();
            config.CreateMap<LoginLogEntity, LoginLogDto>().ReverseMap();
            config.CreateMap<MenuEntity, MenuDto>()
                .ForMember(m => m.Type, e => e.MapFrom(item => (MenuType) item.Type))
                .ReverseMap();
            config.CreateMap<MenuEntity, TreeDto>()
                .ForMember(m => m.id, e => e.MapFrom(item => item.Id))
                .ForMember(m => m.pId, e => e.MapFrom(item => item.ParentId))
                .ForMember(m => m.name, e => e.MapFrom(item => item.Name));
            config.CreateMap<RoleEntity, TreeDto>()
                .ForMember(m => m.id, e => e.MapFrom(item => item.Id))
                .ForMember(m => m.name, e => e.MapFrom(item => item.Name));

            config.CreateMap<DepartmentEntity, DepartmentDto>().ReverseMap();
            config.CreateMap<AreaEntity, AreaDto>().ReverseMap();
            config.CreateMap<MessageEntity, MessageDto>().ReverseMap();
            config.CreateMap<MessageEntity, MessageQueryDto>();
            config.CreateMap<SmtpEntity, SmtpDto>().ReverseMap();
            config.CreateMap<STSEntity, STSDto>().ReverseMap();
            config.CreateMap<AreaOfferEntity, AreaOfferDto>().ReverseMap();
            config.CreateMap<DriverLicenseOfferEntity, DriverLicenseOfferDto>().ReverseMap();
            config.CreateMap<ProjectEntity, ProjectAddDto>().ReverseMap();
            config.CreateMap<ProjectEntity, ServiceEditDto>().ForMember(p => p.ChargePersonName, pu => pu.MapFrom(pui => pui.ChargePerson.RealName)).ReverseMap();
            config.CreateMap<ProjectEntity, ProjectUpdateDto>().ForMember(p=>p.ChargePersonName,pu=>pu.MapFrom(pui=>pui.ChargePerson.RealName)).ReverseMap();
            config.CreateMap<FileCollectionEntity, FileCollectionDto>().ReverseMap();
            #region ItemGroups
            config.CreateMap<ItemGroupEntity, ItemGroupDto>().ReverseMap();
            #endregion



        }
    }

    /// <summary>
    /// 依赖注入模块初始化
    /// </summary>
    public static class DUWENINKServiceModuleInitialize
    {
        /// <summary>
        /// 添加需要依赖注入的服务
        /// </summary>
        /// <param name="services"></param>
        public static void UseDUWENINKService(this IServiceCollection services)
        {
            //AutoMapper配置
            services.AddScoped<IConfigurationProvider>(_ => AutoMapperConfig.GetMapperConfiguration());
            services.AddScoped(_ => AutoMapperConfig.GetMapperConfiguration().CreateMapper());

            //通过反射，批量取出需要注入的接口和实现类
            var registrations =
                from type in typeof(DUWENINKModuleInitializer).Assembly.GetTypes()
                where type.Namespace != null && (type.Namespace.IsNotBlank() &&
                                               type.Namespace.StartsWith("DUWENINK.Core.Services") &&
                                               type.GetInterfaces().Any(x => x.Name.EndsWith("Service")) &&
                                               type.GetInterfaces().Any())
                select new { Service = type.GetInterfaces().First(), Implementation = type };

            foreach (var t in registrations)
            {
                services.AddScoped(t.Service, t.Implementation);
            }
        }
    }
}
