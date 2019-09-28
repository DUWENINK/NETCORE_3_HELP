using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Enum;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Models.System;
using DUWENINK.Core.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DUWENINK.Core.Web.Controllers
{/// <summary>
/// 
/// </summary>
    public class ProjectController : Controller
    {
        private readonly IProjectService _ProjectService;

        private readonly IConfiguration _Configuration;

        // Configuration.GetSection("CqpApiUrl").Value


        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectService"></param>
        /// <param name="configuration"></param>
        public ProjectController(IProjectService projectService, IConfiguration configuration)
        {
            _ProjectService = projectService;
            _Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        #region 客服视角
        /// <summary>
        /// 客服添加视角 （具有客服角色的用户可以进行添加）
        /// </summary>
        /// <returns></returns>
        public IActionResult ServiceAdd()
        {
            ViewBag.SettleInterval = EnumExtensions.SelectListFor<SettleIntervalType>();
            ViewBag.ProjectType = EnumExtensions.SelectListFor<ProjectType>();

            return View(new ProjectAddDto { FromCustomServiceQQ = User.Identity.GetLoginUserQQ() });
        }

        /// <summary>
        /// 添加（具有客服角色的用户可以进行添加）客服添加项目的时候项目状态默认为开始状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ServiceAdd(ProjectAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _ProjectService.AddAsync(dto, User.Identity.GetLoginUserId(), _Configuration.GetSection("CqpApiUrl").Value);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            ViewBag.SettleInterval = EnumExtensions.SelectListFor(dto.SettleInterval);
            ViewBag.ProjectType = EnumExtensions.SelectListFor(dto.ProjectType);
            return View(dto);
        }
        /// <summary>
        /// 客服对表单进行修改（当项目状态为开始状态的时候，客服可以对项目进行修改，如果项目状态为其他状态，如果需要修改需要联系管理员）
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ServiceEdit(string id)
        {
            var model = await _ProjectService.ServiceEdit(id);
            ViewBag.SettleInterval = EnumExtensions.SelectListFor(model.SettleInterval);
            ViewBag.ProjectType = EnumExtensions.SelectListFor(model.ProjectType);
            return View(model);
        } 
        #endregion
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        public async Task<IActionResult> Delete([FromBody]IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = await _ProjectService.DeleteAsync(ids);
            }
            return Json(result);
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProjectList(ProjectFilters filters)
        {
            #region 客服权限控制,客服只能看到自己发出的
            //var fromCustomServiceQq = string.Empty;
            //if (User.Identity.HaveServiceRight())
            //{
            //    fromCustomServiceQq = User.Identity.GetLoginUserQQ();
            //}
            //filters.FromCustomServiceQQ = fromCustomServiceQq; 
            #endregion

            if (User.Identity.HaveServiceRight())
            {
                filters.CreateUserId = User.Identity.GetLoginUserId();
            }
            if (User.Identity.HaveDeveloperRight())
            {
                filters.ChargePersonId = User.Identity.GetLoginUserId();
            }

            var result = await _ProjectService.SearchProjectsAsync(filters);
            return Json(result);
        }




        /// <summary>
        /// 开发者对表单进行二次修改
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> DeveloperUpdate(string id)
        {
          var model = await _ProjectService.Find(id);
          return View(model);
        }
      
    }
}