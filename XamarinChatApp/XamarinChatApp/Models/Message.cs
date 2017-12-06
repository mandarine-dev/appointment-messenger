using System;
using Humanizer;
using MvvmHelpers;
using Newtonsoft.Json;

namespace XamarinChatApp.Models
{
    public class Message : ObservableObject
    {
        string _text;
        [JsonProperty("text")]
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        DateTime _sentAt;
        [JsonProperty("sentAt")]
        public DateTime SentAt
        {
            get => _sentAt;
            set => SetProperty(ref _sentAt, value);
        }

        //public string MessageTimeDisplay => SentAt.Humanize();

        private string _sender;
        [JsonProperty("sender")]
        public string Sender
        {
            get => _sender;
            set => SetProperty(ref _sender, value);
        }

        public bool IsIncoming() => App.AuthService.CurrentAuth.User.LocalId == _sender;
    }
}
