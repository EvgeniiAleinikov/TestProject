using System;
using System.Collections.Generic;
namespace Coop.Models
{
    public class Manager: UserProfile
    {   
        public ICollection<Company> Companys { get; set; }

        public Manager() : base("manager")
        {
            Companys = new List<Company>();
        }
    }
}