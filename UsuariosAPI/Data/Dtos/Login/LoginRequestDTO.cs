using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Login
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
