using System;
using System.Collections.Generic;

namespace Coop.Models
{
    public class Roomer:UserProfile
    {
        public int? HouseRoomerId { get; set; }
        public House House { get; set; }
        public int Number { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public Roomer() : base("roomer")
        {
            Tasks = new List<Task>();
        }

        public Roomer(RegModel model) : base("roomer",model)
        {
            Tasks = new List<Task>();
        }
    }
}