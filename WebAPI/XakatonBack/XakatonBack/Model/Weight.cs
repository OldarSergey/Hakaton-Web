namespace XakatonBack.Model
{
    public class Weight
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public decimal ImportanceFactor { get; set; }

        public ICollection<Task> Tasks { get; set; }


    }
}
