using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            App.SettingsViewModel.Email = App.AuthService.CurrentAuth.User.Email;
            App.SettingsViewModel.Firstname = App.AuthService.CurrentAuth.User.FirstName;
            App.SettingsViewModel.Lastname = App.AuthService.CurrentAuth.User.LastName;
        }
    }
}