using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Enum;
using DUWENINK.Core.Models.Filters;
using DUWENINK.Core.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using DUWENINK.Core.Models.System;

namespace DUWENINK.Core.Services.AppServices
{
    /// <summary>
    /// 用户实现类
    /// </summary>
    public class UserService : IUserService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public UserService(DUWENINKContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns>用户id</returns>
        public async Task<string> AddAsync(UserAddDto user)
        {
            var entity = _mapper.Map<UserAddDto, UserEntity>(user);
            entity.Init();
            if (entity.UserRoles.AnyOne())
            {
                entity.UserRoles.ForEach(r => r.UserId = entity.Id);
            }
            entity.Password = entity.Password.ToMd5();
            _context.Users.Add(entity);

            await _context.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="dto">菜单模型</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(UserUpdateDto dto)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == dto.Id);
            if (entity==null)
            {
                return false;
            }
            entity.LoginName = dto.LoginName;
            entity.RealName = dto.RealName;
            entity.Email = dto.Email;
            entity.UserQq = dto.UserQq;
            entity.DepartmentId = dto.DepartmentId;
            if (dto.Password.IsNotBlank())
            {
                entity.Password = dto.Password.ToMd5();
            }
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 根据主键查询模型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<UserDto> FindAsync(string id)
        {
            var entity = await _context.Users.Include(c=>c.Department).FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserEntity, UserDto>(entity);
        }

        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {
            if(await _context.Users.AnyAsync(x => ids.Contains(x.Id) && x.IsSuperMan))
            {
                throw new Exception("超级管理员不能被删除");
            }
            var users = _context.Users.Where(item => ids.Contains(item.Id));
            users.ForEach(item => item.IsDeleted = true);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="dto">登录信息</param>
        /// <returns></returns>
        public async Task<UserLoginDto> LoginAsync(LoginDto dto)
        {
            var reslt = new UserLoginDto();
            var logDbSet = _context.LoginLogs;
            var loginName = dto.LoginName.Trim();
            var entity = await _context.Users.FirstOrDefaultAsync(item => item.LoginName == loginName);
            var loginLog = new LoginLogEntity
            {
                Id = Guid.NewGuid().ToString("N"),
                LoginName = dto.LoginName,
                IP = dto.LoginIP,
                CreateDateTime = DateTime.Now
            };
            if (entity == null)
            {
                reslt.Message = "Account not exists";
                reslt.Result = LoginResult.AccountNotExists;
                loginLog.UserId = string.Empty;
            }
            else
            {
                if (entity.Password == dto.Password.ToMd5())
                {
                    reslt.LoginSuccess = true;
                    reslt.Message = "Login success";
                    reslt.Result = LoginResult.Success;
                    reslt.User = _mapper.Map<UserEntity, UserDto>(entity);
                    reslt.User.UserRoles = await _context.UserRoles.Where(x => x.UserId == entity.Id)
                        .Select(x =>new UserRoleDto{RoleId = x.RoleId ,RoleName=x.Role.Name}).ToListAsync();
                }
                else
                {
                    reslt.Message = "Wrong password";
                    reslt.Result = LoginResult.WrongPassword;
                }
                loginLog.UserId = entity.Id;
            }
            loginLog.Message = reslt.Message;
            logDbSet.Add(loginLog);
            await _context.SaveChangesAsync();
            return reslt;
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public async Task<bool> GiveAsync(string userId, string roleId)
        {
            if (await _context.UserRoles.AnyAsync(item => item.UserId == userId && item.RoleId == roleId))
                return true;
            _context.UserRoles.Add(new UserRoleEntity
            {
                Id = Guid.NewGuid().ToString("N"),
                UserId = userId,
                RoleId = roleId
            });
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 用户角色取消
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public async Task<bool> CancelAsync(string userId, string roleId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(item => item.UserId == userId && item.RoleId == roleId);
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="filters">查询过滤参数</param>
        /// <returns></returns>
        public async Task<PagedResult<UserDto>> SearchAsync(UserFilters filters)
        {
            if (filters == null)
                return new PagedResult<UserDto>(1, 0);

            var query = _context.Users.AsQueryable();

            if (filters.keywords.IsNotBlank())
            {
                query = query.Where(x => x.LoginName.Contains(filters.keywords) || x.RealName.Contains(filters.keywords));
            }

            if (filters.DepartmentIdList != null && filters.DepartmentIdList.Any())
            {
                query = query.Where(x => filters.DepartmentIdList.Contains(x.DepartmentId));
            }

            return await query.OrderByDescending(x => x.CreateDateTime)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    LoginName = x.LoginName,
                    RealName = x.RealName,
                    UserQq=x.UserQq,
                    Email = x.Email,
                    DepartmentName = x.Department.FullName,
                    IsSuperMan = x.IsSuperMan,
                    CreateDateTime = x.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }

        /// <summary>
        /// 是否拥有此权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="url">url地址</param>
        /// <returns></returns>
        public async Task<bool> HasRightAsync(string userId, string url)
        {
            //检查是否是超级管理员,如果是超级管理员,则直接默认拥有所有权限
            if(_context.Users.Any(x=>x.Id == userId&& x.IsSuperMan))
            {
                return true;
            }
            var roleIds = await _context.UserRoles.Where(x => x.UserId == userId)
                .Select(x => x.RoleId).ToListAsync();
            var menuIds = await _context.RoleMenus.Where(x => roleIds.Contains(x.RoleId))
                .Select(x => x.MenuId).ToListAsync();
            return await _context.Menus.AnyAsync(x => menuIds.Contains(x.Id) && url.TrimStart('\\').TrimStart('/').StartsWith(x.Url.TrimStart('\\').TrimStart('/')));
        }

        /// <summary>
        /// 记录访问记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> VisitAsync(VisitDto dto)
        {
            var entity = _mapper.Map<VisitDto, PageViewEntity>(dto);
            entity.Init();
            _context.PageViews.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 检测是否存在用户名
        /// </summary>
        /// <param name="userId">用户ID，可以为空</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public async Task<bool> ExistsLoginNameAsync(string userId, string loginName)
        {
            var query = _context.Users.Where(u => u.LoginName == loginName)
                .WhereIf(userId.IsNotBlank(), u => u.Id != userId);
            return await query.AnyAsync();
        }

        public async Task<bool> ReportServiceUser(UserDto dto)
        {
            //bug
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserQq == dto.UserQq);
            if (userEntity == null)
            {
                
                userEntity = _mapper.Map<UserDto, UserEntity>(dto);
                userEntity.Password = "123456".ToMd5();
                userEntity.Init();
                userEntity.DepartmentId = "a017f0614a7244baaf29abca15c28a94";//客服部门id
                userEntity.Department =await _context.Departments.FirstOrDefaultAsync(c => c.Id == userEntity.DepartmentId);
                userEntity.UserRoles =new List<UserRoleEntity>();
                var roleEntity = new UserRoleEntity { CreateUserId = "e71969cc6fca4c818b80a94185892169"/*超级管理员id*/, UserId = userEntity.Id, RoleId = "cf62aa55cd2043f0a053242cc94c3910" };
                roleEntity.Init();
                userEntity.UserRoles.Add(roleEntity);
                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            return  false;

        }
    }
}
