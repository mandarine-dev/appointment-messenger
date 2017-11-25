using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinChatApp.Firebase.Common
{
    public enum FirebaseAuthError
    {
        None,
        Unknown,
        InvalidUser,
        UserDisabled,
        UserNotFound,
        WrongPassword,
        ExpiredActionCode,
        InvalidActionCode,
        WeakPassword,
        EmailAlreadyInUse,
        OperationNotAllowed,
        AccountExistsWithDifferentCredential,
        AuthDomainConfigRequired,
        CredentialAlreadyInUse,
        OperationNotSupportedInThisEnvironment,
        Timeout,
        RequiresRecentLogin,
        UserCollision,
    }
}
