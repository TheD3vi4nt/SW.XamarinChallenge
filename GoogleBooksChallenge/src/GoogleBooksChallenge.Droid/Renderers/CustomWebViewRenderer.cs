using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Droid.Renderers;
using GoogleBooksChallenge.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace GoogleBooksChallenge.Droid.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    CookieManager.Instance.SetAcceptThirdPartyCookies(Control, true);
                }
                else
                {
                    CookieManager.Instance.SetAcceptCookie(true);
                }
            }            
        }
    }
}
