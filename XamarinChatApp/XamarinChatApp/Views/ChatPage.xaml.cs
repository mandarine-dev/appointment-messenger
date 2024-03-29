﻿using System;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChatApp.Models;

namespace XamarinChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage
    {
        public ChatPage()
        {
            InitializeComponent();

            // load current user in user object from userservice
            App.UserService.LoadCurrentUser();

            App.MessagesViewModel.Messages.CollectionChanged += OnMessageSent;
            // Synchronize App with Firebase and continue to listen any changes
            App.MessageService.Subscription = App.MessageService
                .SyncInRealtime()
                .Subscribe(data =>
                {
                    App.MessagesViewModel.Messages.Add(data.Object);
                    var userDetails = App.UserService.LoadUserDetails(data.Object.Sender);
                    App.MessagesViewModel.Messages[App.MessagesViewModel.CountMessages() - 1].SenderDetails = userDetails.Result;
                });
        }

        void OnMessageSent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (App.MessagesViewModel.Messages.Count > 0)
            {
                Message target = App.MessagesViewModel.Messages[App.MessagesViewModel.Messages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            }
        }

        void OnMessageSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void OnMessageTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }
    }
}