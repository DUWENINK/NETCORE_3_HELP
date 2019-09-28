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
    /// 群消息契约
    /// </summary>
    public interface ISTSService
    {
        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        Task<PagedResult<STSDto>> SearchSTSsAsync(STSFilters filters);

    }
}
