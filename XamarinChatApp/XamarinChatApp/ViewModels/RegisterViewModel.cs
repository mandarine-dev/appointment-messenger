using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinChatApp.Services;

namespace XamarinChatApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        // TODO: Later - Check passwords
        //private string _passwordConfirm;
        //public string PasswordConfirm
        //{
        //    get => _passwordConfirm;
        //    set => SetProperty(ref _passwordConfirm, value);
        //}

        // TODO: Later - Allows the user to take a picture or set a photo as avatar
        //private something _avatar;
        //public something Avatar
        //{
        //    get => _avatar;
        //    set => SetProperty(ref _avatar, value);
        //}
        #endregion

        #region Commands
        public ICommand RegisterCommand { get; set; }
        #endregion

        public RegisterViewModel()
        {
            // TODO: Create the Register command
            //RegisterCommand = new Command();
        }
    }
}
