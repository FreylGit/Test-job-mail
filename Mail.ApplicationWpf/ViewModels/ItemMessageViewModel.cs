using System;
using System.ComponentModel.DataAnnotations;

namespace Mail.ApplicationWpf.ViewModels
{
    public class ItemMessageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        [EmailAddress]
        public string EmailAddressee { get; set; }
        [EmailAddress]
        public string EmailSender { get; set; }
    }
}
