using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Database.Streaming;
using XamarinChatApp.Models;

namespace XamarinChatApp.Services
{
    public class MessageService
    {
        private readonly FirebaseClient _firebase = new FirebaseClient("https://appointment-messenger.firebaseio.com/");

        public MessageService() { }

        public ChildQuery GetQuery()
        {
            var test = _firebase
                .Child("messages/message");
                //.WithAuth(App.AuthService.CurrentAuth.FirebaseToken)
                //.OnceAsync<Message>();
            return test;
        }
    }
}
