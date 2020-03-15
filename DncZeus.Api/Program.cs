/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DncZeus.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        ///// <summary>
        ///// 应用程序启动入口方法(Main)
        ///// </summary>
        ///// <param name="args"></param>
        //public static void Main(string[] args)
        //{
        //    //CreateWebHostBuilder(args).Build().Run();
        //    var host = CreateWebHostBuilder(args).Build();
        //    host.Run();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseKestrel(c => c.AddServerHeader = false)
        //        .UseStartup<Startup>();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel(c => c.AddServerHeader = false)
                .UseStartup<Startup>();
    }
}
