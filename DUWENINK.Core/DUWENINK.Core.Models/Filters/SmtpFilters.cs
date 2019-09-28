using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Filters
{
   public class SmtpFilters: BaseFilter
    {
        /// <summary>
        /// 邮件服务器
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 发送端帐号
        /// </summary>
        public string FromUserMail { get; set; }
        /// <summary>
        /// 发送端昵称
        /// </summary>
        public string FromUserName { get; set; }
    }
}
