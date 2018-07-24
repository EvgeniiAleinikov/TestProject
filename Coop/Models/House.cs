using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Models
{
    public class House
    {

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public int NumberOfApartments { get; set; }
        public int Age { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Roomer> Roomers { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public House()
        {
            Roomers = new List<Roomer>();
            Workers = new List<Worker>();
            Tasks = new List<Task>();
        }

        public House(HouseModel model, Company company)
        {
            Roomers = new List<Roomer>();
            Workers = new List<Worker>();
            Tasks = new List<Task>();
            Country = model.Country;
            City = model.City;
            Street = model.Street;
            HouseNumber = model.HouseNumber;
            CompanyId = company.Id;
        }
    }
}