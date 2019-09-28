using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Models.System;

namespace DUWENINK.Core.Interfaces
{
    /// <summary>
    /// 项目管理契约
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="dto">角色模型</param>
        /// <param name="cqpUrl">CQPurl</param>
        /// <returns></returns>
        Task<string> AddAsync(ProjectAddDto dto, string createId,string cqpUrl);

        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="filters">查询过滤参数</param>
        /// <returns></returns>
        Task<PagedResult<ProjectUpdateDto>> SearchProjectsAsync(ProjectFilters filters);
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="dto">角色模型</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(ProjectUpdateDto dto);
        /// <summary>
        /// 根据主键查询模型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ProjectUpdateDto> Find(string id);

        /// <summary>
        /// 删除项目逻辑
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(IEnumerable<string> ids);
        /// <summary>
        /// 客服编辑项目逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceEditDto> ServiceEdit(string id);
    }
}
