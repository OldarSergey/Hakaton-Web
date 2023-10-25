using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id)
                .HasName("PK_Roles_Id");

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

        }
    }
}
