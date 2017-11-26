using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.Services;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp
{
    public partial class LoginPage : ContentPage
    {
        AuthService _authService = new AuthService();

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(this.Navigation);
        }

        async void LoginAsync(object sender, EventArgs args) => await _authService.CreateEmailPasswordUser(Username, Password);
    }
}
