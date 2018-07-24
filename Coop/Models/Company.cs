using Coop.ViewModels;
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
        public DateTime Date { get; set; }
        public string Password { get; set; }
        public ICollection<House> Houses{ get; set; }
        public Company()
        {
            Houses = new List<House>();
        }

        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }

        public Company(NewCompany companyDate)
        {
            Houses = new List<House>();
            Name = companyDate.Name;
            Date = DateTime.Now;
            Password = companyDate.Password;
        }

        public void SetManager(int id)
        {
            ManagerId = id;
        }
    }

}