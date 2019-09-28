using System;
using System.Collections.Generic;
using System.Text;
using DUWENINK.Core.Models.Enum;

namespace DUWENINK.Core.Data.Entity
{
   public class DriverLicenseOfferEntity : BaseEntity
    {
        /// <summary>
        /// 地区id 获取驾照的城市(初步位置 精确到省)
        /// </summary>
        public string SourceAreaId { get; set; }
        /// <summary>
        /// 用户的WeiXinOauthId
        /// </summary>
        public string WeiXinId { get; set; }
        /// <summary>
        /// 地区id(常住地) xx省xx市xxx县
        /// </summary>
        public string GoalAreaId { get; set; }
        /// <summary>
        /// 选填 xx地址
        /// </summary>
        public string GoalAddress { get; set; }
        /// <summary>
        /// 驾照 取得时间
        /// </summary>
        public DateTime AcquisitionTime { get; set; }
        /// <summary>
        /// 剩余分值
        /// </summary>
        public int ScoreLeft { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 0是女 1是男
        /// </summary>
        public byte Sex { get; set; }
        /// <summary>
        /// 总价值(驾照城市)
        /// </summary>
        public decimal SourceTotalPrice { get; set; }
        /// <summary>
        /// 总价值(常住地)
        /// </summary>
        public decimal GoalTotalPrice { get; set; }
        /// <summary>
        /// 驾照类型
        /// </summary>
        public string DriverLicenseType { get; set; }



    }
}
