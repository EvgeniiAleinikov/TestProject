using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coop.Models
{
    public class Roomer
    {
        [Key]
        [ForeignKey("UserProfile")]
        public int Id { get; set; }

        public UserProfile UserProfile { get; set; }

        public int? HouseId { get; set; }
        public House House { get; set; }

        public int Number { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Roomer()
        {
            Tasks = new List<Task>();
        }

        public Roomer(UserProfile user)
        {
            Tasks = new List<Task>();
            UserProfile = user;
        }
    }
}