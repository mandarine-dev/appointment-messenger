using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Auth;

namespace XamarinChatApp.Services
{
    public class UserService
    {
        private const string Table = "users";

        public void CreateUserDetails()
        {
            //var firebase = App.FirebaseService.FirebaseClientInstance;
            //firebase.Child(string.Join("/", Table, "KeyTest")).PostAsync(new
            //{
            //    Username = "UsernameTest"
            //}).Wait();

        }

        public void SaveUserData()
        {
            var firebase = App.FirebaseService.FirebaseClientInstance;
            firebase
                .Child("users")
                .Child(App.AuthService.CurrentAuth.User.LocalId)
                .PutAsync(new User
                {
                    FirstName = "Francis",
                    LastName = "JeSaisPas"
                }
            ).Wait();
        }
    }
}
