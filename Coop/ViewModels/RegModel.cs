using Coop;
using Coop.Models;
using Coop.Repository;
using System.ComponentModel.DataAnnotations;

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

    [Required]
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

    public UserProfile toUserProfile(string role, RegModel regModel)
    {
        return new UserProfile(role,regModel);
    }

    public void RegUser(string role)
    {
        switch (role)
        {
            case ("manager"):
                ManagerRepository managerRepository = new ManagerRepository(new BaseContext());
                managerRepository.Create(new Manager(this));
                break;
            case ("worker"):
                WorkerRepository workerRepository = new WorkerRepository(new BaseContext());
                workerRepository.Create(new Worker(this));
                break;
            case ("roomer"):
                RoomerRepository roomerRepository = new RoomerRepository(new BaseContext());
                roomerRepository.Create(new Roomer(this));
                break;
        }
    }
}