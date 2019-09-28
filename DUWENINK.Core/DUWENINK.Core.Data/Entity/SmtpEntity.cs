using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
    public class SmtpEntity : BaseEntity
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
        /// <summary>
        /// 发送端密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 备注
        /// </summary>

        public string Remark { get; set; }

        /// <summary>
        /// 使用默认凭据
        /// </summary>
        public bool UseDefaultCredentials { get; set; }


    }
}
