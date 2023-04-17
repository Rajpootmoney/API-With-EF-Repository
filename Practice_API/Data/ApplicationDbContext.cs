using Microsoft.EntityFrameworkCore;
using Practice_API.Models;

namespace Practice_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}
