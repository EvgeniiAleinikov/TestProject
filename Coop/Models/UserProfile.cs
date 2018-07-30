using Coop.Models;
using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UserProfile
{
    public int Id { get; set; }

    public Manager Manager { get; set; }
    public Worker Worker { get; set; }
    public Roomer Roomer { get; set; }

    public string SurName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Password { get; set; }
    public ICollection<Role> Roles { get; set; }
    
    public UserProfile()
    {
        Roles = new List<Role>();
    }

    public UserProfile(string role, RegModel model)
    {
        Roles = new List<Role>();
        SurName = model.Surname;
        FirstName = model.FirstName;
        Patronymic = model.Patronymic;
        Email = model.Email;
        Password = model.Password;
    }

    public void AddPhoneNumber(string number)
    {
        PhoneNumber = number;
    }

    public void AddRole(Role role)
    {
        this.Roles.Add(role);
    }

    public UserProfile UpdateName(NameModel model)
    {
        this.SurName = model.SurName;
        this.FirstName = model.FirstName;
        this.Patronymic = model.Patronymic;
        return this;
    }

    public UserProfile UpdateEmail(string email)
    {
        this.Email = email;
        return this;
    }

    public UserProfile UpdatePassword(string Password)
    {
        this.Password = Password;
        return this;
    }
}