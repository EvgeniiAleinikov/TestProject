using Coop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class HouseModel
    {
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public int ApartmentNumber { get; set; }
        public int Age { get; set; }
        public List<WorkerModel> workers { get; set; }
        public List<RoomerModel> roomers { get; set; }

        public HouseModel(House house)
        {
            Id = house.Id;
            Country = house.Country;
            City = house.City;
            Street = house.Street;
            HouseNumber = house.HouseNumber;
        }

        public HouseModel()
        { }

        public string getAddress()
        {
            return Country +", "
                + City + ", "
                + Street + ", " 
                + HouseNumber + ".";
        }
    }
}