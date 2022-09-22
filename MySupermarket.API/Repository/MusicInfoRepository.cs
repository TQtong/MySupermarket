using Microsoft.EntityFrameworkCore;
using MySupermarket.API.Context;
using MySupermarket.API.UnitOfWork;

namespace MySupermarket.API.Repository
{
    public class MusicInfoRepository : Repository<MusicInfo>, IRepository<MusicInfo>
    {
        public MusicInfoRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
