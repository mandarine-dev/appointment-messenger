using System.Collections.Specialized;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage
    {
        public ChatPage()
        {
            InitializeComponent();

            App.MessagesViewModel.Messages.CollectionChanged += OnMessageSent;

            App.MessagesViewModel.InitializeMock();
            Debug.WriteLine("Messages count: " + App.MessagesViewModel.Messages.Count);
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