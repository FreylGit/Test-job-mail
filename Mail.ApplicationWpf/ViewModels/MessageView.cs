using System;
using System.ComponentModel.DataAnnotations;

namespace Mail.ApplicationWpf.ViewModels
{
    public class MessagePost
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [EmailAddress]
        public string EmailAddressee { get; set; }
        [EmailAddress]
        public string EmailSender { get; set; }
        public DateTime DateTime { get; set; }
    }
}
