/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using AutoMapper;
using DncZeus.Api.Entities;
using DncZeus.Api.Entities.Enums;
using DncZeus.Api.Extensions;
using DncZeus.Api.Extensions.AuthContext;
using DncZeus.Api.Extensions.CustomException;
using DncZeus.Api.Models.Response;
using DncZeus.Api.RequestPayload.Rbac.Menu;
using DncZeus.Api.ViewModels.Rbac.DncMenu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace DncZeus.Api.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/rbac/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class MenuController : ControllerBase
    {
        private readonly DncZeusDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public MenuController(DncZeusDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(MenuRequestPayload payload)
        {
            using (_dbContext)
            {
                var query = _dbContext.DncMenu.AsQueryable();
                if (!string.IsNullOrEmpty(payload.Kw))
                {
                    query = query.Where(x => x.Name.Contains(payload.Kw.Trim()) || x.Url.Contains(payload.Kw.Trim()));
                }
                if (payload.IsDeleted > CommonEnum.IsDeleted.All)
                {
                    query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                }
                if (payload.Status > CommonEnum.Status.All)
                {
                    query = query.Where(x => x.Status == payload.Status);
                }
                if (payload.ParentGuid.HasValue)
                {
                    query = query.Where(x => x.ParentGuid == payload.ParentGuid);
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map<DncMenu, MenuJsonModel>);
                var response = ResponseModelFactory.CreateResultInstance;
                response.SetData(data, totalCount);
                return Ok(response);
            }
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="model">菜单视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(MenuCreateViewModel model)
        {
            using (_dbContext)
            {
                var entity = _mapper.Map<MenuCreateViewModel, DncMenu>(model);
                entity.CreatedOn = DateTime.Now;
                entity.Guid = Guid.NewGuid();
                entity.CreatedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.CreatedByUserName = AuthContextService.CurrentUser.DisplayName;
                entity.IsDeleted = CommonEnum.IsDeleted.No;
                entity.Icon = string.IsNullOrEmpty(entity.Icon) ? "md-menu" : entity.Icon;
                _dbContext.DncMenu.Add(entity);
                _dbContext.SaveChanges();
                var response = ResponseModelFactory.CreateInstance;
                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="guid">菜单ID</param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(Guid guid)
        {
            using (_dbContext)
            {
                var entity = _dbContext.DncMenu.FirstOrDefault(x => x.Guid == guid);
                var response = ResponseModelFactory.CreateInstance;
                var model = _mapper.Map<DncMenu, MenuEditViewModel>(entity);
                //if (model.ParentGuid.HasValue)
                //{
                //    var parent = _dbContext.DncMenu.FirstOrDefault(x => x.Guid == entity.ParentGuid);
                //    if (parent != null)
                //    {
                //        model.ParentName = parent.Name;
                //    }
                //}
                var tree = LoadMenuTree(model.ParentGuid.ToString());
                response.SetData(new { model, tree });
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存编辑后的菜单信息
        /// </summary>
        /// <param name="model">菜单视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(MenuEditViewModel model)
        {
            using (_dbContext)
            {
                var entity = _dbContext.DncMenu.FirstOrDefault(x => x.Guid == model.Guid);
                entity.Name = model.Name;
                entity.Icon = string.IsNullOrEmpty(model.Icon) ? "md-menu" : model.Icon;
                entity.Level = 1;
                entity.ParentGuid = model.ParentGuid;
                entity.Sort = model.Sort;
                entity.Url = model.Url;
                entity.ModifiedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.ModifiedByUserName = AuthContextService.CurrentUser.DisplayName;
                entity.ModifiedOn = DateTime.Now;
                entity.Description = model.Description;
                entity.ParentName = model.ParentName;
                entity.Component = model.Component;
                entity.HideInMenu = model.HideInMenu;
                entity.NotCache = model.NotCache;
                entity.BeforeCloseFun = model.BeforeCloseFun;
                if (!ConfigurationManager.AppSettings.IsTrialVersion)
                {
                    entity.Alias = model.Alias;
                    entity.IsDeleted = model.IsDeleted;
                    entity.Status = model.Status;
                    entity.IsDefaultRouter = model.IsDefaultRouter;
                }
                _dbContext.SaveChanges();
                var response = ResponseModelFactory.CreateInstance;
                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet("{selected?}")]
        public IActionResult Tree(string selected)
        {
            var response = ResponseModelFactory.CreateInstance;
            var tree = LoadMenuTree(selected?.ToString());
            response.SetData(tree);
            return Ok(response);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
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
            response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
            return Ok(response);
        }

        /// <summary>
        /// 恢复菜单
        /// </summary>
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
            return Ok(response);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
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
                    response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
                    break;
                case "recover":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
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
        /// 删除菜单
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">菜单ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(CommonEnum.IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncMenu SET IsDeleted=@IsDeleted WHERE Guid IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="status">菜单状态</param>
        /// <param name="ids">菜单ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncMenu SET Status=@Status WHERE Guid IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@Status", (int)status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        private List<MenuTree> LoadMenuTree(string selectedGuid = null)
        {
            var temp = _dbContext.DncMenu.Where(x => x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal).ToList().Select(x => new MenuTree
            {
                Guid = x.Guid.ToString(),
                ParentGuid = x.ParentGuid,
                Title = x.Name
            }).ToList();
            var root = new MenuTree
            {
                Title = "顶级菜单",
                Guid = Guid.Empty.ToString(),
                ParentGuid = null
            };
            temp.Insert(0, root);
            var tree = temp.BuildTree(selectedGuid);
            return tree;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class MenuTreeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="selectedGuid"></param>
        /// <returns></returns>
        public static List<MenuTree> BuildTree(this List<MenuTree> menus, string selectedGuid = null)
        {
            var lookup = menus.ToLookup(x => x.ParentGuid);
            Func<Guid?, List<MenuTree>> build = null;
            build = pid =>
            {
                return lookup[pid]
                 .Select(x => new MenuTree()
                 {
                     Guid = x.Guid,
                     ParentGuid = x.ParentGuid,
                     Title = x.Title,
                     Expand = (x.ParentGuid == null || x.ParentGuid == Guid.Empty),
                     Selected = selectedGuid == x.Guid,
                     Children = build(new Guid(x.Guid)),
                 })
                 .ToList();
            };
            var result = build(null);
            return result;
        }
    }
}