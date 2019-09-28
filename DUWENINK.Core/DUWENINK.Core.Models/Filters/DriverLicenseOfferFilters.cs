using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Filters
{
    public class DriverLicenseOfferFilters: BaseFilter
    {
        /// <summary>
        /// 最大
        /// </summary>
        public int MaxLeftScore { get;set; }
        /// <summary>
        /// 最小
        /// </summary>
        public int MinLeftScore { get; set; }
    }
}
