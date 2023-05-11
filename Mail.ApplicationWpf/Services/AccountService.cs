using Mail.ApplicationWpf.Helper;
using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.Views;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Mail.ApplicationWpf.Services
{
    public class AccountService
    {
        public UserDto Login(UserDto loginUser)
        {
            var url = MyConstants.ACCOUNT_LOGIN_URL;
            var json = JsonConvert.SerializeObject(loginUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var userResponse = JsonConvert.DeserializeObject<UserDto>(content);
                // обработайте полученного пользователя
                //_userApplication = userResponse;
                return userResponse;
               // UserEvent?.Invoke(this, new UserDto(userResponse));
               // this.Close();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                // обработайте сообщение об ошибке
                //idL.Content = "Error";
                
            }
            return null;
        }
        public bool Registration(UserDto registrationUser)
        {
            var url = MyConstants.ACCOUNT_REGISTRATION_URL;
            var json = JsonConvert.SerializeObject(registrationUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;
            if (response.IsSuccessStatusCode)
            {

                return true;
            }
            return false;
        }
    }
}
