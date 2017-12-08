using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinChatApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);
        }
        #endregion

        #region Commands
        public ICommand SaveUserCommand { get; set; }
        #endregion

        public SettingsViewModel()
        {
            SaveUserCommand = new Command(() => App.UserService.SaveUserData());
        }

    }
}
