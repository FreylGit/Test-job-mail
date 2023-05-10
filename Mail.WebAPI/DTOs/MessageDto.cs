using System.ComponentModel.DataAnnotations;

namespace Mail.WebAPI.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Content { get; set; }
        [Required]
        public int AddresseeId { get; set; }
        [Required]
        public int SenderId { get; set; }
    }
}
