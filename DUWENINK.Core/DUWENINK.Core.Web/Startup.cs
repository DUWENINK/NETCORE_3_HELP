using DUWENINK.Core.Data;
using DUWENINK.Core.Infrastructure.Utilities;
using DUWENINK.Core.Services;
using DUWENINK.Core.Web.Filters;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using DUWENINK.Core.Models;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using AspNetCoreRateLimit;
using Hangfire;

namespace DUWENINK.Core.Web
{

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var repository = LogManager.CreateRepository(Constants.Log4net.RepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }


        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages();
            #region Swagger支持
            //添加Swagger. 3.0目前还不支持 20190926
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DUWENINKCoreWeb", new OpenApiInfo { Title = "DUWENINK_API", Version = "v1" });
                //Determine base path for the application.  
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(basePath, "DUWENINK.Core.Web.xml");
                c.IncludeXmlComments(xmlPath);
            });
            #endregion
            //services.AddCors(options =>
            //{

            //    //options.AddPolicy("AllowSpecificOrigin",
            //    //    builder => builder.WithOrigins("http://car.shuyangtao.com").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials());
            //    options.AddPolicy("AllowAllOrigin",
            //        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials());
            //});
            #region 速率限制所需 限流中间件 NetCore3暂时还不知道支持情况,所以不添加
            //// needed to load configuration from appsettings.json
            //services.AddOptions();
            //// needed to store rate limit counters and ip rules
            //services.AddMemoryCache();
            ////api速率限制
            //services.Configure<IpRateLimitOptions>(options =>
            //{
            //    options.GeneralRules = new List<RateLimitRule>
            //    {
            //         new RateLimitRule
            //    {
            //         Endpoint="*",
            //          Limit=3,
            //          Period="5m"
            //    }
            //    };
            //}); 
            //添加单例模式的依赖注入
            // services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            // services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            #endregion
            //identity server 4服务配置
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(Client.GetApiResources())
            //    .AddInMemoryClients(Clients.GetClients())
            //    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            //    .AddProfileService<JuCheapUserProfileService>();

            #region Cookie配置
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(o =>
                   {
                       o.ExpireTimeSpan = TimeSpan.FromMinutes(480);//cookie默认有效时间为8个小时
                       o.LoginPath = new PathString("/Home/Login");
                       o.LogoutPath = new PathString("/Home/Logout");
                       o.Cookie = new CookieBuilder
                       {
                           HttpOnly = true,
                           Name = ".DUWENINK.Core.Identity",
                           Path = "/"
                       };
                       //o.DataProtectionProvider = null;//如果需要做负载均衡，就需要提供一个Key
                   });
            #endregion



            #region 选择一种数据库
            //使用Sql Server数据库
            services.AddDbContext<DUWENINKContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection_SqlServer")));

            ////使用Sqlite数据库
            //services.AddDbContext<DUWENINKContext>(options => options.UseSqlite(Configuration.GetConnectionString("Connection_Sqlite")));

            //使用MySql数据库
            // // services.AddDbContext<DUWENINKContext>(options => options.UseMySql(Configuration.GetConnectionString("Connection_MySql")));
            #endregion
            //权限验证filter
            services.AddMvc(cfg =>
            {
                cfg.Filters.Add(new RightFilter());
            });






            // var  a=   Configuration.GetSection("SystemCaches:WeiXinTicket:FromMinutes").Value;

            // service依赖注入
            services.UseDUWENINKService();
            #region hangfire自动任务配置数据库配置

            //使用sql server数据库做hangfire的持久化
            //services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("Connection_Job_SqlServer")));
            //使用mysql数据库做hangfire的持久化
            //services.AddHangfire(x => x.UseStorage(new MySqlStorage(Configuration.GetConnectionString("Connection_Job_MySql")))); 
            #endregion
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment  env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
           // app.UseMvc();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "doc/{documentName}/swagger.json";
            }).UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/doc/DUWENINKCoreWeb/swagger.json", "DUWENINKCoreWeb");
            });
            // app.UseCors("default");
            //app.UseExceptionHandler(builder =>
            //{

            //    //builder.Run(async context =>
            //    //{
            //    //    var exception=context.Features.GetEnumerator


            //    //});

            //});

            //全局身份认证

            //访问记录middleware
            //app.UseMiddleware<VisitMiddleware>();
            //app.UseCors("default");

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DUWENINK_API V1");
            //    c.RoutePrefix = string.Empty;
            //});
            //初始化数据库以及初始数据
            //Task.Run(async () =>
            //{
            //    using (var scope = app.ApplicationServices.CreateScope())
            //    {
            //        var menues = MenuHelper.GetMenues();
            //        var dbService = scope.ServiceProvider.GetService<IDatabaseInitService>();
            //        await dbService.InitAsync(menues);
            //    }
            //});
            #region HangFire
            //hangfire自动任务配置
            //var jobOptions = new BackgroundJobServerOptions
            //{
            //    ServerName = Environment.MachineName,
            //    WorkerCount = 1
            //};
            //app.UseHangfireServer(jobOptions);
            //var option = new DashboardOptions
            //{
            //    Authorization = new[] { new HangfireAuthorizationFilter() }
            //};
            //app.UseHangfireDashboard("/task", option);
            #endregion



            //添加一个每天自动在凌晨的时候执行的统计任务
            // RecurringJob.AddOrUpdate<ISiteViewService>(x => x.AddOrUpdate(), Cron.Daily());
            // RecurringJob.AddOrUpdate<IVaeService>(x => x.PushVaeNews(Configuration.GetSection("CqpApiUrl").Value), Cron.Minutely());//一分钟一次


            //RecurringJob.AddOrUpdate(() => Console.WriteLine($"Job在{DateTime.Now}执行完成."), Cron.Minutely());
            //RecurringJob.AddOrUpdate<IWeChatService>(x=>x.GetLastTicket(), Cron.Hourly);
        }

    }
    /// <summary>
    /// IIdentity扩展
    /// </summary>
    public static class IdentityExtention
    {
        
        /// <summary>
        /// 获取登录的用户ID
        /// </summary>
        /// <param name="identity">IIdentity</param>
        /// <returns></returns>
        public static string GetLoginUserId(this IIdentity identity)

        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("LoginUserId");
            if (claim != null)
            {
                return claim.Value;
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static  string GetLoginUserQQ(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("LoginUserQQ");
            return claim != null ? claim.Value : string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static List<UserRoleDto> GetLoginUserRoles(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("LoginUserRoles");
            return claim != null ? JsonConvert.DeserializeObject< List<UserRoleDto>>(claim.Value) : null;
        }
        /// <summary>
        /// 是否具备客服权限(权限最小只能看到自己的)只有不具备管理员角色的客服才能被称为客服
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool HaveServiceRight(this IIdentity identity)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return GetLoginUserRoles(identity).Any(c => c.RoleId == builder.Build()["TaoBaoConfig:ServiceRoleId"] && c.RoleId!= builder.Build()["TaoBaoConfig:AdminRoleId"]);//客服的角色id
        }
        /// <summary>
        /// 是否具备开发者权限只有不具备管理员角色的客服才能被称为开发者
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool HaveDeveloperRight(this IIdentity identity)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return GetLoginUserRoles(identity).Any(c => c.RoleId == builder.Build()["TaoBaoConfig:DeveloperRoleId"] && c.RoleId != builder.Build()["TaoBaoConfig:AdminRoleId"]);//客服的角色id
        }


}
}

