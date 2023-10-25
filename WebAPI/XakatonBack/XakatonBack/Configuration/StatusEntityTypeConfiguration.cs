using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(st => st.Id)
                .HasName("PK_Statuses_Id");

            builder.Property(st => st.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            builder.Property(st => st.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");
        }
    }
}
