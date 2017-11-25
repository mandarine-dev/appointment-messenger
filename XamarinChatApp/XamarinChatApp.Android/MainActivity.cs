using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Firebase;
using Firebase.Xamarin.Auth;
using XamarinChatApp.Droid.Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using XamarinChatApp.Firebase.Auth;
using FirebaseAuth = XamarinChatApp.Droid.Firebase.Auth.FirebaseAuth;
using SimpleInjector;

namespace XamarinChatApp.Droid
{
    [Activity(Label = "XamarinChatApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private FirebaseAuth _firebaseAuth = new FirebaseAuth();

        private const string FirebaseUrl = "https://appointment-messenger.firebaseio.com/";

        protected override void OnCreate(Bundle bundle)
        {
            var container = new Container();
            container.Register<IFirebaseAuth, FirebaseAuth>(Lifestyle.Singleton);
            container.Verify();
            
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        //private async void CreateUser()
        //{
        //    //FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAtAWqNNAJKxwZ0zoU0p1Nseh2O5HN1EJE"));

        //    //var auth = await _firebaseAuth.CreateEmailPasswordUser(authProvider, "sofiane@gramadi.fr", "password");



        //    //FirebaseUser user = new FirebaseUser();
        //    //user.DisplayName = "Test 1";
        //    //user.Email = "test@test.fr";
        //    //user.Uid = "fjzojf";

        //    //var firebase = new FirebaseClient(FirebaseUrl);

        //    ////Add item
        //    //var item = await firebase.Child("users").PostAsync<FirebaseUser>(user);
        //}
    }
}

