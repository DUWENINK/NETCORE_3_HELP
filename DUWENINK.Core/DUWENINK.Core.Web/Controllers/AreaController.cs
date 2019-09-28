using System.Collections.Generic;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure.Attributes;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Infrastructure.Menu;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Models.System;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaService"></param>
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.AreaPageId, ParentId = Menu.SystemId, Name = "省市区管理", Order = "2")]
        public ActionResult Index()
        {
            _areaService.UpdatePathCodes();
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id">父页面ID</param>
        /// <returns></returns>
        [Menu(Id = Menu.AreaPageAddId, ParentId = Menu.AreaPageId, Name = "添加省市区", Order = "1")]
        public async Task<ActionResult> Add(string id)
        {
            var parentDepartment = await _areaService.Find(id);
            var model = new AreaDto
            {
                ParentId = id
            };
            if (parentDepartment != null)
            {
                model.ParentName = parentDepartment.Name;
            }
            return View(model);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(AreaDto model)
        {
            if (ModelState.IsValid)
            {
                var id = await _areaService.Add(model);
                if (id.IsNotBlank())
                {
                    return PartialView("CloseLayerPartial");
                }
            }
            return View(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Menu(Id = Menu.AreaPageEditId, ParentId = Menu.AreaPageId, Name = "编辑省市区", Order = "2")]
        public async Task<ActionResult> Edit(string id)
        {
            var model = await _areaService.Find(id);
            return View(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(AreaDto model)
        {
            if (ModelState.IsValid)
            {
                var success = await _areaService.Update(model);
                if (success)
                {
                    return PartialView("CloseLayerPartial");
                }
            }
            return View(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpPost]
        [Menu(Id = Menu.AreaPageDeleteId, ParentId = Menu.AreaPageId, Name = "删除省市区", Order = "3")]
        public async Task<ActionResult> Delete(string id)
        {
            var success = await _areaService.Delete(new List<string> { id });
            return Json(new { flag = success });
        }

        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, IgnoreRightFilter,AllowAnonymous]
        public async Task<ActionResult> GetTrees(TreeFilter model)
        {
            var pages = await _areaService.FindByParentId(model.id);
            return Json(pages);
        }
        /// <summary>
        /// 获取票价值
        /// </summary>
        //[HttpPost, IgnoreRightFilter]
        public async Task<ActionResult> AreaOfferPriceList(AreaOfferFilter model)
        {
            var pages = await _areaService.SearchPAreaOffersAsync(model);
            return Json(pages);
        }



        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<ActionResult> Exists(string Id, string Name)
        {
            var exists = await _areaService.IsExists(Id, Name);
            return Json(!exists);
        }

        /// <summary>
        /// 添加表单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddAreaOffer(string id)
        {
            // throw new NotImplementedException();
            var model = await _areaService.Find(id);
            if (model == null) return RedirectToAction("Index");
            var dto = new AreaOfferDto {AreaId = model.Id, AreaName = model.Name};
            return View(dto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAreaOffer(AreaOfferDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _areaService.AddAsync(dto);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}