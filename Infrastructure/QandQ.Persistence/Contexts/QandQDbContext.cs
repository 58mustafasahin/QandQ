using Microsoft.EntityFrameworkCore;
using QandQ.Domain.Entities;
using System.Reflection;

namespace QandQ.Persistence.Contexts
{
    public class QandQDbContext : DbContext
    {
        public QandQDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<RateAndNoteMovie> RateAndNoteMovies { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
