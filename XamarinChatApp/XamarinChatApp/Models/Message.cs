using System;
using Humanizer;
using MvvmHelpers;
using Newtonsoft.Json;
using XamarinChatApp.Firebase.Auth;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

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

        //public string SentAtFormatted => SentAt.Humanize();

        private string _sender;
        [JsonProperty("sender")]
        public string Sender
        {
            get => _sender;
            set => SetProperty(ref _sender, value);
        }

        public bool IsIncoming() => App.AuthService.CurrentAuth.User.LocalId == _sender;

        private CustomUser _senderDetails;
        public CustomUser SenderDetails
        {
            get => _senderDetails;
            set {
                _senderDetails = value;
                _avatar = _senderDetails.ConvertImageByteToStream();
            }
        }

        private ImageSource _avatar;
        public ImageSource Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }
    }
}
