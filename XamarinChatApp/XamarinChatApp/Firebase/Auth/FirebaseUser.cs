using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinChatApp.Firebase.Auth
{
    public interface IFirebaseUser
    {
        string DisplayName { get; }

        string Email { get; }

        string Uid { get; }
    }
}
