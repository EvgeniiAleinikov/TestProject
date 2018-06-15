using System;
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
    public string Role { get; set; }
    public string Password { get; set; }

    public UserProfile(string role)
    {
        this.Role = role;
    }
}