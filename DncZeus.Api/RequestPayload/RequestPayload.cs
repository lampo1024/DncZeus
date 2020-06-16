/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System.Collections.Generic;
using System.Linq;

namespace DncZeus.Api.RequestPayload
{
    /// <summary>
    /// 请求实体
    /// </summary>
    public class RequestPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestPayload()
        {
            Sort = new List<Sort>();
            Kw = "";
        }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 排序对象集合(支持多个字段排序)
        /// </summary>
        public List<Sort> Sort { get; set; }
        /// <summary>
        /// 组合后的排序字符串
        /// </summary>
        public string OrderBy
        {
            get
            {
                var orderBy = "";
                var sort = Sort.Where(x => string.IsNullOrEmpty(x.Field) && string.IsNullOrEmpty(x.Direct)).ToList();
                if (sort.Count > 0)
                {
                    orderBy = "ORDER BY " + string.Join(",", sort.Select(x => $"{x.Field} {x.Direct}"));
                }
                return orderBy;
            }
        }

        /// <summary>
        /// 第一个排序字段(单个字段排序)
        /// </summary>
        public Sort FirstSort
        {
            get
            {
                var fs = Sort[0];
                if (fs == null)
                {
                    return null;
                }
                var sort = new Sort
                {
                    Direct = fs.Direct.ToUpper(),
                    Field = fs.Field
                };
                return sort;
            }
        }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Kw { get; set; }
    }

    /// <summary>
    /// 排序实体对象
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// 排序实体对象构造函数
        /// </summary>
        public Sort()
        {
            Direct = "DESC";
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string Direct { get; set; }
    }
}
