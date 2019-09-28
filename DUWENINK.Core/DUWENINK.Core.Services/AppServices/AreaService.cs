using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace DUWENINK.Core.Services.AppServices
{
    /// <summary>
    /// 省市区契约服务
    /// </summary>
    public class AreaService : IAreaService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContextScopeFactory"></param>
        /// <param name="mapper"></param>
        public AreaService(DUWENINKContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto">模型</param>
        /// <returns></returns>
        public async Task<string> Add(AreaDto dto)
        {
            var entity = _mapper.Map<AreaDto, AreaEntity>(dto);
            entity.Init();
            entity.PathCode = await GetPathCode(entity.ParentId);
            entity.SimpleSpelling = entity.Name.GetChineseSpell();
            _context.Areas.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto">模型</param>
        /// <returns></returns>
        public async Task<bool> Update(AreaDto dto)
        {
            var entity = await _context.Areas.FindAsync(dto.Id);
            entity.Name = dto.Name;
            entity.SimpleSpelling = dto.SimpleSpelling;
            entity.FullSpelling = dto.FullSpelling;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 根据主键查询模型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<AreaDto> Find(string id)
        {
            if (id.IsBlank())
                return null;
            var entity = await _context.Areas.FindAsync(id);
            var result = _mapper.Map<AreaEntity, AreaDto>(entity);
            if (result?.ParentId.IsBlank() == false)
            {
                var parent = await _context.Areas.FindAsync(entity.ParentId);
                result.ParentName = parent?.Name;
            }
            return result;
        }

        /// <summary>
        /// 根据父ID查询
        /// </summary>
        /// <param name="parentId">父ID</param>
        /// <returns></returns>
        public async Task<IList<TreeDto>> FindByParentId(string parentId)
        {
            var query = _context.Areas
                .WhereIf(parentId.IsBlank() || parentId == "0", x => x.ParentId == null || x.ParentId == string.Empty || x.ParentId == "0")
                .WhereIf(parentId.IsNotBlank(), x => x.ParentId == parentId);
            return await query.Select(x => new TreeDto
            {
                id = x.Id,
                name = x.Name,
                pId = x.ParentId,
                isParent = _context.Areas.Any(c => c.ParentId == "0" || c.ParentId == x.Id)
            }).ToListAsync();
        }
        /// <summary>
        /// 根据父ID查询
        /// </summary>
        /// <param name="parentId">父ID</param>
        /// <returns></returns>
        public async Task<IList<TreeDto>> FindAllByParentId(string parentId)
        {
            var query = _context.Areas
                //.WhereIf(parentId.IsBlank() || parentId == "0", x => x.ParentId == null || x.ParentId == string.Empty || x.ParentId == "0")
                .WhereIf(parentId.IsNotBlank(), x => x.ParentId == parentId /*寻找直接子集*/||x.ParentId.StartsWith(parentId.TrimEnd('0'))/*根据规则寻找间接子集*/|| x.Id == parentId/*算上自己*/ );
            return await query.Select(x => new TreeDto
            {
                id = x.Id,
                name = x.Name,
                pId = x.ParentId,
                isParent = _context.Areas.Any(c => c.ParentId == "0" || c.ParentId == x.Id)
            }).ToListAsync();
        }



        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> Delete(IList<string> ids)
        {
            var areas = await _context.Areas.Where(x => ids.Contains(x.Id)).ToListAsync();

            if (!areas.AnyOne())
            {
                throw new Exception("没有找到任何需要删除的数据");
            }

            if (await _context.Areas.AnyAsync(x => x.Enabled && ids.Contains(x.ParentId)))
            {
                throw new Exception("该节点下还有子节点，请删除子节点");
            }

            foreach (var area in areas)
            {
                area.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="id">区域id，可以为空</param>
        /// <param name="name">区域名称</param>
        /// <returns></returns>
        public async Task<bool> IsExists(string id, string name)
        {
            var query = _context.Areas.Where(x => x.Name == name)
                   .WhereIf(id.IsBlank() == false, x => x.Id != id && x.ParentId == id);
            return await query.AnyAsync();
        }

        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="filters">查询过滤参数</param>
        /// <returns></returns>
        public async Task<PagedResult<AreaDto>> Search(BaseFilter filters)
        {
            if (filters == null)
                return new PagedResult<AreaDto>();

            var query = _context.Areas
                    .WhereIf(filters.keywords.IsNotBlank(), x => x.Name.Contains(filters.keywords));

            return await query.OrderByDescending(x => x.CreateDateTime)
                .Select(item => new AreaDto
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name,
                    FullSpelling = item.FullSpelling,
                    SimpleSpelling = item.SimpleSpelling,
                    Enabled = item.Enabled,
                    Level = item.Level,
                    DisplaySequence = item.DisplaySequence
                }).PagingAsync(filters.page, filters.rows);
        }

        /// <summary>
        /// 更新路劲码
        /// </summary>
        public async Task<bool> UpdatePathCodes()
        {
            while (await _context.Areas.AnyAsync(x => x.PathCode == string.Empty))
            {
                var query = _context.Areas.Where(x => x.PathCode == string.Empty);
                var list = query.AsNoTracking().Take(100).ToList();
                foreach (var area in list)
                {
                    var entity = _context.Areas.Find(area.Id);
                    if (entity != null)
                    {
                        var parent = _context.Areas.Find(entity.ParentId);
                        if (parent != null && parent.PathCode.IsNotBlank())
                        {
                            entity.PathCode = await GetPathCode(entity.ParentId);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取路径码
        /// </summary>
        /// <param name="db"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private async Task<string> GetPathCode(string parentId)
        {
            //顶级页面
            List<string> existCodes;
            var parentPathCode = string.Empty;
            if (parentId.IsBlank())
            {
                var list = await _context.Areas
                    .Where(x => (x.ParentId == null || x.ParentId == string.Empty))
                    .Select(x => x.PathCode).ToListAsync();
                existCodes = list.Select(x => x.Trim()).ToList();
            }
            else
            {
                var area = await _context.Areas.FindAsync(parentId);
                parentPathCode = area?.PathCode;

                var list = await _context.Areas.Where(x => x.ParentId == parentId && x.PathCode != string.Empty)
                    .Select(x => x.PathCode).ToListAsync();
                existCodes = list.Select(x => x.Substring(area.PathCode.Trim().Length, 2)).ToList();
            }
            var pathCode = await _context.PathCodes
                    .OrderBy(x => x.Code)
                    .FirstOrDefaultAsync(x => !existCodes.Contains(x.Code));
            return parentPathCode.Trim() + pathCode.Code.Trim();
        }

        public async Task<PagedResult<AreaOfferDto>> SearchPAreaOffersAsync(AreaOfferFilter filters)
        {
            if (filters == null)//110000
                return new PagedResult<AreaOfferDto>();
            var parent =await FindAllByParentId(filters.AreaId);
            var query = _context.AreaOffers
                    .WhereIf(filters.AreaId.IsNotBlank(), x => x.AreaId == filters.AreaId || x.AreaId.StartsWith(GetParentAreaId(filters.AreaId)));

            return await query.OrderByDescending(x => x.CreateDateTime)
                .Select(item => new AreaOfferDto
                {
                    Id = item.Id,
                    AreaId=item.AreaId,
                    AreaName= parent==null?string.Empty: (parent.FirstOrDefault(c=>c.id==item.AreaId)==null?string.Empty: parent.FirstOrDefault(c => c.id == item.AreaId).name),
                    //AreaName = parent?.FirstOrDefault(c=>c.id==item.AreaId)?.name??string.Empty,
                    A1OfferPrice = item.A1OfferPrice,
                    A2OfferPrice = item.A2OfferPrice,
                    A3OfferPrice = item.A3OfferPrice,
                    B1OfferPrice = item.B1OfferPrice,
                    B2OfferPrice = item.B2OfferPrice,
                    C1OfferPrice = item.C1OfferPrice,
                    C2OfferPrice = item.C2OfferPrice,
                    C3OfferPrice = item.C3OfferPrice,
                    C4OfferPrice = item.C4OfferPrice,
                    DOfferPrice = item.DOfferPrice,
                    EOfferPrice = item.EOfferPrice,
                    FOfferPrice = item.FOfferPrice,
                    MOfferPrice = item.MOfferPrice,
                    NOfferPrice = item.NOfferPrice,
                    POfferPrice = item.POfferPrice,
                    CreateDateTime = item.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }
        static string GetParentAreaId(string sourceAreaId)
        {
            if (sourceAreaId?.Length > 2)
            {
                string temp = sourceAreaId?.Substring(sourceAreaId.Length - 2);
                if (temp == "00")
                {
                    sourceAreaId = sourceAreaId?.Substring(0, sourceAreaId.Length - 2);
                    sourceAreaId = GetParentAreaId(sourceAreaId);
                }
            }
            return sourceAreaId;
        }

        public async Task<string> AddAsync(AreaOfferDto dto)
        {
            var entity = _mapper.Map<AreaOfferDto, AreaOfferEntity>(dto);
            entity.Init();
            _context.AreaOffers.Add(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }

        /// <summary>
        /// 根据地区编码和驾照类型获取报价
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<decimal> GetOfferByAreaId(string areaId,string type)
        {
          var offer = await _context.AreaOffers.OrderByDescending(c => c.CreateDateTime).FirstOrDefaultAsync(c => c.AreaId == areaId);
            if (offer == null) return 0;
            switch (type)
            {
                case "A1":
                    return offer.A1OfferPrice;
                case "A2":
                    return offer.A2OfferPrice;
                case "A3":
                    return offer.A3OfferPrice;
                case "B1":
                    return offer.B1OfferPrice;
                case "B2":
                    return offer.B2OfferPrice;
                case "C1":
                    return offer.C1OfferPrice;
                case "C2":
                    return offer.C2OfferPrice;
                case "C3":
                    return offer.C3OfferPrice;
                case "C4":
                    return offer.C4OfferPrice;
                case "D":
                    return offer.DOfferPrice;
                case "E":
                    return offer.EOfferPrice;
                case "F":
                    return offer.FOfferPrice;
                case "M":
                    return offer.MOfferPrice;
                case "N":
                    return offer.NOfferPrice;
                case "P":
                    return offer.POfferPrice;
                default:
                    return 0;
            }


        }


    }
}
