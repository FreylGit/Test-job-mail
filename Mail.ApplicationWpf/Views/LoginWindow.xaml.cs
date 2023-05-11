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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
       
        public event EventHandler<UserDto> UserEvent;
        public LoginWindow()
        {
            InitializeComponent();
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
