using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XakatonBack.Model;

namespace XakatonBack.Configuration
{
    public class UserTaskEntityTypeConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasKey(ut => new { ut.UserId, ut.TaskId })
                 .HasName("PK_UserTask_UserId_TaskId");

            builder.Property(ut => ut.Order)
                .IsRequired()
                .HasColumnType("integer");

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.UserTask)
                .HasForeignKey(ut => ut.UserId)
                .HasConstraintName("FK_UserTask_UserId_Users_Id");

            builder.HasOne(ut => ut.Task)
                .WithMany(u => u.UserTask)
                .HasForeignKey(ut => ut.TaskId)
                .HasConstraintName("FK_UserTask_TaskId_Tasks_Id");
        }
    }
}
