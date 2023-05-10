using System.ComponentModel.DataAnnotations;

namespace Mail.WebAPI.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Content { get; set; }
        public User Addressee { get; set; }
        public int AddresseeId { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }

    }
}
