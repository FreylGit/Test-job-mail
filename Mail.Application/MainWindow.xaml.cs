using Mail.Application.Helper;
using Mail.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mail.ApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserDto user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
          var url =  Constants.ACCOUNT_LOGIN_URL;
            var loginUser = new UserDto()
            {
                Name = "DANIIL",
                Email = "DANIIL@example.com"
            };
            var json = JsonSerializer.Serialize(loginUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response =  client.PostAsync(url, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var content =  response.Content.ReadAsStringAsync().Result;
                var user = JsonSerializer.Deserialize<UserDto>(content);
                // обработайте полученного пользователя
                idL.Content = "id:" + user.Id;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage =  response.Content.ReadAsStringAsync();
                // обработайте сообщение об ошибке
                idL.Content = "Error";
            }

        }
    }
}
