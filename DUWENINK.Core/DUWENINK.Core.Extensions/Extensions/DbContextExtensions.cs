/*----------------------------------------------------------------
// Copyright © 2019 Chinairap.All rights reserved. 
// CLR版本：	4.0.30319.42000
// 类 名 称：    DbContextExtensions
// 文 件 名：    DbContextExtensions
// 创建者：      DUWENINK
// 创建日期：	2019/9/27 9:43:18
// 版本	日期					修改人	
// v0.1	2019/9/27 9:43:18	DUWENINK
//----------------------------------------------------------------*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Extensions.Extensions
{
    /// <summary>
    /// 命名空间： DUWENINK.Core.Extensions.Extensions
    /// 创建者：   DUWENINK
    /// 创建日期： 2019/9/27 9:43:18
    /// 类名：     DbContextExtensions
    /// </summary>
    public static partial class DbContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int SaveChanges(this DbContext context,Action<IEnumerable<ChangeTracker>> tracks)
        {


            return 0;

        }


    }
}
