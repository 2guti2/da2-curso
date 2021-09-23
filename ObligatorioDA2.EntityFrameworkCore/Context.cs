using Microsoft.EntityFrameworkCore;
using ObligatorioDA2.Domain;
using ObligatorioDA2.Domain.Roles;

namespace ObligatorioDA2.EntityFrameworkCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(User.PasswordHashExpression);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Forecasts)
                .WithOne(e => e.User);

            modelBuilder.Entity<AdminRole>();
            modelBuilder.Entity<MemberRole>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}