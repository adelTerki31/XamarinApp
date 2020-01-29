using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using hmin309_IOT.Models;
using hmin309_IOT.ViewModels;

namespace hmin309_IOT.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MessageDetailPage : ContentPage
    {
        MessageDetailViewModel viewModel;

        public MessageDetailPage(MessageDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MessageDetailPage()
        {
            InitializeComponent();

            var message = new Message
            {
                id = 0,
                student_id= 21587200,
                student_message ="xamarin tuto",
                gps_lat=3.25,
                gps_long=36.01
            };

            viewModel = new MessageDetailViewModel(message);
            BindingContext = viewModel;
        }
    }
}