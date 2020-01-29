using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using hmin309_IOT.Models;

namespace hmin309_IOT.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewMessagePage : ContentPage
    {
        public Message Message { get; set; }

        public NewMessagePage()
        {
            InitializeComponent();

            Message = new Message
            {
                id = 0,
                student_id = 000000,
                student_message = "",
                gps_long=0.0,
                gps_lat=0.0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddMessage", Message);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}