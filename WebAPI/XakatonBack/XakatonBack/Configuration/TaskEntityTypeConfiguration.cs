using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XakatonBack.Configuration
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Model.Task>
    {

        public void Configure(EntityTypeBuilder<Model.Task> builder)
        {
            builder.HasKey(t => t.Id)
                .HasName("PK_Tasks_Id");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            builder.Property(t => t.DeadLine)
                .HasColumnType("datetime");

            builder.HasOne(t => t.TaskType)
                .WithMany(tt => tt.Tasks)
                .HasForeignKey(t => t.TaskTypeId)
                .HasConstraintName("FK_Tasks_TaskTypeId_TaskType_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Priority)
                .WithMany(tt => tt.Tasks)
                .HasForeignKey(t => t.PriorityId)
                .HasConstraintName("FK_Tasks_PriorityId_Priority_Id")
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(t => t.Status)
            //    .WithMany(tt => tt.Tasks)
            //    .HasForeignKey(t => t.StatusId)
            //    .HasConstraintName("FK_Tasks_StatusId_Status_Id")
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Weight)
                .WithMany(tt => tt.Tasks)
                .HasForeignKey(t => t.WeightId)
                .HasConstraintName("FK_Tasks_WeightId_Weight_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Project)
                .WithMany(tt => tt.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .HasConstraintName("FK_Tasks_ProjectId_Projects_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
