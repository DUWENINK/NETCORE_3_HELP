using DUWENINK.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
   public class JobDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        [Display(Name = "收件人")]
        [MinLength(5, ErrorMessage = Message.MinLength)]
        public string ReviceAccount { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        [Display(Name = "消息内容")]
        [MinLength(1, ErrorMessage = Message.MinLength)]
        public string MessageContext { get; set; }
        /// <summary>
        /// 是否已经送达
        /// </summary>
        [Display(Name = "送达状态")]
        public bool IsSend { get; set; }
        /// <summary>
        /// 发送方式
        /// </summary>
        [Display(Name = "发送方式")]
        public JobReciveType JobReciveType { get; set; }
    }
}
