using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.ApplicationWpf.Models
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
        public UserDto()
        {
            
        }
        public UserDto(UserDto user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}
