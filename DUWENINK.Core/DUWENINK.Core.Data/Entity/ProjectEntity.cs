using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Models.Enum;

namespace DUWENINK.Core.Data.Entity
{
   public class ProjectEntity:BaseEntity
    {  
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string FromCustomServiceQQ { get; set; }
        /// <summary>
        /// 客户QQ
        /// </summary>
        public string FromCustomQQ { get; set; }
        /// <summary>
        /// QQ群
        /// </summary>
        public string FromQQGroup { get; set; }


        /// <summary>
        /// 客服答应的截止日期
        /// </summary>
        public DateTime? ProjectServiceEndTime { get; set; }


        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime? ProjectStartTime { get; set; }
        /// <summary>
        /// 做完时间
        /// </summary>
        public DateTime? ProjectEndTime { get; set; }
        /// <summary>
        /// 项目群
        /// </summary>
        public string ProjectQQGroup { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 结清间隔
        /// </summary>
        public SettleIntervalType SettleInterval { get; set; }
        /// <summary>
        /// 结清时间
        /// </summary>
        public DateTime? SettleTime { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string ChargePersonId { get; set; }

        /// <summary>
        /// 约定金额
        /// </summary>
        public decimal ProjectAgreementWorth { get; set; }

        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal ProjectWorth { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        public ProjectType ProjectType { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        public ProjectStatus ProjectStatus { get; set; }

        /// <summary>
        /// 存储地址
        /// </summary>
        public string ProjectPath { get; set; }

        /// <summary>
        /// 客户旺旺
        /// </summary>
        public string FromCustomWangWang { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 交易单号(支付宝返款单号)
        /// </summary>
        public string RefundNumber { get; set; }

        /// <summary>
        /// 返款金额
        /// </summary>
        public decimal RefundWorth { get; set; }

        /////////////////////////////////////////////
       /// <summary>
       /// 负责人实体导航
       /// </summary>
        public virtual UserEntity ChargePerson { get; set; }

        /// <summary>
        /// 客服导航实体
        /// </summary>
        public virtual UserEntity ServicePerson { get; set; }

    }
}
