using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
   public class STSEntity : BaseEntity
    {
        /// <summary>
        /// 来自群
        /// </summary>
        public string FromGroup { get; set; }

        /// <summary>
        /// 来自QQ
        /// </summary>
        public string FromQQ { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string ToQQ { get; set; }
    }
}
