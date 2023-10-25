using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class TaskTypeEntityTypeConfiguration : IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {
            builder.HasKey(tt => tt.Id)
                .HasName("PK_TaskTypes_Id");

            builder.Property(tt => tt.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnType("nvarchar");

            builder.Property(tt => tt.Description)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnType("nvarchar");

        }
    }
}
