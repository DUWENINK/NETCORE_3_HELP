using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DUWENINK.Core.Infrastructure.Attributes;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Models.Enum;

namespace DUWENINK.Core.Models.Business
{

    /// <summary>
    /// 开发者编辑实体
    /// </summary>
   public class ProjectUpdateDto:ProjectAddDto
    {

        /// <summary>
        /// 做完时间
        /// </summary>
        [Display(Name = "做完时间")]
        public DateTime? ProjectEndTime { get; set; }
     
        /// <summary>
        /// 结清时间
        /// </summary>
        [Display(Name = "结清时间")]
        public DateTime? SettleTime { get; set; }
        /// <summary>
        /// 存储库地址
        /// </summary>
        [Display(Name = "存储库地址")]
        public string  ProjectPath { get; set; }

        /// <summary>
        /// 客服名称
        /// </summary>
        public string FromCustomServiceName { get; set; }

        /// <summary>
        /// 到手金额
        /// </summary>
        [Display(Name = "到手金额")]
        [Number(ErrorMessage = "请输入数字")]
        public  decimal ProjectWorth { get; set; }

        [Display(Name = "回款周期")]
        public string SettleIntervalStr => SettleInterval.GetDescriptionForEnum();


    }
}
