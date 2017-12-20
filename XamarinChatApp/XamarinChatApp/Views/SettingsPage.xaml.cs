using Firebase.Xamarin.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.Firebase.Auth;

namespace XamarinChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            // get current user info from database
            CustomUser user = App.UserService.User;

            if (user != null)
            {
                ImageSource image;

                Stream stream = new MemoryStream(user.ProfilPicture);
                image = ImageSource.FromStream(() => stream);

                App.SettingsViewModel.ProfilPicture = image;
                App.SettingsViewModel.Firstname = user.Firstname != null ? user.Firstname : "";
                App.SettingsViewModel.Lastname = user.Lastname != null ? user.Lastname : "";
            }
            
        }
    }
}