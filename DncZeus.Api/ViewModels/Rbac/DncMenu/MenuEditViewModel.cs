/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:   码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncMenu
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuEditViewModel
    {
        /// <summary>
        /// 
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
        /// 前端组件(.vue)
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 在菜单中隐藏
        /// </summary>
        public YesOrNo HideInMenu { get; set; }
        /// <summary>
        /// 不缓存页面
        /// </summary>
        public YesOrNo NotCache { get; set; }
        /// <summary>
        /// 页面关闭前的回调函数
        /// </summary>
        public string BeforeCloseFun { get; set; }
    }
}
