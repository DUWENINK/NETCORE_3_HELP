using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models
{
    /// <summary>
    /// 空对象
    /// </summary>
   public class EmptyDto
    {
    }
    /// <summary>
    /// 空对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmptyDto<T> : EmptyDto
    {

        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }

}
