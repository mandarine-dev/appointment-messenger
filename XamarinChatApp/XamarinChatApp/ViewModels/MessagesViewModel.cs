using Firebase.Xamarin.Database.Query;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinChatApp.Models;
using XamarinChatApp.Views;

namespace XamarinChatApp.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }

        private string _outGoingText = string.Empty;
        public string OutGoingText
        {
            get => _outGoingText;
            set => SetProperty(ref _outGoingText, value);
        }

        public ICommand SendCommand { get; set; }
        public ICommand OpenSettings { get; set; }
        public ICommand ExitApp { get; set; }

        public MessagesViewModel()
        {
            Messages = new ObservableCollection<Message>();

            SendCommand = new Command(() =>
            {
                Message message = new Message
                {
                    Text = OutGoingText,
                    SentAt = DateTime.Now,
                    Sender = App.AuthService.CurrentAuth.User.LocalId
                };

                // Sent the new message to Firebase
                App.MessageService.SendMessage(message);

                // Clear input text
                OutGoingText = string.Empty;
            });

            OpenSettings = new Command(() =>
            {
                App.NavigationService.PushAsync(new SettingsPage());
            });

            ExitApp = new Command(() =>
            {

            });
        }

    }
}
