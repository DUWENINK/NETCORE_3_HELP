using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
   public class PrivateMessageDto
    {
        /// <summary>
        /// qq号码
        /// </summary>
        public string qqid { get; set; }
        /// <summary>
        /// 发送消息
        /// </summary>
        public string msg { get; set; }
    }
}
