using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using hmin309_IOT.Models;
using hmin309_IOT.Views;

namespace hmin309_IOT.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }
        public Command LoadMessagesCommand { get; set; }

        public MessagesViewModel()
        {
            Title = "Browse";
            Messages = new ObservableCollection<Message>();
            LoadMessagesCommand = new Command(async () => await ExecuteLoadMessagesCommand());

            MessagingCenter.Subscribe<NewMessagePage, Message>(this, "AddMessage", async (obj, message) =>
            {
                var newMessage = message as Message;
                Messages.Add(newMessage);
                await DataStore.AddMessageAsync(newMessage);
            });
        }

        async Task ExecuteLoadMessagesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Messages.Clear();
                var messages = await DataStore.GetMessagesAsync(true);
              
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}