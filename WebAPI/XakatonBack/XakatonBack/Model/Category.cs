﻿namespace XakatonBack.Model
{
    public class Category
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
