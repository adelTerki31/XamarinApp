using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using hmin309_IOT.Models;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;

namespace hmin309_IOT.Services
{
    public class MockDataStore : IDataStore<Message>
    {
        readonly List<Message> messages;

        public MockDataStore()
        {
            messages = new List<Message>()
            {
                new Message {id=1, student_id=21915893, student_message="Hello Xamarin 1", gps_lat=36.001, gps_long=3.235 },
                new Message {id=2, student_id=21611143, student_message="Hello Xamarin 2", gps_lat=36.001, gps_long=3.235 }

            };

        }

        /*public async Task<bool> AddMessageAsync(Message message)
        {
            messages.Add(message);

            return await Task.FromResult(true);
        }
        */

        public async Task<bool> AddMessageAsync(Message message){
             
        var client = new HttpClient();
        var json = JsonConvert.SerializeObject(message);
        HttpContent content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await client.PostAsync("https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/", content);
        return await Task.FromResult(true);
        }
        public async Task<bool> UpdateMessageAsync(Message message)
        {
            var oldMessage = messages.Where((Message arg) => arg.id == message.id).FirstOrDefault();
            messages.Remove(oldMessage);
            messages.Add(message);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMessageAsync(long id)
        {
            var oldMessage = messages.Where((Message arg) => arg.id == id).FirstOrDefault();
            messages.Remove(oldMessage);

            return await Task.FromResult(true);
        }

        public async Task<Message> GetMessageAsync(long id)
        {
            return await Task.FromResult(messages.FirstOrDefault(s => s.id == id));
        }

        /*public async Task<IEnumerable<Message>> GetMessagesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(messages);
        }
        */
        //Getting the messages from the server

        public async Task<IEnumerable<Message>> GetMessagesAsync(bool forceRefresh = false)
 
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept","application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            List<Message> messagesArray = JsonConvert.DeserializeObject<List<Message>>(json);
            return messagesArray;
        }
    }
}
 