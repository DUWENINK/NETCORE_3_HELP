using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
    public class VaeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public bool state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
    }
    public class CityDesc
    {
        /// <summary>
        /// 
        /// </summary>
        public string provinceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 昆明
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nameEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baiduCode { get; set; }
        /// <summary>
        /// 云南
        /// </summary>
        public string provinceName { get; set; }
    }

    public class ActivityInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 许嵩咪咕歌友会——昆明站
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 【咪咕音乐现场许嵩“1直在1起”昆明站】活动时间：2019.5.17活动地点：昆明市官渡区云南大剧院活动QQ群：497756742购票详情：3.8日11：00  大麦网
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CityDesc cityDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int inCaseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yearMonth { get; set; }
    }

    public class PointInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string configKey { get; set; }
        /// <summary>
        /// 行程首页广告
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showTimeItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pointSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string picUrl { get; set; }
    }

    public class BannerInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pointId { get; set; }
        /// <summary>
        /// 厦门见面会
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string targetUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string targetType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string targetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
    }

    public class BannerList
    {
        /// <summary>
        /// 
        /// </summary>
        public PointInfo pointInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<BannerInfoItem> bannerInfo { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ActivityInfoItem> activityInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BannerList bannerList { get; set; }
    }


    public class VaeNewsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ContentId { get; set; }
    }


}
