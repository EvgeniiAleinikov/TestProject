using Coop;
using Coop.Models;
using Coop.Repository;
using System.ComponentModel.DataAnnotations;
using System;

public class RegModel
{
    [Required]
    public string Surname { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string Patronymic { get; set; }
    [Required]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }

    public string Role { get; set; }

    public RegModel()
    { }

    public RegModel(string surname, string firstname, string patronymic, string password, string email,string role)
    {
        Role = role;
        Surname = surname;
        FirstName = firstname;
        Patronymic = patronymic;
        Password = password;
        Email = email;
    }

    public UserProfile toUserProfile(string role)
    {
        return new UserProfile(role,this);
    }

    public void RegUser(string role)
    {
        UserProfileRepository userRepository = new UserProfileRepository(new BaseContext());
        UserProfile user = this.toUserProfile(role);
        userRepository.Create(user);

        switch (role)
        {
            case ("manager"):
                new ManagerRepository(new BaseContext()).Create(new Manager(user));
                break;
            case ("worker"):
                new WorkerRepository(new BaseContext()).Create(new Worker(user));
                break;
            case ("roomer"):
                new RoomerRepository(new BaseContext()).Create(new Roomer(user));
                break;
        }
    }
}