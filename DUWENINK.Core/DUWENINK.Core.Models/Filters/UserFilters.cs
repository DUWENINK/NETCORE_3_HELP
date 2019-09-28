using System.Collections.Generic;

namespace DUWENINK.Core.Models.Filters
{
    /// <summary>
    /// 用户搜索过滤器
    /// </summary>
    public class UserFilters : BaseFilter
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public List<string> DepartmentIdList { get; set; }
    }
}
