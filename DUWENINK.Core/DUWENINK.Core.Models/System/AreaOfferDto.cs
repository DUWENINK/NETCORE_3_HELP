using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DUWENINK.Core.Models.System
{
   public class AreaOfferDto
    {
        public string Id { get; set; }
        //A1、A2、A3、B1、B2、C1、C2、C3、C4、D、E、F、M、N、P
        /// <summary>
        /// AreaId//县区id
        /// </summary>
        [Display(Name = "地区代码")]
        public string AreaId { get; set; }
        [Display(Name = "地区名称")]
        public string AreaName { get; set; }
        [Display(Name = "A1")]
        public decimal A1OfferPrice { get; set; }
        [Display(Name = "A2")]
        public decimal A2OfferPrice { get; set; }
        [Display(Name = "A3")]
        public decimal A3OfferPrice { get; set; }
        [Display(Name = "B1")]
        public decimal B1OfferPrice { get; set; }
        [Display(Name = "B2")]
        public decimal B2OfferPrice { get; set; }
        [Display(Name = "C1")]
        public decimal C1OfferPrice { get; set; }
        [Display(Name = "C2")]
        public decimal C2OfferPrice { get; set; }
        [Display(Name = "C3")]
        public decimal C3OfferPrice { get; set; }
        [Display(Name = "C4")]
        public decimal C4OfferPrice { get; set; }
        [Display(Name = "D")]
        public decimal DOfferPrice { get; set; }
        [Display(Name = "E")]
        public decimal EOfferPrice { get; set; }
        [Display(Name = "F")]
        public decimal FOfferPrice { get; set; }
        [Display(Name = "M")]
        public decimal MOfferPrice { get; set; }
        [Display(Name = "N")]
        public decimal NOfferPrice { get; set; }
        [Display(Name = "P")]
        public decimal POfferPrice { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateDateTime { get; set; }
    }
   
}
