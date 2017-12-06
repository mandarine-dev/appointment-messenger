using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reactive.Linq;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Database.Streaming;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.Models;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage
    {
        //private ChildQuery _query;
        //private IObservable<FirebaseEvent<Message>> _observable;
        //private IDisposable _subscription;

        public ChatPage()
        {
            InitializeComponent();

            App.MessagesViewModel.Messages.CollectionChanged += OnMessageSent;
            App.MessagesViewModel.LoadMessages();
        }

        void OnMessageSent(object sender, NotifyCollectionChangedEventArgs e)
        {
            Message target = App.MessagesViewModel.Messages[App.MessagesViewModel.Messages.Count - 1];
            MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
        }

        void OnMessageSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void OnMessageTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }
    }
}