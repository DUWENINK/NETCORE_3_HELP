using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Services.AppServices;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class DriverLicenseOfferController : Controller
    {
        private readonly IDriverLicenseOfferService _driverLicenseOfferService;
        private readonly IMemoryCache _memoryCache;
        private readonly IWeChatService _weChatService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverLicenseOfferService"></param>
        /// <param name="memoryCache"></param>
        /// <param name="weChatService"></param>
        public DriverLicenseOfferController(IDriverLicenseOfferService driverLicenseOfferService, IMemoryCache memoryCache, IWeChatService weChatService)
        {
            _driverLicenseOfferService = driverLicenseOfferService;
            _memoryCache = memoryCache;
            _weChatService = weChatService;
        }
        /// <summary>
        /// 上报数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpPost, AllowAnonymous]
        //see https://www.cnblogs.com/CreateMyself/p/6246977.html
        public async Task<NormalResult> ReportServiceUser([FromBody]DriverLicenseOfferDto dto)
        {
           var success= await _driverLicenseOfferService.Update
                (dto);
            var result = new NormalResult {Message = success ? "成功":"失败",Successful = success };
            return result;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpGet, AllowAnonymous, IgnoreRightFilter]
        public async Task<NormalResult<WeChatUserInfoDto>> getUserInfo(WeChatCodeDto dto)
        {
            return await _driverLicenseOfferService.GetUserInfo(dto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpGet, AllowAnonymous]
        //see https://www.cnblogs.com/CreateMyself/p/6246977.html
        public async Task<NormalResult<WeiChatSigntureDto>> signture()
        {
            const string cacheKey = "WxTickets_Key";
            if (!_memoryCache.TryGetValue(cacheKey, out string result))
            {
                result = await _weChatService.GetLastTicket();//直接从接口获取值
                //_memoryCache.Set(cacheKey, result);
                _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60)));//设置缓存一个小时一次
            }
            return  _driverLicenseOfferService.GetWeiChatSignture(result);
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpPost, AllowAnonymous]
        //see https://www.cnblogs.com/CreateMyself/p/6246977.html
        public async Task<NormalResult<Ranking>> GetOffer([FromBody]DriverLicenseOfferDto dto)
        {
            var result = new NormalResult<Ranking> { Data = await _driverLicenseOfferService.GetRanking(dto) };
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        public async Task<IActionResult> GetListWithPager(DriverLicenseOfferFilters filters)
        {
            var result = await _driverLicenseOfferService.SearchAsync(filters);
            return Json(result);
        }
    }
}