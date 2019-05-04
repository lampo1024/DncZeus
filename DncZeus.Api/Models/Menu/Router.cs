/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncZeus.Api.Models.Menu
{
    /// <summary>
    /// 用于前端的路由对象
    /// </summary>
    public class Router
    {
        public Router()
        {
            Meta = new RouterMeta();
            Children = new List<Router>();
        }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Component { get; set; }
        public RouterMeta Meta { get; set; }
        public List<Router> Children { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RouterMeta
    {
        public string Title { get; set; }
        public bool hideInMenu { get; set; }
        public bool NotCache { get; set; }
    }
}
