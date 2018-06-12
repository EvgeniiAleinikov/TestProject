using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime data { get; set; }
        public ICollection<House> Houses{ get; set; }
        public Company()
        {
            Houses = new List<House>();
        }

        public Manager Manager { get; set; }
    }

}