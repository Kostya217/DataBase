using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Data.Model;

namespace UserManager.Data.Configuration
{
    public class AccessRoleEntityTypeConfiguration : IEntityTypeConfiguration<AccessRole>
    {
        public void Configure(EntityTypeBuilder<AccessRole> builder)
        {
            builder.HasKey(a => a.AccessRoleId);

            builder.Property(a => a.AccessRoleId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Role).IsRequired();
        }
    }
}
