using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinChatApp.Services;

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
        }

        public void LoginCommand(object sender, EventArgs e)
        {
            _authService.FirebaseAuth.CreateEmailPasswordUser(Username, Password);
        }
    }
}
