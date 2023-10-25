using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using XakatonBack.Model;

namespace XakatonBack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Weight> Weights { get; set; }
    }
}
