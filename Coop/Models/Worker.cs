using System;
using System.Collections.Generic;

namespace Coop.Models
{
    public class Worker
    {
        public int? HouseId { get; set; }
        public House House { get; set; }

        public string UserProfile { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public Worker()
        {
            Tasks = new List<Task>();
        }
    }   
}