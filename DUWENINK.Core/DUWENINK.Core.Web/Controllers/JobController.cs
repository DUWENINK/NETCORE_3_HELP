using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobService"></param>
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
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
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<IActionResult> JobList(JobFilters filters)
        {
            var result = await _jobService.SearchJobsAsync(filters);
            return Json(result);
        }
    }
}
