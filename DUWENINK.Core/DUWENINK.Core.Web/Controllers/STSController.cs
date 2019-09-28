using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class STSController : Controller
    {
        private readonly ISTSService _STSService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTSService"></param>
        public STSController(ISTSService sTSService)
        {
            _STSService = sTSService;
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
        /// 登录日志
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<IActionResult> STSList(STSFilters filters)
        {
            if (User.Identity.HaveServiceRight())
            {
                filters.FromQQ = User.Identity.GetLoginUserQQ();
                
            }
            var result = await _STSService.SearchSTSsAsync(filters);
            return Json(result);
        }
    }
}