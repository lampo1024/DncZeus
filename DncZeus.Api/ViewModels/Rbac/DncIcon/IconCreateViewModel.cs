/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncIcon
{
    /// <summary>
    /// 图标的视图类(创建/编辑)
    /// </summary>
    public class IconCreateViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图标名称
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 图标的大小，单位是 px
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 图标颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 自定义图标
        /// </summary>
        public string Custom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
    }
}
