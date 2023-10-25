using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_Categories_Id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(450)
              .HasColumnType("nvarchar");

        }
    }
}
