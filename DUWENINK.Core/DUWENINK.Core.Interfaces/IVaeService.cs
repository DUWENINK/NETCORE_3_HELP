using DUWENINK.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Interfaces
{
    /// <summary>
    /// 许嵩状态更新契约
    /// </summary>
   public interface IVaeService
    {
        /// <summary>
        /// 推送许嵩的动态
        /// </summary>
        Task<bool> PushVaeNews(string cqpApiUrl);

        /// <summary>
        /// 查询内容id是否在数据库
        /// </summary>
        /// <param name="ContentId"></param>
        /// <returns></returns>
        bool CheckExists(string ContentId);


        string InsertVaeNews(VaeNewsDto dto);
    }
}
