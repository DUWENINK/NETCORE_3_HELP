using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;

namespace DUWENINK.Core.Interfaces
{
   public interface IDriverLicenseOfferService
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto">模型</param>
        /// <returns></returns>
        Task<string> Add(DriverLicenseOfferDto dto);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Ranking> GetRanking(DriverLicenseOfferDto dto);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Update(DriverLicenseOfferDto dto);
        Task<PagedResult<DriverLicenseOfferDto>> SearchAsync(DriverLicenseOfferFilters filters);
        /// <summary>
        /// 获取微信用户的openid
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<NormalResult<WeChatUserInfoDto>> GetUserInfo(WeChatCodeDto dto);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<string> GetWeChatTicketAsync();
        /// <summary>
        /// 获取微信签名
        /// </summary>
        /// <returns></returns>
        NormalResult<WeiChatSigntureDto> GetWeiChatSignture(string weChatTickets);
       
    }
}
