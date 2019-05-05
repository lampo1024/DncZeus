/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 角色权限关系表
    /// </summary>
    public class DncRolePermissionMapping
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string RoleCode { get; set; }
        /// <summary>
        /// 权限编码
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string PermissionCode { get; set; }

        /// <summary>
        /// 角色实体
        /// </summary>
        public DncRole DncRole { get; set; }

        /// <summary>
        /// 权限实体
        /// </summary>
        public DncPermission DncPermission { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
