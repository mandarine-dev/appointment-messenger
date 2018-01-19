using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinChatApp.Firebase.Auth
{
    public class CustomUser
    {
        public string DisplayName { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public byte[] ProfilPicture { get; set; }

        public string Email { get; set; }

        public CustomUser() { }

        public ImageSource ConvertImageByteToStream()
        {
            return ImageSource.FromStream(() =>
            {
                return ProfilPicture != null ? new MemoryStream(ProfilPicture) : new MemoryStream();
            });
        }
    }
}
