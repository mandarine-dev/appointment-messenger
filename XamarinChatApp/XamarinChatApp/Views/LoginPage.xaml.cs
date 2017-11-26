using System;
using Xamarin.Forms;
using XamarinChatApp.Services;

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
        }

        async void LoginAsync(object sender, EventArgs args) => await _authService.CreateEmailPasswordUser(Username, Password);

        void Entry_UsernameChanged(object sender, TextChangedEventArgs e) => Username = e.NewTextValue;

        void Entry_PasswordChanged(object sender, TextChangedEventArgs e) => Password = e.NewTextValue;
    }
}
