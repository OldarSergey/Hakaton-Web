namespace XakatonBack.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Message { get; set; }

        public List<User> Users { get; set; }

        public Project Project { get; set; }

    }
}
