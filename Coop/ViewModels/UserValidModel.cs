using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class UserValidModel
    {
        public bool IsRoomer { get; set; }
        public bool IsPasswordValid { get; set; }
        public bool IsApartamentValid { get; set; }
        public bool IsUserValid { get; set; }

        public UserValidModel()
        { }

        public bool IsValid()
        {
            return IsUserValid == IsPasswordValid == IsApartamentValid == true;
        }
    }
}