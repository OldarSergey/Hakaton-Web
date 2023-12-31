﻿using System.Text.Json.Serialization;

namespace XakatonBack.Model
{
    public class Status
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }

    }
}
