using System;
using System.Collections.Generic;

namespace Coop.Models
{
    public class Worker : UserProfile
    {
        public int? HouseWorkerId { get; set; }
        public House House { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
        public Worker(): base("worker")   
        {
                Tasks = new List<Task>();
        }
    }   
}