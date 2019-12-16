using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncZeus.Api.RequestPayload
{
    public class ProductRequsetPayload : RequestPayload
    {
        /// <summary>
        /// 料件号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 原产国
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        public string TexNo { get; set; }
        /// <summary>
        /// 英文品名
        /// </summary>
        public string Name_en { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public string Name_zh { get; set; }
        /// <summary>
        /// 申报要素
        /// </summary>
        public string Element { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
