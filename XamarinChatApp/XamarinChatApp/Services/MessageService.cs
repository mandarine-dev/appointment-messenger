using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private const string Database = "messages";

        public IDisposable Subscription { get; set; }

        public MessageService() { }

        private ChildQuery PrepareQuery()
        {
            return _firebase
                .Child(Database);
            //.WithAuth(App.AuthService.CurrentAuth.FirebaseToken); // Do not uncomment this till we active the Auth requirement in Firebase
        }

        public IObservable<FirebaseEvent<Message>> SyncInRealtime()
        {
            return PrepareQuery()
                .OrderByKey()
                .AsObservable<Message>();
        }

        public void SendMessage(Message message)
        {
            PrepareQuery().PostAsync(message).Wait();
        }

        public void ReleaseMemory()
        {
            Subscription?.Dispose();
        }
    }
}
