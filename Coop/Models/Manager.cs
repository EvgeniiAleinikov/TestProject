using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coop.Models
{
    public class Manager
    {
        [Key]
        [ForeignKey("Company")]
        public int Id { get; set; }
        public Company Company { get; set; }

        public string UserProfile { get; set; }
        public DateTime DOB { get; set; }

    }
}