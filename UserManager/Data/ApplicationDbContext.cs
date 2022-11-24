using Microsoft.EntityFrameworkCore;
using UserManager.Data.Configuration;
using UserManager.Data.Model;

namespace UserManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRuleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AccessRole> AccessRoles { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
    }
}
