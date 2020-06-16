/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using DncZeus.Api.Extensions.AuthContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace DncZeus.Api.Extensions.CustomException
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        // https://tpodolak.com/blog/2017/12/13/asp-net-core-memorycache-getorcreate-calls-factory-method-multiple-times/
        private IMemoryCache _memoryCache;
        /// <summary>
        /// 
        /// </summary>
        public CustomAuthorizeAttribute()
        {
        }

        /// <summary>
        /// 操作的别名
        /// </summary>
        public string ActionAlias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            return;
            // 以下权限拦截器未现实，所以直接return
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                throw new UnauthorizeException();
            }
            OwnedApiPermission entry = new OwnedApiPermission();
            _memoryCache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            _memoryCache.GetOrCreate("CK_PERMISSION_" + AuthContextService.CurrentUser.LoginName, (cache) =>
            {
                //TODO: load real permission list from db
                //entry = new OwnedApiPermission();
                cache.SlidingExpiration = TimeSpan.FromMinutes(30);
                return entry;
            });
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string controllerName = controllerActionDescriptor?.ControllerName;
            string actionName = controllerActionDescriptor?.ActionName;
            if (!string.IsNullOrEmpty(ActionAlias))
            {
                actionName = ActionAlias;
            }
            if (!entry.Can(controllerName, actionName))
            {
                throw new UnauthorizeException();
            }
        }
    }
}
