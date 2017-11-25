﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinChatApp.Firebase.Auth;

namespace XamarinChatApp.Services
{
    public class AuthService
    {
        public IFirebaseAuth FirebaseAuth { get; }

        public AuthService()
        {
            FirebaseAuth = TinyIoC.TinyIoCContainer.Current.Resolve<IFirebaseAuth>();
        }
    }
}
