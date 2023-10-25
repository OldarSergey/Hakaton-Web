using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(pr => pr.Id)
                .HasName("PK_Projects_Id");

            builder.Property(pr => pr.Name)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            builder.Property(pr => pr.Description)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            builder.Property(pr => pr.DeadLine)
                .HasColumnType("datetime");

            builder.HasOne(pr => pr.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(pr => pr.CategoryId)
                .HasConstraintName("FK_Projects_CategoryId_Categories_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pr => pr.Status)
                .WithMany(s => s.Projects)
                .HasForeignKey(pr => pr.StatusId)
                .HasConstraintName("FK_Projects_StatusId_Statuses_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pr => pr.Priority)
                .WithMany(p => p.Projects)
                .HasForeignKey(pr => pr.PriorityId)
                .HasConstraintName("FK_Projects_PriorityId_Prioriries_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pr => pr.Chat)
                .WithOne(ch => ch.Project)
                .HasForeignKey<Project>(pr => pr.ChatId)
                .HasConstraintName("FK_Projects_ChatId_Chat_Id")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
