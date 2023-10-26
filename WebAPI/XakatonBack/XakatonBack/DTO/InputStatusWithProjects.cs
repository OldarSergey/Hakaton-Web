using XakatonBack.Model;

namespace XakatonBack.DTO
{
    public class InputStatusWithProjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PriorityName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
