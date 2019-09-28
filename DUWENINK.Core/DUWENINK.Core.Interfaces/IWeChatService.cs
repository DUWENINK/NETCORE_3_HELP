using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Interfaces
{
   public interface IWeChatService
    {
        /// <summary>
        /// 获取微信tickets
        /// </summary>
        Task<string> GetLastTicket();
    }
}
