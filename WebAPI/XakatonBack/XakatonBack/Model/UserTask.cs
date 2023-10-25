namespace XakatonBack.Model
{
    public class UserTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }

        public int Order { get; set; }

        public User User { get; set; }
        public Task Task { get; set; }
    }
}
