using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinChatApp.Services;
using XamarinChatApp.Views;
using XamarinChatApp.Interfaces;

namespace XamarinChatApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                RegisterCommand.CanExecute(null);
            }
        }

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set
            {
                SetProperty(ref _passwordConfirm, value);
                RegisterCommand.CanExecute(value);
            }
        }

        // TODO: Later - Allows the user to take a picture or set a photo as avatar
        //private something _avatar;
        //public something Avatar
        //{
        //    get => _avatar;
        //    set => SetProperty(ref _avatar, value);
        //}
        #endregion

        #region Commands

        public ICommand RegisterCommand { get; }

        #endregion

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register(_email, _password));
        }


        public async Task Register(string username, string password)
        {
            try
            {
                if (!ValidatorService.IsPasswordAndConfirmValid(_password, _passwordConfirm))
                {
                    ShowToast("PASSWORD_INVALID");
                    return;
                }

                if (!ValidatorService.IsEmailValid(_email))
                {
                    ShowToast("EMAIL_INVALID");
                    return;
                }

                var result = await App.AuthService.CreateEmailPasswordUser(username, password);

                if (result != null)
                {
                    await App.NavigationService.PopAsync();
                    ShowToast("USER_CREATED");
                }
            }
            catch (Exception e)
            {
                ShowToast("USER_REGISTER_FAIL");
            }
        }

        private void ShowToast(string i18NKey)
        {
            DependencyService.Get<IAlert>().ShortAlert(App.TranslationService.GetTranslation(i18NKey));
        }
    }
}
