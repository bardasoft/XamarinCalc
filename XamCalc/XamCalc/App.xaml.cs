using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace XamCalc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XamCalc.MainPage();
        }

        protected override void OnStart()
        {
            MobileCenter.Start("android=18619034-ca31-4a1d-9d1a-8f67a76e4d36;ios=fee95673-3c6f-490f-b9ed-e0300f4f46e9;",typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
