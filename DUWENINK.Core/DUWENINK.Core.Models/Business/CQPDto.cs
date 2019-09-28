using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
    /// <summary>
    /// 发送私聊消息入参
    /// </summary>
    [Description("CQ_sendPrivateMsgDto")]
    public class PrivateMsgDto
    {
        /// <summary>
        /// QQ帐号
        /// </summary>
        public long qqid { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }



}
