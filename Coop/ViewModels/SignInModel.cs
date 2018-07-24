using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class SignInModel
    {
        public bool IsRoomer { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string HouseId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}