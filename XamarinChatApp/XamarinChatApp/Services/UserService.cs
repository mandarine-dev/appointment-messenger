using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;

namespace XamarinChatApp.Services
{
    public class UserService
    {
        private const string Table = "users";
        private FirebaseClient firebase = App.FirebaseService.FirebaseClientInstance;


        public void CreateUserDetails()
        {
            //var firebase = App.FirebaseService.FirebaseClientInstance;
            //firebase.Child(string.Join("/", Table, "KeyTest")).PostAsync(new
            //{
            //    Username = "UsernameTest"
            //}).Wait();
        }

        public void GetCurrentUserInfos()
        {
            //User user = new User();
            var userFromFirebase = firebase
                .Child("users")
                .Child(App.AuthService.CurrentAuth.User.LocalId);
            //App.AuthService.CurrentAuth.User.LocalId

            //return user;
        }

        public void SaveUserData(User user)
        {
            firebase
                .Child("users")
                .Child(App.AuthService.CurrentAuth.User.LocalId)
                .PutAsync(new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhotoUrl = "https://assets.entrepreneur.com/content/3x2/1300/20150406145944-dos-donts-taking-perfect-linkedin-profile-picture-selfie-mobile-camera-2.jpeg" // user.PhotoUrl
                }
            ).Wait();
        }
    }
}
