/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using DncZeus.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DncZeus.Api.Controllers.Api.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Count()
        {
            return Ok(1);
        }

        /// <summary>
        /// 初始化消息标题列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            var response = ResponseModelFactory.CreateInstance;
            var unread = new object[] {
                new {title="消息1",create_time=DateTime.Now,msg_id=1}
            };
            response.SetData(new { unread });
            return Ok(response);
        }

        /// <summary>
        /// 获取指定ID的消息内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("{msgid:int}")]
        public IActionResult Content(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
           
            response.SetData($"消息[{msgid}]内容");
            return Ok(response);
        }

        /// <summary>
        /// 将消息标为已读
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/has_read/{msgid}")]
        public IActionResult HasRead(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }

        /// <summary>
        /// 删除已读消息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/remove_readed/{msgid}")]
        public IActionResult RemoveRead(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }

        /// <summary>
        /// 恢复已删消息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/restore/{msgid}")]
        public IActionResult Restore(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }
    }
}