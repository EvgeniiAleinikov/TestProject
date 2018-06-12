using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Models
{
    public class House
    {

        public int Id { get; set; }
        public string Address { get; set; }
        public int HouseNumber { get; set; }
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
    }
}