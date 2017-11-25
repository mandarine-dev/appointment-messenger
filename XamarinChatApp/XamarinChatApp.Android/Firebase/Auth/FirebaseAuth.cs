using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Xamarin.Auth;
using XamarinChatApp.Firebase.Auth;
using XamarinChatApp.Firebase.Common;

namespace XamarinChatApp.Droid.Firebase.Auth
{
    class FirebaseAuth : IFirebaseAuth
    {
        //private const string FirebaseUrl = "https://appointment-messenger.firebaseio.com/";
        private FirebaseAuthProvider _authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAtAWqNNAJKxwZ0zoU0p1Nseh2O5HN1EJE"));

        public FirebaseAuth() { }

        public static FirebaseAuth Instance { get; } = new FirebaseAuth();

        public IFirebaseUser CurrentUser { get; }

        public async Task<FirebaseAuthLink> CreateEmailPasswordUser(string email, string password)
        {
            return await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
        }

        public async Task<FirebaseAuthLink> SignInWithEmailPassword(string email, string password)
        {
            return await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
        }
    }
}