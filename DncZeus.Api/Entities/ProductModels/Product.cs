using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DncZeus.Api.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 料件号
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string ItemNo { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }
        /// <summary>
        /// 原产国
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string TexNo { get; set; }
        /// <summary>
        /// 英文品名
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Name_en { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Name_zh { get; set; }
        /// <summary>
        /// 申报要素
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string Element { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }
    }
}
