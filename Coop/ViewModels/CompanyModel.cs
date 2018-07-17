using Coop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class CompanyModel
    {
        [Required]
        public string Name{ get; set; }
        public DateTime Date{ get; set; }
        public ICollection<House> Houses { get; set; }
        public Manager Manager;

        public CompanyModel(Manager manager,int numberCompany)
        {
            Manager = manager;
            Company company = manager.Companys.ElementAt(numberCompany);
            Name = company.Name;
            Date = company.Date;
            Houses = company.Houses;
        }
    }
}