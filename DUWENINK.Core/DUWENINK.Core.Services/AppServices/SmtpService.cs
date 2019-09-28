using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Enum;
using DUWENINK.Core.Models.Filters;
using Microsoft.EntityFrameworkCore;

namespace DUWENINK.Core.Services.AppServices
{
   public class SmtpService: ISmtpService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public SmtpService(DUWENINKContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// 添加邮件服务器
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> AddAsync(SmtpDto dto)
        {
            var entity = _mapper.Map<SmtpDto, SmtpEntity>(dto);
            entity.Init();
            //entity.CreateUserId=
            var dbSet = _context.Smtps;
            dbSet.Add(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }

        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        public async Task<PagedResult<SmtpDto>> SearchSmtpsAsync(SmtpFilters filters)
        {
            var dbSet = _context.Smtps;
            var query = dbSet.AsQueryable();
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.FromUserName.Contains(filters.keywords) || item.FromUserMail.Contains(filters.keywords) || item.Host.Contains(filters.keywords));
            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new SmtpDto
                {
                    Id = item.Id,
                    Host = item.Host,
                    Port = item.Port,
                    FromUserMail = item.FromUserMail,
                    FromUserName = item.FromUserName,
                    PassWord = item.PassWord,
                    UseDefaultCredentials= item.UseDefaultCredentials
                }).PagingAsync(filters.page, filters.rows);
        }
    }
}
