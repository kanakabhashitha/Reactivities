using Domain;
using Domain.obj;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    // public class DataContext : DbContext
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Initialize Activities property
        public DbSet<Activity> Activities { get; set; }
    }
}
