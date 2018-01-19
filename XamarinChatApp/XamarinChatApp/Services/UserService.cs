using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;
using System.Dynamic;
using XamarinChatApp.Firebase.Auth;

namespace XamarinChatApp.Services
{
    public class UserService
    {
        private const string Table = "users";
        private FirebaseClient firebase = App.FirebaseService.FirebaseClientInstance;

        private CustomUser user;
        public CustomUser User { get => user; set => user = value; }

        public async void LoadCurrentUser()
        {
            user = await firebase
                 .Child("users")
                 .Child(App.AuthService.CurrentAuth.User.LocalId)
                 .OnceSingleAsync<CustomUser>();
        }

        public async Task<CustomUser> LoadUserDetails(string userId)
        {
            return await firebase
                 .Child("users")
                 .Child(userId)
                 .OnceSingleAsync<CustomUser>();
        }

        public void SaveUserData(CustomUser user)
        {
            this.user = user;

            firebase
                .Child("users")
                .Child(App.AuthService.CurrentAuth.User.LocalId)
                .PutAsync(new CustomUser
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    DisplayName = user.DisplayName,
                    ProfilPicture = user.ProfilPicture
                }
            ).Wait();

            LoadCurrentUser();
        }

        //public void UploadProfilePicture(byte[] bytes)
        //{
        //    dynamic picture = new ExpandoObject();

        //    firebase
        //        .Child("users")
        //        .Child(App.AuthService.CurrentAuth.User.LocalId)
        //        .PutAsync(picture.Bytes = bytes);
        //}
    }
}
