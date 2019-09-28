using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Interfaces
{
    public interface IJobService
    {
        /// <summary>
        /// 获取定时任务列表
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        Task<PagedResult<JobDto>> SearchJobsAsync(JobFilters filters);
    }
}
