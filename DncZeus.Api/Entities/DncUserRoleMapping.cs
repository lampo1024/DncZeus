/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 用户-角色映射
    /// </summary>
    public class DncUserRoleMapping
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 用户实体
        /// </summary>
        public DncUser DncUser { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色实体
        /// </summary>
        public DncRole DncRole { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
