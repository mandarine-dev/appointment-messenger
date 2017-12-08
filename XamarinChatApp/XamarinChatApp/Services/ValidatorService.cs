using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XamarinChatApp.Services
{
    public class ValidatorService
    {
        public static bool IsPasswordAndConfirmValid(string pwd, string pwdConfirm)
        {
            return
                pwd != null &&
                pwdConfirm != null &&
                pwd.Length > 6 &&
                pwd == pwdConfirm;
        }

        public static bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, Constants.EmailPattern);
        }
    }
}
