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
using XamarinChatApp.Services;

namespace XamarinChatApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;

        private AuthService _authService;
        public ICommand LoginCommand { get; set; }
        
        public LoginViewModel()
        {
            _authService = new AuthService();

            LoginCommand = new Command(async () => await Login(username, password));
        }

        public async Task Login(string username, string password)
        {
            //var notificator = DependencyService.Get<IToastNotificator>();

            try
            {
                await _authService.SignInWithEmailPassword(username, password);
            }
            catch (Exception e)
            {
                //var result = await notificator.Notify(ToastNotificationType.Error, "Erreur", "Impossible de se connecter", new TimeSpan(0,0,0,3));
            }
        }

        #region ascessors
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        #endregion
    }
}
