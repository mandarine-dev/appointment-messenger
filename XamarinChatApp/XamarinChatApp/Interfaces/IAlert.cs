﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinChatApp.Interfaces
{
    public interface IAlert
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
