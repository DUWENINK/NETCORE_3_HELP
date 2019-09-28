/*******************************************************************************
* Copyright (C) AspxPet.Com
* 
* Author: DUWENINK
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@aspxpet.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System;
using System.Reflection;


namespace DUWENINK.Core.Infrastructure.Extentions
{
    /// <summary>
    ///     Guid扩展方法类
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBlank(this Guid? value)
        {
            return value == null || value.Value == Guid.Empty;
        }
    }
}