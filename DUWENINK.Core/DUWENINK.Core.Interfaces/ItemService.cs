/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemService
// 文 件 名：    ItemService
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 14:14:33
// 版本	日期					修改人	
// v0.1	2019/9/27 14:14:33	DUWENINK
//----------------------------------------------------------------*/
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Interfaces
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Interfaces
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 14:14:33
    /// 类名：     ItemService
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// 添加 ItemGroup  添加成功返回itemgroup主键,失败返回string.Empty
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<string> AddItemGroup(ItemGroupDto dto);


        string AddItem(ItemDto dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<TreeDto>> FindByParentIdAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemGroupDto> FindItemGroupByIdAsync(string id);
    }
}
