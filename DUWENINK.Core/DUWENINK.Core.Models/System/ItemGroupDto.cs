/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    ItemGroupDto
// 文 件 名：    ItemGroupDto
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 14:16:44
// 版本	日期					修改人	
// v0.1	2019/9/27 14:16:44	DUWENINK
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DUWENINK.Core.Models.System
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Models.System
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 14:16:44
    /// 类名：     ItemGroupDto
    /// </summary>
    public class ItemGroupDto
    {
        /// <summary>
        /// 代码组的组名 例如 :性别
        /// </summary>
        [Required]
        [Display(Name = "代码组名称")]
        public string ItemGroupText { get; set; }
        /// <summary>
        /// 代码组的组名Code  例如 :Gender
        /// </summary>
        [Required]
        [Display(Name = "代码组Code")]
        [RegularExpression("^[^_][a-zA-Z0-9_]*$", ErrorMessage = "代码组的名称必须是数字,字母或者下划线的组合")]
        public string ItemGroupCode { get; set; }

        /// <summary>
        /// 父级代码项Id
        /// </summary>
        
        public string ParentItemGroupId { get; set; }

        /// <summary>
        /// 父级代码名称
        /// </summary>
        [Display(Name = "上级代码项")]
        public string ParentItemGroupText { get; set; }

        /// <summary>
        /// 代码组的描述 例如 :本代码组表示性别的枚举
        /// </summary>
        [Display(Name = "代码项描述")]
        public string ItemGroupDescription { get; set; }

        /// <summary>
        /// 排序号,用于决定代码组与组之间顺序的位置
        /// </summary>
        [Display(Name = "排序")]
        public int Index { get; set; }
        /// <summary>
        /// 是否可以多选
        /// </summary>
        [Display(Name = "是否多选")]
        public bool MultipleSelect { get; set; } = true;


    }
}
