using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Web.Filters;
using DUWENINK.Core.Web.Models;
using DUWENINK.Core.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using DUWENINK.Core.Infrastructure.Attributes;
using DUWENINK.Core.Infrastructure.Menu;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 站内信
    /// </summary>
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageService"></param>
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.MessagePageId, ParentId = Menu.SystemId, Name = "站内信管理", Order = "8")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 发送站内信
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.MessageAddId, ParentId = Menu.MessagePageId, Name = "发送站内信", Order = "1")]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 发送站内信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(MessageDto message)
        {
            await _messageService.SendAsync(message);
            return RedirectToAction("Add");
        }

        /// <summary>
        /// 站内信详情
        /// </summary>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> Detail(string id)
        {
            var message = await _messageService.GetDetailsAsync(id);
            return View(message);
        }

        /// <summary>
        /// 阅读站内信
        /// </summary>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> Read(string id)
        {
            var message = await _messageService.GetDetailsAsync(id);
            await _messageService.ReadAsync(id, User.Identity.GetLoginUserId());
            return View(message);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Menu(Id = Menu.MessageDeleteId, ParentId = Menu.MessagePageId, Name = "删除站内信", Order = "3")]
        public async Task<IActionResult> Delete([FromBody]IList<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = await _messageService.DeleteAsync(ids);
            }
            return Json(result);
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithPager(BaseFilter filters)
        {
            var result = await _messageService.SearchAsync(filters);
            return Json(result);
        }
    }
}