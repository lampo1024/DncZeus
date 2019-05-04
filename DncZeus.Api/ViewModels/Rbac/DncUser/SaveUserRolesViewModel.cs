/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncZeus.Api.ViewModels.Rbac.DncUser
{
    /// <summary>
    /// 用户获得的角色实体对象
    /// </summary>
    public class SaveUserRolesViewModel
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 已获得的角色代码集合
        /// </summary>
        public List<string> AssignedRoles { get; set; }
    }
}
