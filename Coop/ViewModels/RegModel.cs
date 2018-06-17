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
}