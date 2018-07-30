using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class RoomerModel
    {
        public int RoomerId { get; set; }
        public int HouseId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int RoomNumber { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public RoomerModel(Roomer roomer)
        {
            RoomerId = roomer.Id;
            Country = roomer.House.Country;
            City = roomer.House.City;
            Street = roomer.House.Street;
            HouseNumber = roomer.House.HouseNumber;
            RoomNumber = roomer.Number;
            HouseId = roomer.House.Id;

            Workers = roomer.House.Workers;
            Tasks = roomer.Tasks;
        }
    }
}