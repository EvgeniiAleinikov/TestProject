using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UserProfile
{
    [Key]
    public int Id { get; set; }

    public string SurName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public string Role { get; set; }
    
    public UserProfile(string role)
    {
        Role = role;
    }

    UserProfile()
    { }

    public UserProfile(string role, RegModel model)
    {
        Role =  role ;
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