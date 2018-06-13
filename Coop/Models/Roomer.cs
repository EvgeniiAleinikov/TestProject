using System;
using System.Collections.Generic;

namespace Coop.Models
{
    public class Roomer:UserProfile
    {
        public int? HouseId { get; set; }
        public House House { get; set; }
        public int Number { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public Roomer()
        {
            Tasks = new List<Task>();
        }
    }
}