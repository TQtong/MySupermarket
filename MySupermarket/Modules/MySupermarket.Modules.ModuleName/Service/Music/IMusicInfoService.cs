using MySupermarket.Common.Configurations;
using MySupermarket.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Service.Music
{
    public interface IMusicInfoService : IBaseService<MusicInfoDto>
    {
        Task<ApiResponse<MusicInfoDto>> GetFirstOfDefaultAsync(string songName);
    }
}
