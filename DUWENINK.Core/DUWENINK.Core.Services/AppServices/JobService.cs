using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Services.AppServices
{
    /// <summary>
    /// 定时任务契约实现
    /// </summary>
    public class JobService : IJobService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContextScopeFactory"></param>
        /// <param name="mapper"></param>
        public JobService(DUWENINKContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// index页面展示
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public  async Task<PagedResult<JobDto>> SearchJobsAsync(JobFilters filters)
        {
            if (filters == null)
                return new PagedResult<JobDto>();

            var query = _context.Jobs
                    .WhereIf(filters.keywords.IsNotBlank(), x => (x.ReviceAccount.Contains(filters.keywords)|| x.MessageContext.Contains(filters.keywords)));
            return await query.OrderByDescending(x => x.CreateDateTime)
                .Select(item => new JobDto
                {
                    Id = item.Id,
                    ReviceAccount = item.ReviceAccount,
                    JobReciveType=item.JobReciveType,
                    MessageContext = item.MessageContext
                }).PagingAsync(filters.page, filters.rows);
        }
    }
}
