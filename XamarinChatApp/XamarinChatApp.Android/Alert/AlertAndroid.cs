﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinChatApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinChatApp.Droid.Alert.AlertAndroid))]
namespace XamarinChatApp.Droid.Alert
{
    public class AlertAndroid : IAlert
    {
        public void LongAlert(string message) => Toast.MakeText(Application.Context, message, ToastLength.Long).Show();

        public void ShortAlert(string message) => Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
    }
}