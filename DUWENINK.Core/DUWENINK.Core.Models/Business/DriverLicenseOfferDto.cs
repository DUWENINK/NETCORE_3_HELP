using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Models.Enum;

namespace DUWENINK.Core.Models.Business
{

    /// <summary>
    /// 驾分DTO
    /// </summary>
   public class DriverLicenseOfferDto

    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

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
        public SexType Sex { get; set; }
        /// <summary>
        /// 菜单类型名称
        /// </summary>
        public string TypeName => Sex.GetDescriptionForEnum();

        /// <summary>
        /// 总价值
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

        /// <summary>
        /// 驾龄
        /// </summary>
        public int DriveYear => DateTime.Now.Year - AcquisitionTime.Year + 1;
    }


    public class Ranking
    {
        //你的分数为xx分,在驾照取得地,可值xx元,超越了xx%本地用户,超越xx全国用户,在居住地,可值xx元,超越了xx%本地用户,超越xx全国用户
        /// <summary>
        /// 在驾照取得地
        /// </summary>
        public decimal SourceTotalPrice { get; set; }
        /// <summary>
        /// 这笔钱超越多少本地用户
        /// </summary>
        public float SourceBeyond { get; set; }
        /// <summary>
        /// 这笔钱在全国的排名
        /// </summary>
        public float SourceBeyondAll { get; set; }
        /// <summary>
        /// 在居住地
        /// </summary>
        public decimal GoalTotalPrice { get; set; }
        /// <summary>
        /// 这笔钱超过多少居住地用户
        /// </summary>
        public float GoalBeyond { get; set; }
        /// <summary>
        /// 这笔钱在全国的排名
        /// </summary>
        public float GoalBeyondAll { get; set; }

        /// <summary>
        /// 收集信息的id
        /// </summary>
        public string DriverLicenseOfferId { get; set; }

    }

    /// <summary>
    /// 微信公众号返回信息
    /// </summary>
    public class WeChatUserInfoDto
    {

        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }

    public class AccessToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class Ticket
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }

    public class WeiChatSigntureDto
    {
        public long Timestamp { get; set; }
        public string NonceStr { get; set; }
        public string Signature { get; set; }
    }


    /// <summary>
    /// 微信接口请求信息
    /// </summary>
    public class WeChatCodeDto
    {
        public string Code
        { get; set; }
    }



}
