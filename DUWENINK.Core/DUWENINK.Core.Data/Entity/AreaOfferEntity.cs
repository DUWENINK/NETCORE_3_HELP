using DUWENINK.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
   public class AreaOfferEntity : BaseEntity
    {
        //A1、A2、A3、B1、B2、C1、C2、C3、C4、D、E、F、M、N、P
        /// <summary>
        /// AreaId//县区id
        /// </summary>
        public string AreaId { get; set; }

        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal A1OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal A2OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal A3OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal B1OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal B2OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal C1OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal C2OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal C3OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal C4OfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal DOfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal EOfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal FOfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal MOfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal NOfferPrice { get; set; }
        /// <summary>
        /// 报价单(单价)
        /// </summary>
        public decimal POfferPrice { get; set; }

    }
}
