using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Domain.Models.Auth;

public class Login
{
    [Required(ErrorMessage = "Email is not specified")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is not specified")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}