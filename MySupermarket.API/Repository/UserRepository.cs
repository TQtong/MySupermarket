using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MySupermarket.API.UnitOfWork;

namespace MySupermarket.API.Context
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
