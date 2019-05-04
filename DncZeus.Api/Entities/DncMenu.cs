/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-13
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * DESCRIPTION:     菜单实体类
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
    /// 菜单实体类
    /// </summary>
    public class DncMenu
    {
        /// <summary>
        /// GUID
        /// </summary>
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DefaultValue("newid()")]
        public Guid Guid { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required,Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }
        /// <summary>
        /// 页面别名
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Alias { get; set; }
        /// <summary>
        /// 菜单图标(可选)
        /// </summary>
        [Column(TypeName = "nvarchar(128)")]
        public string Icon { get; set; }
        /// <summary>
        /// 父级GUID
        /// </summary>
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// 上级菜单名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 菜单层级深度
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 是否为默认路由
        /// </summary>
        public YesOrNo IsDefaultRouter { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 最近修改者ID
        /// </summary>
        public Guid? ModifiedByUserGuid { get; set; }
        /// <summary>
        /// 最近修改者姓名
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 前端组件(.vue)
        /// </summary>
        [StringLength(255)]
        public string Component { get; set; }

        /// <summary>
        /// 在菜单中隐藏
        /// </summary>
        public YesOrNo? HideInMenu { get; set; }
        /// <summary>
        /// 不缓存页面
        /// </summary>
        public YesOrNo? NotCache { get; set; }
        /// <summary>
        /// 页面关闭前的回调函数
        /// </summary>
        [StringLength(255)]
        public string BeforeCloseFun { get; set; }
        
        /// <summary>
        /// 菜单拥有的权限列表
        /// </summary>
        public ICollection<DncPermission> Permissions { get; set; }
    }
}
