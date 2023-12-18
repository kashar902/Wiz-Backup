using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
