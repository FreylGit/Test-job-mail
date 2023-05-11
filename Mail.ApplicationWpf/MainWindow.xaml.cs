using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.Services;
using Mail.ApplicationWpf.ViewModels;
using Mail.ApplicationWpf.Views;
using System.Windows;
using System.Windows.Controls;

namespace Mail.ApplicationWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserDto userApplication;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.UserEvent += LoginWindow_UserEvent;
            loginWindow.Show();

        }
        private void LoginWindow_UserEvent(object sender, UserDto user)
        {
            // выполните действия, которые нужно выполнить при получении данных из LoginWindow
            userApplication = user;
            LEmail.Content = "Почта: " + user.Email;
            SetListMessage();
        }
        private void SetListMessage()
        {

            LBMessage.Items.Clear();
            LBMessage.Focusable = false;
            if (userApplication == null)
            {
                MessageBox.Show("Войдите в почту, чтобы отобразить письма");
                return;
            }
            MessageService messageService = new MessageService();
            var list = messageService.GetMessageItems(userApplication); // получаю от сервера список сообщений

            // LBMessage.ItemsSource = list;
            foreach (var item in list)
            {
                LBMessage.Items.Add(item);
            }
        }

        private void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (userApplication == null)
            {
                MessageBox.Show("Войдите в почту, чтобы отправить письмо");
                return;
            }
            SendMessageWindow sendMessageWindow = new SendMessageWindow(userApplication.Email);
            sendMessageWindow.Show();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void LBMessage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = LBMessage.SelectedItem as ItemMessageViewModel;
            if (selectedItem == null)
            {
                return;
            }
            var messageWindow = new MessageWindow(selectedItem);
            messageWindow.Show();
            BtnSendMessage.Focus();
           
        }

        private void BtnUpdateMessages_Click(object sender, RoutedEventArgs e)
        {
            SetListMessage();
            if (LBMessage.SelectedItems == null)
            {
                return;
            }
        }
    }
}
