/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    NormalResultExtension
// 文 件 名：    NormalResultExtension
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 14:55:53
// 版本	日期					修改人	
// v0.1	2019/9/27 14:55:53	DUWENINK
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Infrastructure.Extentions
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Infrastructure.Extentions
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 14:55:53
    /// 类名：     NormalResultExtension
    /// </summary>
    public static class NormalResultExtension
    {
        /// <summary>
        /// 通用返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static NormalResult<T> Response<T>(this T entity)
        {
            return new NormalResult<T> { Data = entity };
        }


    }
}
