namespace XakatonBack.Model
{
    public class Task
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

        public int TaskTypeId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int WeightId {  get; set; }
        public int ProjectId {  get; set; } 

        public TaskType TaskType { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Weight Weight { get; set; }
        public Project Project { get; set; }
        public ICollection<UserTask> UserTask { get; set; }
    }
}
