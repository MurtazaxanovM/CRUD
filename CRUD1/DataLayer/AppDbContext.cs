using CRUD1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD1.DataLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            : base(options)
        {

        }
        public DbSet<Cars> cars { get; set; }
    }
}
