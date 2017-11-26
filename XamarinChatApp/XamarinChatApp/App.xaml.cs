using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinChatApp.Services;
using XamarinChatApp.ViewModels;
using XamarinChatApp.Views;

namespace XamarinChatApp
{
    public partial class App
    {
        #region View models

        public static LoginViewModel LoginViewModel { get; private set; }
        public static MessagesViewModel MessagesViewModel { get; private set; }
        public static RegisterViewModel RegisterViewModel { get; private set; }

        #endregion

        #region Pages

        public static Page LoginPage { get; private set; }
        public static Page RegisterPage { get; private set; }
        public static Page ChatPage { get; private set; }

        #endregion

        #region Services inner PCL

        public static readonly AuthService AuthService = new AuthService();
        public static readonly NavigationService NavigationService = new NavigationService();

        #endregion

        public App()
        {
            InitializeComponent();

            // Init View Models
            LoginViewModel = new LoginViewModel();
            MessagesViewModel = new MessagesViewModel();
            RegisterViewModel = new RegisterViewModel();

            // Init Pages
            LoginPage = new NavigationPage(new LoginPage());
            RegisterPage = new NavigationPage(new RegisterPage());
            ChatPage = new NavigationPage(new ChatPage());

            MainPage = LoginPage;

            NavigationService.CurrentPage = LoginPage;
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
