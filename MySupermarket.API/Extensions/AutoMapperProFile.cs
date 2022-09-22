using AutoMapper;
using MySupermarket.API.Context;
using MySupermarket.Core.Dto;

namespace MySupermarket.API.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<MusicInfo, MusicInfoDto>().ReverseMap();
        }
    }
}
