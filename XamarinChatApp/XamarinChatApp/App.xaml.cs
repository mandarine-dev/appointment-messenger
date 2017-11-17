using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinChatApp.ChatPage();
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
        static MessagesViewModel VM;
        public static MessagesViewModel MessagesViewModel
        {
            get
            {
                if (VM == null)
                {
                    VM = new MessagesViewModel();
                    VM.InitializeMock();
                }
                return VM;

            }
        }

    }
}
