using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id)
                .HasName("FK_Users_Id");

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .HasConstraintName("FK_Users_RoleId_Roles_Id");

        }
    }
}
