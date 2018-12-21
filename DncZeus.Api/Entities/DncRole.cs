/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-06
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * DESCRIPTION:     角色实体类
 ******************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    public class DncRole
    {
        /// <summary>
        /// 
        /// </summary>
        public DncRole()
        {
            UserRoles = new HashSet<DncUserRoleMapping>();
            Permissions = new HashSet<DncRolePermissionMapping>();
        }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ModifiedByUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 是否是超级管理员(超级管理员拥有系统的所有权限)
        /// </summary>
        public bool IsSuperAdministrator { get; set; }
        /// <summary>
        /// 是否是系统内置角色(系统内置角色不允许删除,修改操作)
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// 角色拥有的用户集合
        /// </summary>
        public ICollection<DncUserRoleMapping> UserRoles { get; set; }
        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public ICollection<DncRolePermissionMapping> Permissions { get; set; }
    }
}
