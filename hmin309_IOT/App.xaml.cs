using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hmin309_IOT.Services;
using hmin309_IOT.Views;

namespace hmin309_IOT
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
