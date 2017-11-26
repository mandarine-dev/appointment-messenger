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

namespace XamarinChatApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public static LoginViewModel Instance
        {
            get
            {
                if (Instance != null)
                    return Instance;
                return Instance = new LoginViewModel();
            }
            private set => Instance = value;
        }

        private string username;
        private string password;

        private AuthService _authService;

        public ICommand LoginCommand { get; set; }
        public INavigation _navigation { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(INavigation navigation)
        {
            _authService = new AuthService();
            _navigation = navigation;

            LoginCommand = new Command(async () => await Login(username, password));
        }

        public async Task Login(string username, string password)
        {
            try
            {
                var result = await _authService.SignInWithEmailPassword(username, password);

                if (result != null)
                    await _navigation.PushAsync(new ChatPage());
            }
            catch (Exception e)
            {
                DependencyService.Get<IAlert>().ShortAlert("Impossible de se connecter");
            }
        }

        #region ascessors
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        #endregion
    }
}
