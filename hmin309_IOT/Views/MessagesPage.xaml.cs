using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using hmin309_IOT.Models;
using hmin309_IOT.Views;
using hmin309_IOT.ViewModels;

namespace hmin309_IOT.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MessagesPage : ContentPage
    {
        MessagesViewModel viewModel;

        public MessagesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MessagesViewModel();
        }

        async void OnMessageSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var message = args.SelectedItem as Message;
            if (message == null)
                return;

            await Navigation.PushAsync(new MessageDetailPage(new MessageDetailViewModel(message)));

            // Manually deselect message.
            MessagesListView.SelectedItem = null;
        }

        async void AddMessage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewMessagePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Messages.Count == 0)
                viewModel.LoadMessagesCommand.Execute(null);
        }
    }
}