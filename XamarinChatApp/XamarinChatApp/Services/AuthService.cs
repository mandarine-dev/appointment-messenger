using Firebase.Xamarin.Auth;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinChatApp.Firebase.Auth;

namespace XamarinChatApp.Services
{
    public class AuthService
    {
        private readonly FirebaseAuthProvider _authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAtAWqNNAJKxwZ0zoU0p1Nseh2O5HN1EJE"));

        //public IFirebaseAuth FirebaseAuth { get; }

        //public IFirebaseUser CurrentUser { get; }
        public FirebaseAuthLink CurrentAuth { get; set; }

        public AuthService() { }

        public async Task<FirebaseAuthLink> CreateEmailPasswordUser(string email, string password) => await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

        public async Task<FirebaseAuthLink> SignInWithEmailPassword(string email, string password) => await _authProvider.SignInWithEmailAndPasswordAsync(email, password);

    }
}
