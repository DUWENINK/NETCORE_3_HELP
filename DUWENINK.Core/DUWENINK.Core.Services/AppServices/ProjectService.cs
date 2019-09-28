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
using DUWENINK.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace DUWENINK.Core.Services.AppServices
{
    public class ProjectService : IProjectService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ProjectService(DUWENINKContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> AddAsync(ProjectAddDto dto,string createId,string cqpUrl)
        {
            var entity = _mapper.Map<ProjectAddDto, ProjectEntity>(dto);
            entity.Init();
            entity.CreateUserId = createId;
            entity.ProjectStatus = ProjectStatus.OnStart;//项目为起始状态
            var dbSet = _context.Projects;
            dbSet.Add(entity);
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == createId);
            var chargePerson = await _context.Users.FirstOrDefaultAsync(c => c.Id == entity.ChargePersonId);
            if (user != null)
            {
                long.TryParse(user.UserQq, out long UserQQ);
                var cqp = new CQPHelper(cqpUrl);
                await cqp.SendPrivateMessage(new PrivateMsgDto
                {
                    qqid = UserQQ,
                    msg = $"您好!项目:{entity.ProjectTitle} 已经被记录!负责人:{chargePerson?.RealName},QQ:{chargePerson?.UserQq}",
                });
                long.TryParse(entity.ChargePerson.UserQq, out long ChargeQQ);
                await cqp.SendPrivateMessage(new PrivateMsgDto
                {
                    qqid = ChargeQQ,
                    msg = $"您好!项目:{entity.ProjectTitle} 已经被客服{user.RealName} 记录!客服QQ:{user.UserQq},请及时处理!",
                });

            }
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }

        public async Task<PagedResult<ProjectUpdateDto>> SearchProjectsAsync(ProjectFilters filters)
        {
            if (filters == null)
                return new PagedResult<ProjectUpdateDto>(0, 0);

            var query = _context.Projects.AsQueryable();
            if (filters.keywords.IsNotBlank())
                query = query.Where(item =>  item.FromCustomQQ.Contains(filters.keywords) || item.FromCustomServiceQQ.Contains(filters.keywords) || item.FromQQGroup.Contains(filters.keywords) || item.ProjectTitle.Contains(filters.keywords));
            if (filters.CreateUserId.IsNotBlank())
            {
                query = query.Where(item => item.CreateUserId == filters.CreateUserId);
            }
            if (filters.ChargePersonId.IsNotBlank())
            {
                query = query.Where(item => item.ChargePersonId == filters.ChargePersonId);
            }
            var users = _context.Users.AsQueryable();
            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new ProjectUpdateDto
                {
                    Id = item.Id,
                     FromCustomQQ = item.FromCustomQQ,
                    FromCustomServiceQQ = item.FromCustomServiceQQ,
                    FromQQGroup = item.FromQQGroup,
                    ProjectStartTime = item.ProjectStartTime,

                    ProjectEndTime = item.ProjectEndTime,
                    ProjectQQGroup = item.ProjectQQGroup,
                    ProjectTitle = item.ProjectTitle,
                    Remarks = item.Remarks,
                    SettleInterval = item.SettleInterval,
                    SettleTime = item.SettleTime,
                    ChargePersonId = item.ChargePersonId,
                    ChargePersonName= users.FirstOrDefault(c=>c.Id == item.ChargePersonId).RealName??string.Empty,
                    ProjectAgreementWorth = item.ProjectAgreementWorth,
                     ProjectWorth = item.ProjectWorth,
                    ProjectType = item.ProjectType
                }).PagingAsync(filters.page, filters.rows);
        }

        public async Task<bool> UpdateAsync(ProjectUpdateDto dto)
        {
            var dbSet = _context.Projects;
            var entity = dbSet.FirstOrDefault(r => r.Id == dto.Id);
            _mapper.Map(dto, entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ProjectUpdateDto> Find(string id)
        {
            if (id.IsBlank())
            {
                return null;
            }
            var entity = await _context.Projects.Include(c=>c.ChargePerson).FirstOrDefaultAsync(c=>c.Id== id);
            var result = _mapper.Map<ProjectEntity, ProjectUpdateDto>(entity);
            return result;
        }

        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {
            var projects = _context.Projects.Where(x => ids.Contains(x.Id)).ToList();
            if (!projects.AnyOne())
            {
                throw new Exception("没有找到要删除的项目");
            }
            //标记成逻辑删除
            foreach (var project in projects)
            {
                project.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
            return true;



        }
        /// <summary>
        /// 客服编辑实现逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceEditDto> ServiceEdit(string id)
        {
            if (id.IsBlank())
            {
                return null;
            }
            var project =await _context.Projects.FirstOrDefaultAsync(c=>c.Id.Equals(id));
            if (project==null)
            {
                throw new Exception("没有找到要编辑的项目");
            }
            var result = _mapper.Map<ProjectEntity, ServiceEditDto>(project);
            return result;



        }
    }
}
