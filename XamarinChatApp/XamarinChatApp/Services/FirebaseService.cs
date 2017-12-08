using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;

namespace XamarinChatApp.Services
{
    public class FirebaseService
    {
        public readonly FirebaseAuthProvider AuthProviderInstance = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAtAWqNNAJKxwZ0zoU0p1Nseh2O5HN1EJE"));

        public readonly FirebaseClient FirebaseClientInstance = new FirebaseClient("https://appointment-messenger.firebaseio.com/");
    }
}
