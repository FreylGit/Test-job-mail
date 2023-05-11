using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.Services;
using System;
using System.Windows;

namespace Mail.ApplicationWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public event EventHandler<UserDto> UserEvent;
        public LoginWindow()
        {
            InitializeComponent();
            TBName.Focus();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var name = TBName.Text;
            var email = TBEmail.Text;
            if (name.Length == 0 || email.Length == 0)
            {
                // TODO: Вывести ошибку
                LStatus.Content = "Вы не ввели имя или Email";
                return;
            }
            UserDto loginUser = new UserDto()
            {
                Name = name,
                Email = email
            };
            AccountService accountService = new AccountService();
            var user = accountService.Login(loginUser);
            if (user != null)
            {
                UserEvent?.Invoke(this, new UserDto(user));
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось войти");
            }


        }

    }
}
