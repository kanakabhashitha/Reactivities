using Domain.obj;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Initialize Activities property
        public DbSet<Activity> Activities { get; set; }
    }
}
