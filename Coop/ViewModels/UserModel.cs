using Coop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Телефона")]
        public string PhoneNumber { get; set; }


        public ICollection<Role> Roles{ get; set; }

        internal void SetRoles(IQueryable<Role> queryable)
        {
            throw new NotImplementedException();
        }

        public string Password { get; set; }

        public UserModel(UserProfile profile)
        {
            SurName = profile.SurName;
            FirstName = profile.FirstName;
            Patronymic = profile.Patronymic;
            Email = profile.Email;
            PhoneNumber = profile.PhoneNumber;
        }

        public void SetRoles(ICollection<Role> roles)
        {
            Roles = roles;
        }
    }
}