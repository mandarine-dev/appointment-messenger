using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinChatApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public MessagesViewModel VM;

        public ChatPage()
        {
            InitializeComponent();
            BindingContext = VM = new MessagesViewModel();

            VM.Messages.CollectionChanged += OnMessageSent;
        }

        void OnMessageSent(object sender, NotifyCollectionChangedEventArgs e)
        {
            Message target = VM.Messages[VM.Messages.Count - 1];
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