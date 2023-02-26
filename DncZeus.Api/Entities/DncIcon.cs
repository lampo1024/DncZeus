/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-14
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * DESCRIPTION:     图标实体类
 ******************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 图标实体类
    /// </summary>
    public class DncIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 图标名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 图标的大小，单位是 px
        /// </summary>
        [StringLength(20)]
        public string Size { get; set; }
        /// <summary>
        /// 图标颜色
        /// </summary>
        [StringLength(50)]
        public string Color { get; set; }
        /// <summary>
        /// 自定义图标
        /// </summary>
        [StringLength(60)]
        public string Custom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(800)]
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
        public Guid CreatedByUserGuid { get; set; }
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
        public Guid? ModifiedByUserGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 是否为种子数据
        /// </summary>
        [DefaultValue(0)]
        public YesOrNo IsSeed { get; set; }
    }
}
