﻿using Firebase.Xamarin.Database.Query;
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
        }

        //public void InitializeMock()
        //{
        //    Messages.Add(new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, SentAt = DateTime.Now.AddMinutes(-25) });
        //    Messages.Add(new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, SentAt = DateTime.Now.AddMinutes(-24) });
        //    Messages.Add(new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, SentAt = DateTime.Now.AddMinutes(-23) });
        //    Messages.Add(new Message { Text = "You will love it. Don't miss.", IsIncoming = true, SentAt = DateTime.Now.AddMinutes(-23) });
        //    Messages.Add(new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, SentAt = DateTime.Now.AddMinutes(-23) });
        //    Messages.Add(new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, SentAt = DateTime.Now.AddMinutes(-23) });
        //}

    }
}
