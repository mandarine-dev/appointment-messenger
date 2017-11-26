using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinChatApp.Services
{
    public class NavigationService : INavigation
    {
        public Page CurrentPage { get; set; }

        public void InsertPageBefore(Page page, Page before)
        {
            CurrentPage.Navigation.InsertPageBefore(page, before);
        }

        public Task<Page> PopAsync()
        {
            return CurrentPage.Navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return CurrentPage.Navigation.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return CurrentPage.Navigation.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return CurrentPage.Navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return CurrentPage.Navigation.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return CurrentPage.Navigation.PopToRootAsync(animated);
        }

        public Task PushAsync(Page page)
        {
            return CurrentPage.Navigation.PushAsync(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return CurrentPage.Navigation.PushAsync(page, animated);
        }

        public Task PushModalAsync(Page page)
        {
            return CurrentPage.Navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return CurrentPage.Navigation.PushModalAsync(page, animated);
        }

        public void RemovePage(Page page)
        {
            CurrentPage.Navigation.RemovePage(page);
        }

        #region Do not use

        public IReadOnlyList<Page> ModalStack { get; }
        public IReadOnlyList<Page> NavigationStack { get; }

        #endregion
    }
}
