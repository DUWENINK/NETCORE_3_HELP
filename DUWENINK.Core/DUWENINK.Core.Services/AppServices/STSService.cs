using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Data;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;

namespace DUWENINK.Core.Services.AppServices
{
    public class STSService : ISTSService
    {
        private readonly DUWENINKContext _context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public STSService(DUWENINKContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        public async Task<PagedResult<STSDto>> SearchSTSsAsync(STSFilters filters)
        {
            var dbSet = _context.STSs;
            var query = dbSet.AsQueryable();
            var now = DateTime.Now;
            query = query.Where(item =>
                (item.CreateDateTime.Year == now.Year && item.CreateDateTime.Date == now.Date &&
                 item.CreateDateTime.Day == now.Day));
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => (item.Message.Contains(filters.keywords) || item.FromGroup.Contains(filters.keywords) || item.FromQQ.Contains(filters.keywords)));
            if (filters.FromQQ.IsNotBlank())
                query = query.Where(item => item.FromQQ == filters.FromQQ);
                return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new STSDto
                {
                    Id = item.Id,
                    FromGroup = item.FromGroup,
                    FromQQ = item.FromQQ,
                    Message = item.Message,
                    CreateDateTime = item.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }
    }
}
