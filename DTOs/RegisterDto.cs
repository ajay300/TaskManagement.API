using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="Username is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Username must be 3 to 5o Characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Formate")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password is Required")]
        [StringLength(50,MinimumLength =8,ErrorMessage ="PAssword must be 8 to 50 characters") ]
        public string PasswordHash { get; set; } = string.Empty;

    }
}
