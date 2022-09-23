using MySupermarket.API.Context;
using MySupermarket.Common.Parameter;
using MySupermarket.Core.Dto;

namespace MySupermarket.API.Service.Music
{
    public interface IMusicInfoService
    {
        Task<ApiResponse> GetAllAsync(QueryParameter parameter);

        Task<ApiResponse> AddAsync(MusicInfoDto dto);

        Task<ApiResponse> GetFirstOfDefaultAsync(string name);
    }
}
