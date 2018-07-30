using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class NameModel
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    }
}