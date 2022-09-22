using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MySupermarket.API.UnitOfWork;
using MySupermarket.Core.Dto;

namespace MySupermarket.API.Context
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public LoginService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> LoginAsync(UserDto user)
        {
            try
            {
                var Password = user.Password.MD5Encryption();

                var userDb = await work.GetRepository<User>().GetFirstOrDefaultAsync(predicate:
                    x => (x.Account.Equals(user.Account)) &&
                    (x.Password.Equals(Password)));

                if (userDb == null)
                {
                    return new ApiResponse("账号或密码错误,请重试！");
                }

                return new ApiResponse(true, userDb);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, "登录失败！");
            }
        }

        public async Task<ApiResponse> RegisterAsync(UserDto param)
        {
            try
            {
                var user = mapper.Map<User>(param);

                var repository = work.GetRepository<User>();
                var userDb = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(user.Account));

                if (userDb != null)
                {
                    return new ApiResponse($"当前账号:{user.Account}已存在,请重新注册！");
                }

                user.CreatedDate = DateTime.Now;
                user.Password = user.Password.MD5Encryption();
                await repository.InsertAsync(user);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, user);
                }

                return new ApiResponse("注册失败,请稍后重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse("注册账号失败！");
            }
        }

        public async Task<ApiResponse> RetrieveAsync(string Account)
        {
            try
            {
                var repository = work.GetRepository<User>();
                var userDb = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(Account));

                if (userDb != null)
                {
                    return new ApiResponse(true, userDb);
                }

                return new ApiResponse("注册失败,请稍后重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse("注册账号失败！");
            }
        }
    }
}
