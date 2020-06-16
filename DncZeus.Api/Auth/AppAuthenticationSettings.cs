/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

namespace DncZeus.Api.Auth
{
    /// <summary>
    /// JWT授权的配置项
    /// </summary>
    public class AppAuthenticationSettings
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 应用密钥(真实项目中可能区分应用,不同的应用对应惟一的密钥)
        /// </summary>
        public string Secret { get; set; }
    }
}