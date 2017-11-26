using Firebase.Xamarin.Auth;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.Interfaces;
using XamarinChatApp.Services;
using XamarinChatApp.Views;

namespace XamarinChatApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegisterCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login(_username, _password));

            GoToRegisterCommand = new Command(() => { App.NavigationService.PushAsync(new RegisterPage()); });
        }

        public async Task Login(string username, string password)
        {
            try
            {
                var result = await App.AuthService.SignInWithEmailPassword(username, password);
                
                if (result != null)
                {
                    await App.NavigationService.PushAsync(new ChatPage());
                }
            }
            catch (Exception e)
            {
                DependencyService.Get<IAlert>().ShortAlert("Impossible de se connecter");
            }
        }

    }
}
