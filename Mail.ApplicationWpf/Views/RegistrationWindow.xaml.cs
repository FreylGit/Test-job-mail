using Mail.ApplicationWpf.Helper;
using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
