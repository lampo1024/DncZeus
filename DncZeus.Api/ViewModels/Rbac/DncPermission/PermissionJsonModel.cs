/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using DncZeus.Api.Entities.Enums;

namespace DncZeus.Api.ViewModels.Rbac.DncPermission
{
    /// <summary>
    /// 权限实体类
    /// </summary>
    public class PermissionJsonModel
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 菜单GUID
        /// </summary>
        public Guid MenuGuid { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限操作码
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 图标(可选)
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public CommonEnum.Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public CommonEnum.IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 权限类型(0:菜单,1:按钮/操作/功能等)
        /// </summary>
        public CommonEnum.PermissionType Type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public string ModifiedOn { get; set; }
        /// <summary>
        /// 最近修改者ID
        /// </summary>
        public int ModifiedByUserId { get; set; }
        /// <summary>
        /// 最近修改者
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 权限类型的显示文本
        /// </summary>
        public string PermissionTypeText { get; set; }
    }
}
