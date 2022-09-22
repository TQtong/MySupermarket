using Microsoft.EntityFrameworkCore;

namespace MySupermarket.API.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<MusicInfo> MusicInfo { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

    }
}
