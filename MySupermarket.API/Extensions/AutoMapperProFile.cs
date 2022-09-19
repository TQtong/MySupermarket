using AutoMapper;
using MySupermarket.Common.Models;
using WebApplication1.Context;

namespace MySupermarket.API.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
