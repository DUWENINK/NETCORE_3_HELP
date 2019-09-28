using System;
using System.ComponentModel.DataAnnotations;
using DUWENINK.Core.Infrastructure.Attributes;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Models.Enum;

namespace DUWENINK.Core.Models.Business
{


    /// <summary>
    /// 客服添加dto
    /// </summary>
   public class ProjectAddDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 客服QQ
        /// </summary>
        [Display(Name = "客服QQ")]
        [QQ(ErrorMessage = "请输入正确的QQ号码")]
        public string FromCustomServiceQQ { get; set; }

        /// <summary>
        /// 客户QQ
        /// </summary>
        [Display(Name = "客户QQ")]
        [QQ(ErrorMessage = "请输入正确的QQ号码")]
        public string FromCustomQQ { get; set; }
        /// <summary>
        /// QQ群
        /// </summary>
        [Display(Name = "QQ群")]
        [QQ(ErrorMessage = "请输入正确的QQ群号码")]
        public string FromQQGroup { get; set; }
        /// <summary>
        /// 项目开始时间
        /// </summary>
        [Display(Name = "项目开始时间")]
        [Required(ErrorMessage = Message.Required)]
        public DateTime? ProjectStartTime { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Display(Name = "负责人姓名")]
        [Required(ErrorMessage = Message.Required)]
        public string ChargePersonName { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Display(Name = "负责人")]
        [Required(ErrorMessage = Message.Required)]
        public string ChargePersonId { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        [Display(Name = "约定金额")]
        [Number(ErrorMessage = "请输入数字。")]
        public decimal? ProjectAgreementWorth { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        [Display(Name = "项目类型")]
        [Required(ErrorMessage = Message.Required)]
        public ProjectType ProjectType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [Required(ErrorMessage = Message.Required)]
        [MinLength(4, ErrorMessage = Message.MinLength)]
        [MaxLength(200, ErrorMessage = Message.MaxLength)]
        public string Remarks { get; set; }
        /// <summary>
        /// 项目群
        /// </summary>
        [Display(Name = "三方群")]
        [QQ(ErrorMessage = "请输入正确的QQ群号码")]
        public string ProjectQQGroup { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        [Display(Name = "项目标题")]
        [Required(ErrorMessage = Message.Required)]
        [MinLength(4, ErrorMessage = Message.MinLength)]
        [MaxLength(2000, ErrorMessage = Message.MaxLength)]
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 结清间隔
        /// </summary>
        [Display(Name = "回款周期(天)")]
        public SettleIntervalType SettleInterval { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        [Display(Name = "截止日期")]
        public DateTime? ProjectServiceEndTime { get; set; }
        /// <summary>
        /// 客户旺旺
        /// </summary>
        [Display(Name = "客户旺旺")]
        public string FromCustomWangWang { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Display(Name = "订单编号")]
        public string OrderNumber { get; set; }

    }


    public class ServiceEditDto : ProjectAddDto
    {
        /// <summary>
        /// 客户旺旺
        /// </summary>
        [Display(Name = "项目状态")]

        public ProjectStatus ProjectStatus { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        [Display(Name = "项目状态汉字")]
        public string ProjectStatusText => ProjectStatus.GetDescription();
    }
    

}
