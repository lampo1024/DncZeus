/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 ******************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class DncUser
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DefaultValue("newid()")]
        public Guid Guid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)",Order =10)]
        public string LoginName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DisplayName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(255)",Order = 100)]
        public string Avatar { get; set; }
        public UserType UserType { get; set; }
        public IsLocked IsLocked { get; set; }
        //[EnumDataType(typeof(UserStatus))]
        public UserStatus Status { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ModifiedByUserId { get; set; }
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 用户描述信息
        /// </summary>
        [Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }
        /// <summary>
        /// 用户的角色集合
        /// </summary>
        public ICollection<DncUserRoleMapping> UserRoles { get; set; }
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdministator = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 一般用户
        /// </summary>
        GeneralUser = 2
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus {
        /// <summary>
        /// 未指定
        /// </summary>
        All =-1,
        /// <summary>
        /// 已禁用
        /// </summary>
        Forbidden=0,
        /// <summary>
        /// 正常
        /// </summary>
        Normal =1
    }
}
