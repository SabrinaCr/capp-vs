﻿using CottonApp.Views.HomePage;
using CottonApp.Views.LoginPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new HomePage();

            // Quando precisa do Login
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
