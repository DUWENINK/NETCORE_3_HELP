using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DUWENINK.Core.Models.Enum
{
    /// <summary>
    /// 驾照类型
    /// </summary>
   public enum DriverLicenseType
    {


       // A1、A2、A3、B1、B2、C1、C2、C3、C4、D、E、F、M、N、P
        /// <summary>
        /// A1
        /// </summary>
        [Description("A1")]
        A1 = 1,

        /// <summary>
        /// A2
        /// </summary>
        [Description("A2")]
        A2 = 2,

        /// <summary>
        /// A3
        /// </summary>
        [Description("A3")]
        A3 = 3,

        /// <summary>
        /// B1
        /// </summary>
        [Description("B1")]
        B1 = 4,
        /// <summary>
        /// A3
        /// </summary>
        [Description("B2")]
        B2 = 5,
        /// <summary>
        /// B1
        /// </summary>
        [Description("C1")]
        C1 = 6,
        /// <summary>
        /// A3
        /// </summary>
        [Description("C2")]
        C2 = 7,
        /// <summary>
        /// B1
        /// </summary>
        [Description("C3")]
        C3 = 8,
        /// <summary>
        /// A3
        /// </summary>
        [Description("C4")]
        C4 = 9,
        /// <summary>
        /// B1
        /// </summary>
        [Description("D")]
        D = 10,
        /// <summary>
        /// A3
        /// </summary>
        [Description("E")]
        E = 11,
        /// <summary>
        /// B1
        /// </summary>
        [Description("F")]
        F = 12,
        /// <summary>
        /// A3
        /// </summary>
        [Description("M")]
        M = 13,
        /// <summary>
        /// B1
        /// </summary>
        [Description("N")]
        N = 14,
        /// <summary>
        /// A3
        /// </summary>
        [Description("P")]
        P = 15
    }
}
