using MySupermarket.Core.Dto;

namespace MySupermarket.API.Context
{
    public interface ILoginService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<ApiResponse> LoginAsync(UserDto user);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApiResponse> RegisterAsync(UserDto user);

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApiResponse> RetrieveAsync(string Account);
    }
}
