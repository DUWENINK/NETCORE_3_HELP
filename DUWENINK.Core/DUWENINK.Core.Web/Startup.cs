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
            #region Swagger֧��
            //���Swagger. 3.0Ŀǰ����֧�� 20190926
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
            #region ������������ �����м�� NetCore3��ʱ����֪��֧�����,���Բ����
            //// needed to load configuration from appsettings.json
            //services.AddOptions();
            //// needed to store rate limit counters and ip rules
            //services.AddMemoryCache();
            ////api��������
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
            //��ӵ���ģʽ������ע��
            // services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            // services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            #endregion
            //identity server 4��������
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(Client.GetApiResources())
            //    .AddInMemoryClients(Clients.GetClients())
            //    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            //    .AddProfileService<JuCheapUserProfileService>();

            #region Cookie����
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(o =>
                   {
                       o.ExpireTimeSpan = TimeSpan.FromMinutes(480);//cookieĬ����Чʱ��Ϊ8��Сʱ
                       o.LoginPath = new PathString("/Home/Login");
                       o.LogoutPath = new PathString("/Home/Logout");
                       o.Cookie = new CookieBuilder
                       {
                           HttpOnly = true,
                           Name = ".DUWENINK.Core.Identity",
                           Path = "/"
                       };
                       //o.DataProtectionProvider = null;//�����Ҫ�����ؾ��⣬����Ҫ�ṩһ��Key
                   });
            #endregion



            #region ѡ��һ�����ݿ�
            //ʹ��Sql Server���ݿ�
            services.AddDbContext<DUWENINKContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection_SqlServer")));

            ////ʹ��Sqlite���ݿ�
            //services.AddDbContext<DUWENINKContext>(options => options.UseSqlite(Configuration.GetConnectionString("Connection_Sqlite")));

            //ʹ��MySql���ݿ�
            // // services.AddDbContext<DUWENINKContext>(options => options.UseMySql(Configuration.GetConnectionString("Connection_MySql")));
            #endregion
            //Ȩ����֤filter
            services.AddMvc(cfg =>
            {
                cfg.Filters.Add(new RightFilter());
            });






            // var  a=   Configuration.GetSection("SystemCaches:WeiXinTicket:FromMinutes").Value;

            // service����ע��
            services.UseDUWENINKService();
            #region hangfire�Զ������������ݿ�����

            //ʹ��sql server���ݿ���hangfire�ĳ־û�
            //services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("Connection_Job_SqlServer")));
            //ʹ��mysql���ݿ���hangfire�ĳ־û�
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

            //ȫ�������֤

            //���ʼ�¼middleware
            //app.UseMiddleware<VisitMiddleware>();
            //app.UseCors("default");

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DUWENINK_API V1");
            //    c.RoutePrefix = string.Empty;
            //});
            //��ʼ�����ݿ��Լ���ʼ����
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
            //hangfire�Զ���������
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



            //���һ��ÿ���Զ����賿��ʱ��ִ�е�ͳ������
            // RecurringJob.AddOrUpdate<ISiteViewService>(x => x.AddOrUpdate(), Cron.Daily());
            // RecurringJob.AddOrUpdate<IVaeService>(x => x.PushVaeNews(Configuration.GetSection("CqpApiUrl").Value), Cron.Minutely());//һ����һ��


            //RecurringJob.AddOrUpdate(() => Console.WriteLine($"Job��{DateTime.Now}ִ�����."), Cron.Minutely());
            //RecurringJob.AddOrUpdate<IWeChatService>(x=>x.GetLastTicket(), Cron.Hourly);
        }

    }
    /// <summary>
    /// IIdentity��չ
    /// </summary>
    public static class IdentityExtention
    {
        
        /// <summary>
        /// ��ȡ��¼���û�ID
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
        /// �Ƿ�߱��ͷ�Ȩ��(Ȩ����Сֻ�ܿ����Լ���)ֻ�в��߱�����Ա��ɫ�Ŀͷ����ܱ���Ϊ�ͷ�
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool HaveServiceRight(this IIdentity identity)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return GetLoginUserRoles(identity).Any(c => c.RoleId == builder.Build()["TaoBaoConfig:ServiceRoleId"] && c.RoleId!= builder.Build()["TaoBaoConfig:AdminRoleId"]);//�ͷ��Ľ�ɫid
        }
        /// <summary>
        /// �Ƿ�߱�������Ȩ��ֻ�в��߱�����Ա��ɫ�Ŀͷ����ܱ���Ϊ������
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool HaveDeveloperRight(this IIdentity identity)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return GetLoginUserRoles(identity).Any(c => c.RoleId == builder.Build()["TaoBaoConfig:DeveloperRoleId"] && c.RoleId != builder.Build()["TaoBaoConfig:AdminRoleId"]);//�ͷ��Ľ�ɫid
        }


}
}

