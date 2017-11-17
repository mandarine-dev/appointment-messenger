using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinChatApp
{
    public partial class LoginPage : ContentPage
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        public void LoginCommand(object sender, EventArgs e)
        {

        }
    }
}
