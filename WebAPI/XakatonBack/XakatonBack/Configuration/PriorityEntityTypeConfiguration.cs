using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class PriorityEntityTypeConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.HasKey(p => p.Id)
                .HasName("PK_Priorities_Id");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");


        }
    }
}
