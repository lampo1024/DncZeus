/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-13
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * DESCRIPTION:     菜单实体类
 ******************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace DncZeus.Api.Entities.QueryModels
{
    /// <summary>
    /// 菜单实体类
    /// </summary>
    public class DncMenuQueryModel
    {
        /// <summary>
        /// GUID
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 页面别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 菜单图标(可选)
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 父级GUID
        /// </summary>
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否为默认路由
        /// </summary>
        public int IsDefaultRouter { get; set; }

        /// <summary>
        /// 前端组件(.vue)
        /// </summary>
        [StringLength(255)]
        public string Component { get; set; }

        /// <summary>
        /// 在菜单中隐藏
        /// </summary>
        public int? HideInMenu { get; set; }
        /// <summary>
        /// 不缓存页面
        /// </summary>
        public int? NotCache { get; set; }
        /// <summary>
        /// 页面关闭前的回调函数
        /// </summary>
        [StringLength(255)]
        public string BeforeCloseFun { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
