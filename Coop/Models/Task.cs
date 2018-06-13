using System;

namespace Coop.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int? HouseId { get; set; }
        public House House { get; set; }

        public int? RoomerId { get; set; }
        public Roomer Roomer { get; set; }

        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }

        public string Description { get; set; }
        public DateTime TaskDate { get; set; }
    }
}