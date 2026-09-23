using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<ScholEntity> School { get; set; }
    }
}
