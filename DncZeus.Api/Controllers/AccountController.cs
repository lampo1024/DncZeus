/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using DncZeus.Api.Entities;
using DncZeus.Api.Extensions;
using DncZeus.Api.Extensions.AuthContext;
using DncZeus.Api.Extensions.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly DncZeusDbContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public AccountController(DncZeusDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Profile()
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var guid = AuthContextService.CurrentUser.Guid;
                var user = _dbContext.DncUser.FirstOrDefaultAsync(x => x.Guid == guid).Result;

                var menus = _dbContext.DncMenu.Where(x => x.IsDeleted == IsDeleted.No && x.Status == Status.Normal).ToList();

                //查询当前登录用户拥有的权限集合(非超级管理员)
                var sqlPermission = @"SELECT P.Code AS PermissionCode,P.ActionCode AS PermissionActionCode,P.Name AS PermissionName,P.Type AS PermissionType,M.Name AS MenuName,M.Guid AS MenuGuid,M.Alias AS MenuAlias,M.IsDefaultRouter FROM DncRolePermissionMapping AS RPM 
LEFT JOIN DncPermission AS P ON P.Code = RPM.PermissionCode
INNER JOIN DncMenu AS M ON M.Guid = P.MenuGuid
WHERE P.IsDeleted=0 AND P.Status=1 AND EXISTS (SELECT 1 FROM DncUserRoleMapping AS URM WHERE URM.UserGuid={0} AND URM.RoleCode=RPM.RoleCode)";
                if (user.UserType == UserType.SuperAdministator)
                {
                    //如果是超级管理员
                    sqlPermission = @"SELECT P.Code AS PermissionCode,P.ActionCode AS PermissionActionCode,P.Name AS PermissionName,P.Type AS PermissionType,M.Name AS MenuName,M.Guid AS MenuGuid,M.Alias AS MenuAlias,M.IsDefaultRouter FROM DncPermission AS P 
INNER JOIN DncMenu AS M ON M.Guid = P.MenuGuid
WHERE P.IsDeleted=0 AND P.Status=1";
                }
                var permissions = _dbContext.DncPermissionWithMenu.FromSql(sqlPermission, user.Guid).ToList();
                var allowPages = new List<string> {  };
                
                if (user.UserType == UserType.SuperAdministator)
                {
                    allowPages.AddRange(menus.Select(x => x.Alias));
                }
                else
                {
                    allowPages.AddRange(menus.Where(x => x.IsDefaultRouter == YesOrNo.Yes).Select(x => x.Alias));
                    foreach (var permission in permissions.Where(x => x.PermissionType == PermissionType.Menu))
                    {
                        allowPages.AddRange(FindParentMenuAlias(menus, permission.MenuGuid));
                    }
                }
                
                //var allowPages = FindParentMenuAlias(menus);
                var pages = allowPages.Distinct().ToList();
                var pagePermissions = permissions.GroupBy(x => x.MenuAlias).ToDictionary(g=>g.Key,g=>g.Select(x=>x.PermissionActionCode));
                response.SetData(new
                {
                    access = new string[] { },
                    avator = user.Avatar,
                    user_guid = user.Guid,
                    user_name = user.DisplayName,
                    user_type = user.UserType,
                    pages, // =new[] { "rbac", "rbac_user_page", "rbac_menu_page", "rbac_role_page", "rbac_permission_page", "rbac_role_permission_page" },
                    permissions = pagePermissions

                });
            }

            return Ok(response);
        }

        private List<string> FindParentMenuAlias(List<DncMenu> menus, Guid? parentGuid)
        {
            var pages = new List<string>();
            var parent = menus.FirstOrDefault(x => x.Guid == parentGuid);
            if (parent != null)
            {
                if (!pages.Contains(parent.Alias))
                {
                    pages.Add(parent.Alias);
                }
                else
                {
                    return pages;
                }
                if (parent.ParentGuid != Guid.Empty)
                {
                    pages.AddRange(FindParentMenuAlias(menus, parent.ParentGuid));
                }
            }

            return pages.Distinct().ToList();
        }
    }
}