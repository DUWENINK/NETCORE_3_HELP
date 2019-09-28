using DUWENINK.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
   public class JobEntity:BaseEntity
    {


        /// <summary>
        /// 收件人QQ
        /// </summary>
        public string ReviceAccount { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageContext { get; set; }
        /// <summary>
        /// 是否已经送达
        /// </summary>
        public bool IsSend { get; set; }
        /// <summary>
        /// 发送方式
        /// </summary>
        public JobReciveType JobReciveType { get; set; }
        /// <summary>
        /// 送达时间
        /// </summary>
        public DateTime? DeliverTime { get; set; }

    }
}
