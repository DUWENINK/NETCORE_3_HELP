using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DUWENINK.Core.Models.Enum
{
    /// <summary>
    /// 项目类型
    /// </summary>
    public enum ProjectType
    {
        /// <summary>
        /// 留学生
        /// </summary>
        [Description("留学生")]
        留学生 = 1,

        /// <summary>
        /// 国内学生
        /// </summary>
        [Description("国内学生")]
        国内学生 = 2,

        /// <summary>
        /// 个人需求
        /// </summary>
        [Description("个人需求")]
        个人需求 = 3
    }

    public enum SettleIntervalType 
    {
        [Description("一天")]
         OneDay=1,
        [Description("二天")]
         TwoDay =2,
        [Description("三天")]
        ThreeDay = 3,
        [Description("四天")]
        FourDDay = 4,
        [Description("五天")]
        FiveDay = 5,
        [Description("六天")]
        SixDay = 6,
        [Description("一周")]
        OneWeek = 7,
        [Description("半个月")]
        HalfMonth = 15

    }


    public enum ProjectStatus
    {
        [Description("开始")]
        OnStart = 1,
        [Description("暂停")]
        OnPause = 2,
        [Description("停止")]
        OnStop = 3,
        [Description("结束")]
        OnEnd = 4,


    }

}
 