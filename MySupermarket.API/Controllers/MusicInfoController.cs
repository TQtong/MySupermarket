using Microsoft.AspNetCore.Mvc;
using MySupermarket.API.Context;
using MySupermarket.API.Service.Music;
using MySupermarket.Common.Parameter;
using MySupermarket.Core.Dto;

namespace MySupermarket.API.Controllers
{
    /// <summary>
    /// 歌曲控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MusicInfoController : Controller
    {
        private readonly IMusicInfoService service;

        public MusicInfoController(IMusicInfoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter param) =>
            await service.GetAllAsync(param);

        [HttpGet]
        public async Task<ApiResponse> GetSingle(string name) =>
            await service.GetFirstOfDefaultAsync(name);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MusicInfoDto param) =>
            await service.AddAsync(param);
    }
}
