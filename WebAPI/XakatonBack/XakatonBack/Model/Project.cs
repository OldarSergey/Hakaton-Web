namespace XakatonBack.Model
{
    public class Project
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ChatId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Chat Chat { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
