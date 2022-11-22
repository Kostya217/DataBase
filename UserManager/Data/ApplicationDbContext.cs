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
            //new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

            //new AccessRoleEntityTypeConfiguration().Configure(modelBuilder.Entity<AccessRole>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessRoleEntityTypeConfiguration).Assembly);

            //new AccessRuleEntityTypeConfiguration().Configure(modelBuilder.Entity<AccessRule>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessRuleEntityTypeConfiguration).Assembly);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRuleEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AccessRole> AccessRoles { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
    }
}
