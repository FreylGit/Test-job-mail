using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.Services;
using System;
using System.Windows;

namespace Mail.ApplicationWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public event EventHandler<UserDto> UserEvent;
        public RegistrationWindow()
        {
            InitializeComponent();
            TBName.Focus();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var name = TBName.Text;
            var email = TBEmail.Text;
            if (name == null || email == null)
            {
                return;
            }
            var registrationUser = new UserDto
            {
                Name = name,
                Email = email
            };

            AccountService accountService = new AccountService();
            if (accountService.Registration(registrationUser))
            {
                MessageBox.Show("Зарегистрированно");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации");
            }
        }
    }
}
