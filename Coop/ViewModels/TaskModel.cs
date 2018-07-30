using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class TaskModel
    {
        public int RoomerId { get; set; }
        public int HouseId { get; set; }
        public int WorkerId { get; set; }
        [Required]
        public string Description { get; set; }
        
    }
}