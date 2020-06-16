/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using System.Collections.Generic;

namespace DncZeus.Api.ViewModels.Rbac.DncMenu
{
    /// <summary>
    /// 用于iview的菜单树
    /// </summary>
    public class MenuTree
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuTree()
        {
            Children = new List<MenuTree>();
        }
        /// <summary>
        /// GUID
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// 标题(菜单名称)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否展开子节点
        /// </summary>
        public bool Expand { get; set; }
        /// <summary>
        /// 禁掉响应
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 禁掉 checkbox
        /// </summary>
        public bool DisableCheckbox { get; set; }
        /// <summary>
        /// 是否选中子节点	
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// 是否勾选(如果勾选，子节点也会全部勾选)
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// 子节点属性数组
        /// </summary>
        public List<MenuTree> Children { get; set; }
    }
}
