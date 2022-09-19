using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

    }
}
