/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemGroupEntity
// 文 件 名：    ItemGroupEntity
// 创建者：      DUWENINK
// 创建日期：	2019/9/26 11:04:04
// 版本	日期					修改人	
// v0.1	2019/9/26 11:04:04	DUWENINK
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Data.Entity
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/26 11:04:04
    /// 类名：     ItemGroupEntity
    /// </summary>
    public class ItemGroupEntity : BaseEntity
    {
        /// <summary>
        /// 代码组的组名 例如 :性别
        /// </summary>
        public string ItemGroupText { get; set; }
        /// <summary>
        /// 代码组的组名Code  例如 :Gender
        /// </summary>
        public string ItemGroupCode { get; set; }
        /// <summary>
        /// 代码组的描述 例如 :本代码组表示性别的枚举
        /// </summary>
        public string ItemGroupDescription { get; set; }

        /// <summary>
        /// 排序号,用于决定代码组与组之间顺序的位置
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 是否可以多选
        /// </summary>
        public bool MultipleSelect { get; set; }

        /// <summary>
        /// 是否启用 
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 上级代码项Id
        /// </summary>
        public  string ParentItemGroupId { get; set; }


        /// <summary>
        /// 代码项列表
        /// </summary>
        public virtual IList<ItemEntity> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  virtual ItemGroupEntity ParentItemGroup { get; set; }

    }
}
