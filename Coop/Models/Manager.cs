using System;
using System.Collections.Generic;
namespace Coop.Models
{
    public class Manager: UserProfile
    {   
        public DateTime DOB { get; set; }

        public ICollection<Company> Companys { get; set; }

        public Manager ()
        {
            Companys = new List<Company>();
        }
    }
}