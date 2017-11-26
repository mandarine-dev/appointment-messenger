using System;
using Xamarin.Forms;
using XamarinChatApp.Services;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp.Views
{
    public partial class LoginPage
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
