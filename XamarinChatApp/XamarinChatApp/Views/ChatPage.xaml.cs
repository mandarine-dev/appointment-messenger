using System.Collections.Specialized;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.ViewModels;

namespace XamarinChatApp.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage
    {
        public readonly MessagesViewModel Vm;

        public ChatPage()
        {
            InitializeComponent();
            Vm = new MessagesViewModel();

            Vm.Messages.CollectionChanged += OnMessageSent;

            Vm.InitializeMock();
            Debug.WriteLine("Messages count: " + Vm.Messages.Count);
        }

        void OnMessageSent(object sender, NotifyCollectionChangedEventArgs e)
        {
            Message target = Vm.Messages[Vm.Messages.Count - 1];
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