using Firebase.Xamarin.Auth;
using System.Threading.Tasks;

namespace XamarinChatApp.Services
{
    public class AuthService
    {
        public FirebaseAuthLink CurrentAuth { get; set; }

        public async Task<FirebaseAuthLink> CreateEmailPasswordUser(string email, string password)
        {
            return await App.FirebaseService.AuthProviderInstance
                .CreateUserWithEmailAndPasswordAsync(email, password);
        }

        public async Task<FirebaseAuthLink> SignInWithEmailPassword(string email, string password)
        {
            return await App.FirebaseService.AuthProviderInstance
                .SignInWithEmailAndPasswordAsync(email, password);
        }

        public bool IsLoggedIn()
        {
            return CurrentAuth != null;
        }
    }
}
