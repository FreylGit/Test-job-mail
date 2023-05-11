using Mail.ApplicationWpf.Helper;
using Mail.ApplicationWpf.Models;
using Mail.ApplicationWpf.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mail.ApplicationWpf.Services
{
    public class MessageService
    {
        public IEnumerable<ItemMessageViewModel> GetMessageItems(UserDto user)
        {
            var url = MyConstants.MESSAGE_GET_MESSAGE_BY_ID_URL + user.Id;
            using var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var messagesResponse = JsonConvert.DeserializeObject<IEnumerable<ItemMessageViewModel>>(content);

                // обработайте полученные сообщения
                var listMessages = new List<ItemMessageViewModel>();
                foreach (var message in messagesResponse)
                {
                    listMessages.Add(new ItemMessageViewModel
                    {
                        Title = message.Title,
                        Content = message.Content,
                        DateTime = message.DateTime
                    });
                }
                return listMessages;
            }
            else
            {
                return null;
            }
        }
        public bool SendMessage(ItemMessageViewModel message)
        {
            var url = MyConstants.MESSAGE_POST_URL;
            var json = JsonConvert.SerializeObject(message);
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
