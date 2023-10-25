namespace XakatonBack.Model
{
    public class User
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }


        public int RoleId { get; set; }


        public Role Role { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserTask> UserTask { get; set; }
    }
}
