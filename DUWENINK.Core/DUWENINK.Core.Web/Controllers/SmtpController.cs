using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class SmtpController : Controller
    {
        private readonly ISmtpService _SmtpService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpService"></param>
        public SmtpController(ISmtpService smtpService)
        {
            _SmtpService = smtpService;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(SmtpDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _SmtpService.AddAsync(dto);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            return View(dto);
        }




        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<IActionResult> SmtpList(SmtpFilters filters)
        {
            var result = await _SmtpService.SearchSmtpsAsync(filters);
            return Json(result);
        }
    }
}