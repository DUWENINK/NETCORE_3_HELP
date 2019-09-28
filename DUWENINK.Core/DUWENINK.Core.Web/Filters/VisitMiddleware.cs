using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;

namespace DUWENINK.Core.Web.Filters
{
    /// <summary>
    /// 访问管道
    /// </summary>
    public class VisitMiddleware
    {
        readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public VisitMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            #region 记录访问记录

            try
            {
                var userService = context.RequestServices.GetService<IUserService>();

                var connection = context.Features.Get<IHttpConnectionFeature>();
                var user = context.User;
                var isLogined = user?.Identity != null && user.Identity.IsAuthenticated;
                var visit = new VisitDto
                {
                    Ip = connection.RemoteIpAddress.ToString(),
                    LoginName = isLogined ? user.Identity.Name : string.Empty,
                    Url = context.Request.Path,
                    UserId = user?.Identity.GetLoginUserId()??string.Empty,
                    VisitDate=DateTime.Now
                };
                await userService.VisitAsync(visit);
            }
            catch
            {
                //eat exception
            }

            #endregion
        }
    }
}
