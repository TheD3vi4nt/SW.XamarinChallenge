using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Forms.Platforms.Android.Views;
using GoogleBooksChallenge.Core.ViewModels.Main;
using MvvmCross.Forms.Platforms.Android.Core;
using GoogleBooksChallenge.Core;
using Xam.Plugin.WebView.Droid;
using Acr.UserDialogs;

namespace GoogleBooksChallenge.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<App, UI.App>, App, UI.App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            FFImageLoading.Forms.Platform.CachedImageRenderer.InitImageViewHandler();
            FormsWebViewRenderer.Initialize();
            UserDialogs.Init(this);

            base.OnCreate(bundle);
        }
    }
}
