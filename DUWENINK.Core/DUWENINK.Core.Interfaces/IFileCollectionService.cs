using DUWENINK.Core.Models.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Interfaces
{
    /// <summary>
    /// 文件获取契约
    /// </summary>
   public interface IFileCollectionService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cpuId">cpuId</param>
        /// <returns></returns>
        Task<IList<string>> GetFileNameList(string cpuId);

        /// <summary>
        /// 添加文件信息
        /// </summary>
        /// <returns></returns>
        Task<string> AddFileRecord(FileCollectionDto fileCollectionDto);
    }
}
