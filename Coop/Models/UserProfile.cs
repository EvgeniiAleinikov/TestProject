using Coop.Models;
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
    public ICollection<string> Roles { get; set; }
    
    public UserProfile(string role)
    {
        Roles = new List<string>();
    }

    public UserProfile()
    { }

    public UserProfile(string role, RegModel model)
    {
        Roles = new List<string>();
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
}