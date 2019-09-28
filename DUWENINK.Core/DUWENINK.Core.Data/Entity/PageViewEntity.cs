﻿/*******************************************************************************
* Copyright (C) DUWENINK.Com
* 
* Author: DUWENINK
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@DUWENINK.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System;

namespace DUWENINK.Core.Data.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class PageViewEntity : BaseEntity
    {

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 访问者IP
        /// </summary>
        public string IP { get; set; }
    }
}