/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

namespace DncZeus.Api.Models.Response
{
    /// <summary>
    /// 请求响应实体
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// 请求响应实体类
        /// </summary>
        public ResponseModel()
        {
            Code = 200;
            Message = "操作成功";
        }
        /// <summary>
        /// 响应代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 响应消息内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回的响应数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 设置响应状态为成功
        /// </summary>
        /// <param name="message"></param>
        public void SetSuccess(string message = "成功")
        {
            Code = 200;
            Message = message;
        }
        /// <summary>
        /// 设置响应状态为失败
        /// </summary>
        /// <param name="message"></param>
        public void SetFailed(string message = "失败")
        {
            Message = message;
            Code = 999;
        }

        /// <summary>
        /// 设置响应状态为体验版(返回失败结果)
        /// </summary>
        /// <param name="message"></param>
        public void SetIsTrial(string message = "体验版,功能已被关闭")
        {
            Message = message;
            Code = 999;
        }

        /// <summary>
        /// 设置响应状态为错误
        /// </summary>
        /// <param name="message"></param>
        public void SetError(string message = "错误")
        {
            Code = 500;
            Message = message;
        }

        /// <summary>
        /// 设置响应状态为未知资源
        /// </summary>
        /// <param name="message"></param>
        public void SetNotFound(string message = "未知资源")
        {
            Message = message;
            Code = 404;
        }

        /// <summary>
        /// 设置响应状态为无权限
        /// </summary>
        /// <param name="message"></param>
        public void SetNoPermission(string message = "无权限")
        {
            Message = message;
            Code = 401;
        }

        /// <summary>
        /// 设置响应数据
        /// </summary>
        /// <param name="data"></param>
        public void SetData(object data)
        {
            Data = data;
        }
    }
}
