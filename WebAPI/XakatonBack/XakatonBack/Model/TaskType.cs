namespace XakatonBack.Model
{
    public class TaskType
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
