using Mail.ApplicationWpf.Services;
using Mail.ApplicationWpf.ViewModels;
using System.Windows;

namespace Mail.ApplicationWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для SendMessageWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window
    {
        private readonly string _emailSender;
        public SendMessageWindow(string emailSender)
        {
            InitializeComponent();
            _emailSender = emailSender;
            TBEmail.Focus();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            var emailAddressee = TBEmail.Text;
            var title = TBTitle.Text;
            var content = TBContent.Text;
            if (emailAddressee == null || title == null || content == null)
            {
                return;
            }
            var message = new ItemMessageViewModel()
            {
                Title = title,
                Content = content,
                EmailAddressee = emailAddressee,
                EmailSender = _emailSender
            };
            MessageService messageService = new MessageService();
            if (messageService.SendMessage(message))
            {
                MessageBox.Show("Письмо отправлено");
                this.Close();
            }
            else
            {
                MessageBox.Show("Письмо не отправлено");
                this.Close();
            }
        }
    }
}
