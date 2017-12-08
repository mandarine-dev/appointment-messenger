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
                    DependencyService.Get<IAlert>().ShortAlert("Mot de passe invalide");
                    return;
                }

                if (!ValidatorService.IsEmailValid(_email))
                {
                    DependencyService.Get<IAlert>().ShortAlert("Email invalide");
                    return;
                }

                var result = await App.AuthService.CreateEmailPasswordUser(username, password);

                if (result != null)
                {
                    await App.NavigationService.PopAsync();
                    DependencyService.Get<IAlert>().ShortAlert("Utilisateur inscrit !");
                }
            }
            catch (Exception e)
            {
                DependencyService.Get<IAlert>().ShortAlert("Erreur durant l'inscription");
            }
        }
    }
}
