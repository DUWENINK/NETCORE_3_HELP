﻿using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Data;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Infrastructure.Extentions;

namespace DUWENINK.Core.Services.AppServices
{
    /// <summary>
    /// 日志契约实现
    /// </summary>
    public class LogService : ILogService
    {
        private readonly DUWENINKContext _context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public LogService(DUWENINKContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        public async Task<PagedResult<LoginLogDto>> SearchLoginLogsAsync(LogFilters filters)
        {
            var dbSet = _context.LoginLogs;
            var query = dbSet.AsQueryable();
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.LoginName.Contains(filters.keywords));

            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new LoginLogDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    LoginName = item.LoginName,
                    IP = item.IP,
                    Message = item.Message,
                    CreateDateTime = item.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }

        /// <summary>
        /// 获取访问日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        public async Task<PagedResult<VisitDto>> SearchVisitLogsAsync(LogFilters filters)
        {
            var dbSet = _context.PageViews;
            var query = dbSet.AsQueryable();
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.LoginName.Contains(filters.keywords));

            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new VisitDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    LoginName = item.LoginName,
                    Ip = item.IP,
                    Url = item.Url,
                    VisitDate = item.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }
    }
}
