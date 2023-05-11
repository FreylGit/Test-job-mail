using Mail.ApplicationWpf.Helper;
using Mail.ApplicationWpf.Models;
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

            var url = MyConstants.ACCOUNT_REGISTRATION_URL;
            var json = JsonConvert.SerializeObject(registrationUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;
            if (response.IsSuccessStatusCode)
            {
                
                MessageBox.Show("Зарегистрированно");
                //UserEvent?.Invoke(this, new UserDto(userResponse));TODO: Переписать в сервис
                this.Close();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                // обработайте сообщение об ошибке
                //idL.Content = "Error";
            }

        }
    }
}
