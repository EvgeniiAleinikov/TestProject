using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coop.Models
{
    public class Worker
    {
        [Key]
        [ForeignKey("UserProfile")]
        public int Id { get; set; }

        public UserProfile UserProfile { get; set; }

        public string Profession { get; set; }
        
        public int? HouseId { get; set; }
        public House House { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public Worker()
        {
            Tasks = new List<Task>();
        }

        public Worker(UserProfile user)
        {
            Tasks = new List<Task>();
            UserProfile = user;
        }
    }
}