using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DUWENINK.Core.Models.Enum
{
    /// <summary>
    /// 性别类型
    /// </summary>
    public enum SexType : byte
    {
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female = 0,
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male = 1
    }
}
