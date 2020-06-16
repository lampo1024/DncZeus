/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;

namespace DncZeus.Api.Entities.QueryModels.DncPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class DncPermissionWithAssignProperty
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限关联的菜单GUID
        /// </summary>
        public Guid? MenuGuid { get; set; }
        /// <summary>
        /// 权限操作码
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 权限是否已分配到当前角色
        /// </summary>
        public int IsAssigned { get; set; }
    }
}
