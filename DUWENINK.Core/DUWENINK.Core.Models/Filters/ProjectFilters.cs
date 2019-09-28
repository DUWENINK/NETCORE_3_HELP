using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Filters
{
   public class ProjectFilters : BaseFilter
    {
        ///// <summary>
        /////客服QQ
        ///// </summary>
        //public string FromCustomServiceQQ { get; set; }
        /// <summary>
        /// 创建者id只有客服才可以创建表单
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 开发者id
        /// </summary>
        public string ChargePersonId { get; set; }


    }
}
