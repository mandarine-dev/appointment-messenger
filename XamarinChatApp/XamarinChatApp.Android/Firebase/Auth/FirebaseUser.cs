using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinChatApp.Firebase.Auth;

namespace XamarinChatApp.Droid.Firebase.Auth
{
    class FirebaseUser : IFirebaseUser
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
    }
}