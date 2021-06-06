﻿using System;
using covid19stats.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace covid19stats
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DashboardPage());
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
