﻿using System;
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
        public int? HouseWorkerId { get; set; }
        public House House { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public Worker()
        {
            Tasks = new List<Task>();
        }

        public Worker(RegModel model,UserProfile user)
        {
            Tasks = new List<Task>();
            UserProfile = user;
        }
    }
}