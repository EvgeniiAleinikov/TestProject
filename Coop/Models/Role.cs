using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public Role()
        { }

        public Role(string role)
        {
            Name = role;
        }
    }
}