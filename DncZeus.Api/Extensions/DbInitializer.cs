/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using DncZeus.Api.Entities;
using System;
using System.Linq;

namespace DncZeus.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// 系统数据初始化
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(DncZeusDbContext context)
        {
            if (context.DncUser.Any())
            {
                return; //数据已经初始化过了
            }

            // 添加一个系统超级管理员
            context.DncUser.Add(new DncUser
            {
                Avatar = "https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png",
                CreatedOn = DateTime.Now,
                CreatedByUserId = 1,
                CreatedByUserName = "系统管理员",
                DisplayName = "系统管理员",
                Guid = new Guid("20263da4-aed4-4aba-a6cc-b985c016858e"),
                LoginName = "administrator",
                ModifiedByUserId = 1,
                ModifiedByUserName = "系统管理员",
                Password = "111111", // 明文密码，生产环境请自行加密处理
                UserType = UserType.SuperAdministator
            });
            context.SaveChanges();
        }
    }
}
