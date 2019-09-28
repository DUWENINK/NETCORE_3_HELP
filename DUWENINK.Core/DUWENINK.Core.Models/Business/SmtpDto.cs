using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
   public class SmtpDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 邮件服务器
        /// </summary>
        [Display(Name = "邮件服务器")]
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [Display(Name = "端口")]
        public int Port { get; set; }
        /// <summary>
        /// 发送端帐号
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = Message.Required)]
        [MinLength(5, ErrorMessage = Message.MinLength)]
        [MaxLength(36, ErrorMessage = Message.MaxLength)]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$", ErrorMessage = "请输入正确的邮箱地址")]
        public string FromUserMail { get; set; }
        /// <summary>
        /// 发送端昵称
        /// </summary>
        [Display(Name = "发送端昵称")]
        [Required(ErrorMessage = Message.Required)]
        [MinLength(2, ErrorMessage = Message.MinLength)]
        [MaxLength(20, ErrorMessage = Message.MaxLength)]
        public string FromUserName { get; set; }
        /// <summary>
        /// 发送端密码
        /// </summary>
        [Display(Name = "发送端密码")]
        public string PassWord { get; set; }

        /// <summary>
        /// 使用默认凭据
        /// </summary>
        [Display(Name = "是否使用默认凭据")]
        public bool UseDefaultCredentials { get; set; }

        [Display(Name = "备注信息(用途)")]
        public string Remark { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateDateTime { get; set; }


    }
}
