using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinChatApp.LoginPage();
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

    public static class ViewModelLocator
    {
        static MessagesViewModel MessageVM;
        static LoginViewModel LoginVM;

        public static MessagesViewModel MessagesViewModel
        {
            get
            {
                if (MessageVM == null)
                {
                    MessageVM = new MessagesViewModel();
                    MessageVM.InitializeMock();
                }
                return MessageVM;

            }
        }

        public static LoginViewModel LoginViewModel
        {
            get
            {
                if (LoginVM == null)
                {
                    LoginVM = new LoginViewModel();
                }
                return LoginVM;
            }
        }
    }
}
