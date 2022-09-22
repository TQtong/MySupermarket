using AutoMapper;
using MySupermarket.API.Context;
using MySupermarket.API.UnitOfWork;
using MySupermarket.Common.Parameter;
using MySupermarket.Core.Dto;
using System.Reflection.Metadata;

namespace MySupermarket.API.Service.Music
{
    public class MusicInfoService : IMusicInfoService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public MusicInfoService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(MusicInfoDto dto)
        {
            try
            {
                var music = mapper.Map<MusicInfo>(dto);
                var repository = work.GetRepository<MusicInfo>();
                var musicDb = await repository.GetFirstOrDefaultAsync(predicate: x => x.SongName.Equals(music.SongName));

                if (musicDb != null)
                {
                    return new ApiResponse($"当前歌曲:{musicDb.SongName}已存在！");
                }

                music.CreatedDate = DateTime.Now;
                await repository.InsertAsync(music);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, music);
                }

                return new ApiResponse("添加歌曲,请稍后重试！");

            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var repository = work.GetRepository<MusicInfo>();
                var music = await repository.GetPagedListAsync(predicate:
                    x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.SongName.Equals(parameter.Search),
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreatedDate));

                return new ApiResponse(true, music);

            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
