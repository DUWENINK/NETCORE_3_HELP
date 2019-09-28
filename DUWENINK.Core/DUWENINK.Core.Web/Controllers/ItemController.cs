using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Models.System;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemService"></param>
        public ItemController(IItemService itemService) 
        {
            _itemService = itemService;
        }
        #region form界面


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Add(string id)
        {
            var parent = await _itemService.FindItemGroupByIdAsync(id);
            var model = new ItemGroupDto
            {
                ParentItemGroupId = id
            };
            if (parent != null)
            {
                model.ParentItemGroupText= parent.ItemGroupText;
            }
            return View(model);
        }

        #endregion


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public async Task<ActionResult> Add(ItemGroupDto model)
        {
            if (ModelState.IsValid)
            {
                var departmentId = await _itemService.AddItemGroup(model);
                if (departmentId.IsNotBlank())
                {
                    return PartialView("CloseLayerPartial");
                }
            }
            return View(model);
        }





        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, IgnoreRightFilter, AllowAnonymous]
        public async Task<ActionResult> GetTrees(TreeFilter model)
        {
          
            var pages = await _itemService.FindByParentIdAsync(model.id);
            return Json(pages);
        }




        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}