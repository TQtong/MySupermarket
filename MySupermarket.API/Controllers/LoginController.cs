using Microsoft.AspNetCore.Mvc;
using MySupermarket.Common.Models;
using WebApplication1.Context;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 账户控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto param) =>
            await service.LoginAsync(param);

        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDto param) =>
            await service.RegisterAsync(param);
    }
}
