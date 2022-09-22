using MySupermarket.Common.Configurations;
using MySupermarket.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Service
{
    public interface ILoginService
    {
        Task<ApiResponse<UserDto>> LoginAsync(UserDto param);
        Task<ApiResponse> RegisterAsync(UserDto param);
    }
}
