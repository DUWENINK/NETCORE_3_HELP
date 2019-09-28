using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Web.Filters;
using DUWENINK.Core.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DUWENINK.Core.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using System;
using DUWENINK.Core.Infrastructure.Attributes;
using DUWENINK.Core.Infrastructure.Menu;
using DUWENINK.Core.Models.System;
using DUWENINK.Core.Infrastructure;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSvc"></param>
        /// <param name="roleSvc"></param>
        /// <param name="mapper"></param>
        public UserController(IUserService userSvc, IRoleService roleSvc, IMapper mapper)
        {
            _userService = userSvc;
            _roleService = roleSvc;
            _mapper = mapper;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.UserPageId, ParentId = Menu.SystemId, Name = "用户管理", Order = "7")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.UserRoleSetPageId, ParentId = Menu.UserPageId, Name = "用户角色授权", Order = "4")]
        public IActionResult Authen(string id)
        {
            var user = new UserDto
            {
                Id = id
            };
            return View(user);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [Menu(Id = Menu.UserAddId, ParentId = Menu.UserPageId, Name = "添加用户", Order = "1")]
        public IActionResult Add()
        {
            return View(new UserAddDto());
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Menu(Id = Menu.UserEditId, ParentId = Menu.UserPageId, Name = "编辑用户", Order = "2")]
        public async Task<IActionResult> Edit(string id)
        {
            var dto = await _userService.FindAsync(id);
            var model = _mapper.Map<UserDto, UserUpdateDto>(dto);
            return View(model);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddAsync(dto);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateAsync(dto);
                if (result)
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Menu(Id = Menu.UserDeleteId, ParentId = Menu.UserPageId, Name = "删除用户", Order = "3")]
        public async Task<IActionResult> Delete([FromBody]List<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = await _userService.DeleteAsync(ids);
            }
            return Json(result);
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithPager(UserFilters filters)
        {
            var result = await _userService.SearchAsync(filters);
            return Json(result);
        }

        /// <summary>
        /// 我的角色
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> GetMyRoles(RoleFilters filters)
        {
            var result = await _roleService.SearchAsync(filters);
            return Json(result);
        }

        /// <summary>
        /// 我尚未拥有的角色
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> GetNotMyRoles(RoleFilters filters)
        {
            filters.ExcludeMyRoles = true;
            var result = await _roleService.SearchAsync(filters);
            return Json(result);
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpPost]
        [Menu(Id = Menu.UserRoleSetId, ParentId = Menu.UserRoleSetPageId, Name = "用户角色授权", Order = "1")]
        public async Task<IActionResult> GiveRight(string id, string userId)
        {
            var result = new JsonResultModel<bool>
            {
                flag = await _userService.GiveAsync(userId, id)
            };
            return Json(result);
        }

        /// <summary>
        /// 用户角色取消
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [HttpPost]
        [Menu(Id = Menu.UserRoleCancelId, ParentId = Menu.UserRoleSetPageId, Name = "用户角色取消", Order = "2")]
        public async Task<IActionResult> CancelRight(string id, string userId)
        {
            var result = new JsonResultModel<bool>
            {
                flag = await _userService.CancelAsync(userId, id)
            };
            return Json(result);
        }

        /// <summary>
        /// 验证登录名是否重复
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        [HttpGet]
        [IgnoreRightFilter]
        public async Task<IActionResult> VerifyLoginName(string loginName)
        {
            var isExists = await _userService.ExistsLoginNameAsync(null, loginName);
            return isExists ? Json("登录帐号已存在") : Json(data: true);
        }

        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="q">查询关键字</param>
        /// <returns></returns>
        [HttpGet, IgnoreRightFilter]
        public async Task<ActionResult> GetUsers(string q)
        {
            var filter = new UserFilters
            {
                page = 1,
                rows = 1000,
                keywords = q
            };
            var result = await _userService.SearchAsync(filter);
            var users = new
            {
                results = result.rows.Select(x => new { id = x.Id, text = x.LoginName })
            };
            return Json(users);
        }
        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithKeywords(UserFilters filters)
        {
            filters.page = 1;
            filters.rows = 10;
            //客服权限只能搜索开发者
            if (User.Identity.HaveServiceRight())
            {
                filters.DepartmentIdList = new List<string> { "3137bf53a9d140ef90a663113fea5406" };//开发部门id
            }


            var result = await _userService.SearchAsync(filters);
            return Json(new { value = result.rows });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpPost, AllowAnonymous]
        //see https://www.cnblogs.com/CreateMyself/p/6246977.html
        public async Task<NormalResult> ReportServiceUser([FromBody]UserDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.UserQq))
            {
                return new NormalResult { Successful = false, Message = "参数为空" };
            }
            dto.LoginName = dto.UserQq;
            dto.IsSuperMan = false;
            dto.Email = dto.UserQq + "@qq.com";
            dto.RealName = dto.RealName ?? "未命名";
             var  result=await _userService.ReportServiceUser(dto);
            return new NormalResult { Successful = result, Message = "" }; ;

        }


    }
}