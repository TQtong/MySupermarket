using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
