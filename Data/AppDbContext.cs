using Microsoft.EntityFrameworkCore;
using skySwapper.Model;

namespace skySwapper.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
