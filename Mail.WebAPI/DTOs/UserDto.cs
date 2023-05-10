using System.ComponentModel.DataAnnotations;

namespace Mail.WebAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле name")]
        [MaxLength(255, ErrorMessage = "Слишком длинное name")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Обязательное поле email")]
        [MaxLength(255, ErrorMessage = "Слишком длинный email")]
        public string Email { get; set; }
    }
}
