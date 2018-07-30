
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class WorkerModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Profession { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public WorkerModel(Worker roomer)
        {
            Country = roomer.House.Country;
            City = roomer.House.City;
            Street = roomer.House.Street;
            HouseNumber = roomer.House.HouseNumber;
            
            Tasks = roomer.Tasks;
        }
    }
}