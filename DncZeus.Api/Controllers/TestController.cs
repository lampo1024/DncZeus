using DncZeus.Api.Extensions;
using DncZeus.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DncZeus.Api.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ILogger _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 测试日志
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Logger()
        {
            _logger.LogDebug(message: "LogDebug()...");
            _logger.LogInformation(message: "LogInformation()...");
            _logger.LogWarning(message: "LogWarning()...");
            _logger.LogError(message: "LogError()...");
            ResponseResultModel response = ResponseModelFactory.CreateResultInstance;
            response.SetSuccess(message: "test logger success");
            return Ok(value: response);
        }
    }
}
