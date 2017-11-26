using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinChatApp.Interfaces;
using XamarinChatApp.Views;

namespace XamarinChatApp.Services
{
    public class NavigationService
    {
        public async Task NavigateToMessage()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ChatPage());
        }

        public Task NavigateToRegister()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToLogin()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
