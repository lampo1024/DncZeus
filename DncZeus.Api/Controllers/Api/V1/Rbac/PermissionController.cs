/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using AutoMapper;
using DncZeus.Api.Entities;
using DncZeus.Api.Entities.QueryModels.DncPermission;
using DncZeus.Api.Extensions;
using DncZeus.Api.Extensions.AuthContext;
using DncZeus.Api.Models.Response;
using DncZeus.Api.RequestPayload.Rbac.Permission;
using DncZeus.Api.Utils;
using DncZeus.Api.ViewModels.Rbac.DncMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DncZeus.Api.ViewModels.Rbac.DncPermission;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 权限控制器
    /// </summary>
    [Route("api/v1/rbac/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly DncZeusDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PermissionController(DncZeusDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(PermissionRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.DncPermission.AsQueryable();
                if (!string.IsNullOrEmpty(payload.Kw))
                {
                    query = query.Where(x => x.Name.Contains(payload.Kw.Trim()) || x.Code.Contains(payload.Kw.Trim()));
                }
                if (payload.IsDeleted > IsDeleted.All)
                {
                    query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                }
                if (payload.Status > Status.All)
                {
                    query = query.Where(x => x.Status == payload.Status);
                }
                if (payload.MenuGuid.HasValue)
                {
                    query = query.Where(x => x.MenuGuid == payload.MenuGuid);
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).Include(x => x.Menu).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map<DncPermission, PermissionJsonModel>);
                /*
                 * .Select(x => new PermissionJsonModel {
                    MenuName = x.Menu.Name,
                    x.
                });
                 */

                response.SetData(data, totalCount);
                return Ok(response);
            }
        }

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="model">权限视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(PermissionCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (model.Name.Trim().Length <= 0)
            {
                response.SetFailed("请输入权限名称");
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncPermission.Count(x => x.ActionCode == model.ActionCode) > 0)
                {
                    response.SetFailed("权限操作码已存在");
                    return Ok(response);
                }
                var entity = _mapper.Map<PermissionCreateViewModel, DncPermission>(model);
                entity.CreatedOn = DateTime.Now;
                entity.Code = RandomHelper.GetRandomizer(8, true, false, true, true);
                entity.CreatedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.CreatedByUserName = AuthContextService.CurrentUser.DisplayName;
                _dbContext.DncPermission.Add(entity);
                _dbContext.SaveChanges();

                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        /// <param name="code">权限惟一编码</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(string code)
        {
            using (_dbContext)
            {
                var entity = _dbContext.DncPermission.FirstOrDefault(x => x.Code == code);
                var response = ResponseModelFactory.CreateInstance;
                var model = _mapper.Map<DncPermission, PermissionEditViewModel>(entity);
                var menu = _dbContext.DncMenu.FirstOrDefault(x => x.Guid == entity.MenuGuid);
                model.MenuName = menu.Name;
                response.SetData(model);
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存编辑后的权限信息
        /// </summary>
        /// <param name="model">权限视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(PermissionEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncPermission.Count(x => x.ActionCode == model.ActionCode && x.Code != model.Code) > 0)
                {
                    response.SetFailed("权限操作码已存在");
                    return Ok(response);
                }
                var entity = _dbContext.DncPermission.FirstOrDefault(x => x.Code == model.Code);
                if (entity == null)
                {
                    response.SetFailed("权限不存在");
                    return Ok(response);
                }
                entity.Name = model.Name;
                entity.ActionCode = model.ActionCode;
                entity.MenuGuid = model.MenuGuid;
                entity.IsDeleted = model.IsDeleted;
                entity.ModifiedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.ModifiedByUserName = AuthContextService.CurrentUser.DisplayName;
                entity.ModifiedOn = DateTime.Now;
                entity.Status = model.Status;
                entity.Description = model.Description;
                _dbContext.SaveChanges();
                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="ids">权限ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            response = UpdateIsDelete(IsDeleted.Yes, ids);
            return Ok(response);
        }

        /// <summary>
        /// 恢复权限
        /// </summary>
        /// <param name="ids">权限ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = UpdateIsDelete(IsDeleted.No, ids);
            return Ok(response);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">权限ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            switch (command)
            {
                case "delete":
                    if (ConfigurationManager.AppSettings.IsTrialVersion)
                    {
                        response.SetIsTrial();
                        return Ok(response);
                    }
                    response = UpdateIsDelete(IsDeleted.Yes, ids);
                    break;
                case "recover":
                    response = UpdateIsDelete(IsDeleted.No, ids);
                    break;
                case "forbidden":
                    if (ConfigurationManager.AppSettings.IsTrialVersion)
                    {
                        response.SetIsTrial();
                        return Ok(response);
                    }
                    response = UpdateStatus(UserStatus.Forbidden, ids);
                    break;
                case "normal":
                    response = UpdateStatus(UserStatus.Normal, ids);
                    break;
                default:
                    break;
            }
            return Ok(response);
        }

        /// <summary>
        /// 角色-权限菜单树
        /// </summary>
        /// <param name="code">角色编码</param>
        /// <returns></returns>
        [HttpGet("/api/v1/rbac/permission/permission_tree/{code}")]
        public IActionResult PermissionTree(string code)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var role = _dbContext.DncRole.FirstOrDefault(x => x.Code == code);
                if (role == null)
                {
                    response.SetFailed("角色不存在");
                    return Ok(response);
                }
                var menu = _dbContext.DncMenu.Where(x => x.IsDeleted == IsDeleted.No && x.Status == Status.Normal).OrderBy(x => x.CreatedOn).ThenBy(x => x.Sort)
                    .Select(x => new PermissionMenuTree
                    {
                        Guid = x.Guid,
                        ParentGuid = x.ParentGuid,
                        Title = x.Name
                    }).ToList();
                //DncPermissionWithAssignProperty
                var sql = @"SELECT P.Code,P.MenuGuid,P.Name,P.ActionCode,ISNULL(S.RoleCode,'') AS RoleCode,(CASE WHEN S.PermissionCode IS NOT NULL THEN 1 ELSE 0 END) AS IsAssigned FROM DncPermission AS P 
LEFT JOIN (SELECT * FROM DncRolePermissionMapping AS RPM WHERE RPM.RoleCode={0}) AS S 
ON S.PermissionCode= P.Code
WHERE P.IsDeleted=0 AND P.Status=1";
                if (role.IsSuperAdministrator)
                {
                    sql = @"SELECT P.Code,P.MenuGuid,P.Name,P.ActionCode,'SUPERADM' AS RoleCode,(CASE WHEN P.Code IS NOT NULL THEN 1 ELSE 0 END) AS IsAssigned FROM DncPermission AS P 
WHERE P.IsDeleted=0 AND P.Status=1";
                }
                var permissionList = _dbContext.DncPermissionWithAssignProperty.FromSql(sql, code).ToList();
                var tree = menu.FillRecursive(permissionList, Guid.Empty, role.IsSuperAdministrator);
                response.SetData(new { tree, selectedPermissions = permissionList.Where(x => x.IsAssigned == 1).Select(x => x.Code) });
            }

            return Ok(response);
        }

        #region 私有方法

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">权限ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncPermission SET IsDeleted=@IsDeleted WHERE Code IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="status">权限状态</param>
        /// <param name="ids">权限ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncPermission SET Status=@Status WHERE Code IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@Status", status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }
        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    public static class PermissionTreeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menus">菜单集合</param>
        /// <param name="permissions">权限集合</param>
        /// <param name="parentGuid">父级菜单GUID</param>
        /// <param name="isSuperAdministrator">是否为超级管理员角色</param>
        /// <returns></returns>
        public static List<PermissionMenuTree> FillRecursive(this List<PermissionMenuTree> menus, List<DncPermissionWithAssignProperty> permissions, Guid? parentGuid, bool isSuperAdministrator = false)
        {
            List<PermissionMenuTree> recursiveObjects = new List<PermissionMenuTree>();
            foreach (var item in menus.Where(x => x.ParentGuid == parentGuid))
            {
                var children = new PermissionMenuTree
                {
                    AllAssigned = isSuperAdministrator ? true : (permissions.Where(x => x.MenuGuid == item.Guid).Count(x => x.IsAssigned == 0) == 0),
                    Expand = true,
                    Guid = item.Guid,
                    ParentGuid = item.ParentGuid,
                    Permissions = permissions.Where(x => x.MenuGuid == item.Guid).Select(x => new PermissionElement
                    {
                        Name = x.Name,
                        Code = x.Code,
                        IsAssignedToRole = IsAssigned(x.IsAssigned, isSuperAdministrator)
                    }).ToList(),

                    Title = item.Title,
                    Children = FillRecursive(menus, permissions, item.Guid)
                };
                recursiveObjects.Add(children);
            }
            return recursiveObjects;
        }

        private static bool IsAssigned(int isAssigned, bool isSuperAdministrator)
        {
            if (isSuperAdministrator)
            {
                return true;
            }
            return isAssigned == 1;
        }

        //public static List<PermissionMenuTree> FillRecursive(this List<PermissionMenuTree> menus, List<DncPermissionWithAssignProperty> permissions, Guid? parentGuid)
        //{
        //    List<PermissionMenuTree> recursiveObjects = new List<PermissionMenuTree>();

        //    return recursiveObjects;
        //}
    }
}