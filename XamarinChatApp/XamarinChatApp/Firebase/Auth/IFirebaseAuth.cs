using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Auth;
using XamarinChatApp.Firebase.Common;

namespace XamarinChatApp.Firebase.Auth
{
    public interface IFirebaseAuth
    {
        CustomUser CurrentUser { get; }

        Task<FirebaseAuthLink> CreateEmailPasswordUser(string email, string password);

        Task<FirebaseAuthLink> SignInWithEmailPassword(string email, string password);
    }
}
