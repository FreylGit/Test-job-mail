using System.ComponentModel.DataAnnotations;

namespace Mail.WebAPI.Models.Post
{
    public class MessageView
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [EmailAddress]
        public string EmailAddressee { get; set; }
        [EmailAddress]
        public string EmailSender { get; set; }
        
    }
}
