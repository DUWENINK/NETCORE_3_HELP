/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemDto
// 文 件 名：    ItemDto
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 14:18:40
// 版本	日期					修改人	
// v0.1	2019/9/27 14:18:40	DUWENINK
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.System
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Models.System
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 14:18:40
    /// 类名：     ItemDto
    /// </summary>
    public class ItemDto
    {
        /// <summary>
        /// 代码项中代码组的id,标识本代码项属于的代码组
        /// </summary>
        public string ItemGroupId { get; set; }
        /// <summary>
        /// 代码项的项名 例如 :男
        /// </summary>
        public string ItemText { get; set; }
        /// <summary>
        /// 代码项的项名Code  例如 :Male
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 代码项的描述 例如 :本代码项表示男性
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// 上级代码项Id 本字段属于<c cref="ItemGroupId">二级验证外键</c>
        /// </summary>
        public string ParentItemId { get; set; }
        /// <summary>
        /// 路径码=(上级的路径码-当前的ItemCode)
        /// </summary>
        public string PathCode { get; set; }
        /// <summary>
        /// 排序号,用于决定代码项与项之间顺序的位置
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 标识本代码项是否可以选择
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
