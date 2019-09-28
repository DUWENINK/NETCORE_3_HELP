using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
   public class FileCollectionEntity:BaseEntity
    {
        /// <summary>
        /// CpuId
        /// </summary>
        public string CpuId { get; set; }
        /// <summary>
        /// 文件名 /xxx.jpg
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 相对路径 CpuId/D/xxx/xxx.jpg
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 用户电脑的文件路径 D:/xxx/xxx.jpg
        /// </summary>
        public string UserFilePath { get; set; }

        /// <summary>
        /// Image文件流
        /// </summary>
        public byte[] ImageFileStream { get; set; }

    }
}
