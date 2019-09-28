using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;

namespace DUWENINK.Core.Interfaces
{
    /// <summary>
    /// 邮件客户端契约
    /// </summary>
   public interface ISmtpService
    {
        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        Task<PagedResult<SmtpDto>> SearchSmtpsAsync(SmtpFilters filters);
        /// <summary>
        /// 添加邮件配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<string> AddAsync(SmtpDto dto);
    }
}
