/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemEntity
// 文 件 名：    ItemEntity
// 创建者：      DUWENINK
// 创建日期：	2019/9/26 11:04:43
// 版本	日期					修改人	
// v0.1	2019/9/26 11:04:43	DUWENINK
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Data.Entity
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/26 11:04:43
    /// 类名：     ItemEntity
    /// </summary>
    public class ItemEntity : BaseEntity
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
        /// 全称(代码项的名称-当前代码项名称)
        /// </summary>
        public string ItemFullName { get; set; }
        /// <summary>
        /// 上级代码项Id
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

        /// <summary>
        /// 代码组主体
        /// </summary>
        public virtual ItemGroupEntity ItemGroup { get; set; }


        public virtual List<ItemEntity> ChildItems { get; set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public virtual ItemEntity ParentItem { get; set; }
    }
}
