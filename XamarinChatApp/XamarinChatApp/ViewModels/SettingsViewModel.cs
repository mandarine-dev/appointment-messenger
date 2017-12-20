using Firebase.Xamarin.Auth;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinChatApp.Firebase.Auth;
using XamarinChatApp.Interfaces;
using XamarinChatApp.Services;

namespace XamarinChatApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Import services 
        public UserService _userService = App.UserService;
        #endregion

        #region Properties
        private ImageSource _profilPicture;
        public ImageSource ProfilPicture
        {
            get => _profilPicture;
            set => SetProperty(ref _profilPicture, value);
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

        private byte[] ImageBytes;
        #endregion

        #region Commands
        public ICommand SaveUserCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }
        #endregion

        public SettingsViewModel()
        {
            SaveUserCommand = new Command(async () =>
            {
                _userService.SaveUserData(new CustomUser
                {
                    Firstname = _firstname,
                    Lastname = _lastname,
                    Email = "admin@admin.fr",
                    ProfilPicture = ImageBytes
                });
            });

            UploadImageCommand = new Command(async () =>
            {
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

                if (stream != null)
                {
                    ImageBytes = getBytesArrayFromStream(stream);

                    _profilPicture = ImageSource.FromStream(() => stream);
                }
            });
        }



        byte[] getBytesArrayFromStream(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
