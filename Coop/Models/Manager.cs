using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coop.Models
{
    public class Manager
    {
        [Key]
        [ForeignKey("UserProfile")]
        public int Id { get; set; }

        public UserProfile UserProfile { get; set; }

        public ICollection<Company> Companys { get; set; }
        
        public Manager()
        {
            Companys = new List<Company>();
        }

        public Manager(RegModel model)
        {
            Companys = new List<Company>();
        }
    }
}