using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinChatApp.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public static MessagesViewModel Instance
        {
            get
            {
                if (Instance != null)
                    return Instance;
                return Instance = new MessagesViewModel();
            }
            private set => Instance = value;
        }

        public ObservableRangeCollection<Message> Messages { get; set; }

        string _OutGoingText = string.Empty;
        public string OutGoingText
        {
            get { return _OutGoingText; }
            set { SetProperty(ref _OutGoingText, value); }
        }

        public ICommand SendCommand { get; set; }

        public MessagesViewModel()
        {
            Messages = new ObservableRangeCollection<Message>();

            SendCommand = new Command(() =>
            {
                Message message = new Message
                {
                    Text = OutGoingText,
                    IsIncoming = false,
                    MessageDateTime = DateTime.Now
                };


                Messages.Add(message);

                // TODO: Here, send message to Database

                OutGoingText = string.Empty;
            });
        }

        public void InitializeMock()
        {
            Messages.Add(new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25) });
            Messages.Add(new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24) });
            Messages.Add(new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23) });
            Messages.Add(new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23) });
            Messages.Add(new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23) });
            Messages.Add(new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23) });
        }

    }
}
