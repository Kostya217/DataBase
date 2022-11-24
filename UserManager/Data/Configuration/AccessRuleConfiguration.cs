using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Data.Model;

namespace UserManager.Data.Configuration
{
    public class AccessRuleConfiguration : IEntityTypeConfiguration<AccessRule>
    {
        public void Configure(EntityTypeBuilder<AccessRule> builder)
        {
            builder.HasKey(a => a.AccessRuleId);

            builder.Property(a => a.AccessRuleId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Path).IsRequired();
            builder.Property(a => a.Copy).IsRequired();
            builder.Property(a => a.Download).IsRequired();
            builder.Property(a => a.Write).IsRequired();
            builder.Property(a => a.Read).IsRequired();
            builder.Property(a => a.WriteContents).IsRequired();
            builder.Property(a => a.Upload).IsRequired();
            builder.Property(a => a.Copy).IsRequired();
            builder.Property(a => a.IsFile).IsRequired();



            builder
                .HasOne(a => a.AccessRole)
                .WithMany(a => a.Rules)
                .HasForeignKey(u => u.AccessRoleId);
        }
    }
}
