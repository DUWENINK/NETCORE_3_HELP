/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemService
// 文 件 名：    ItemService
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 15:17:30
// 版本	日期					修改人	
// v0.1	2019/9/27 15:17:30	DUWENINK
//----------------------------------------------------------------*/
using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Services.AppServices
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Services.AppServices
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 15:17:30
    /// 类名：     ItemService
    /// </summary>
    public class ItemService : IItemService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;

        public ItemService(DUWENINKContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        #region 代码组
        /// <summary>
        /// 获取左边树形区域
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<TreeDto>> FindByParentIdAsync(string parentId)
        {
            var query = _context.ItemGroups
                .WhereIf(parentId.IsBlank() || parentId == "0", x => x.ParentItemGroupId == null || x.ParentItemGroupId == string.Empty || x.ParentItemGroupId == "0")
                .WhereIf(parentId.IsNotBlank(), x => x.ParentItemGroupId == parentId);
            return await query.Select(x => new TreeDto
            {
                id = x.Id,
                name = x.ItemGroupText,
                pId = x.ParentItemGroupId,
                isParent = _context.Areas.Any(c => c.ParentId == "0" || c.ParentId == x.Id)
            }).ToListAsync();
        }
        /// <summary>
        /// 添加 ItemGroup  添加成功返回itemgroup主键,失败返回string.Empty
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> AddItemGroup(ItemGroupDto dto)
        {
            var entity = _mapper.Map<ItemGroupEntity>(dto);
            entity.Init();
            //var sss = _middleMDMContext.ItemGroups.Where(c => c.ItemGroupCode == dto.ItemGroupCode).ToList();
            if (_context.ItemGroups.Any(c => c.ItemGroupCode == dto.ItemGroupCode))
            {
                return string.Empty;
            }
             await _context.ItemGroups.AddAsync(entity);
             await _context.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemGroupDto> FindItemGroupByIdAsync(string id) 
        {
            if (id.IsBlank())
                return null;
            var entity = await _context.ItemGroups.FindAsync(id);
            var result = _mapper.Map<ItemGroupEntity, ItemGroupDto>(entity);
            if (result?.ParentItemGroupId.IsBlank() == false)
            {
                var parent = await _context.ItemGroups.FindAsync(entity.ParentItemGroupId);
                result.ParentItemGroupText = parent?.ItemGroupText;
            }
            return result;


        }





        #endregion


        #region 代码项




        #endregion


        public string AddItem(ItemDto dto)
        {
            throw new NotImplementedException();
        }

        

     
    }
}
