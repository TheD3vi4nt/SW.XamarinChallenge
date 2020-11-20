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
        public CustomWebView CustomWebView => Element as CustomWebView;

        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            Control.SetWebViewClient(new CustomWebViewClient(CustomWebView));
        }
    }

    internal class CustomWebViewClient : WebViewClient
    {
        private readonly CustomWebView _customWebView;
        internal CustomWebViewClient(CustomWebView customWebView)
        {
            _customWebView = customWebView;
        }

        public override void OnPageStarted(Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);

            _customWebView.OnNavigating(new CookieNavigationEventArgs
            {
                Url = url
            });
        }

        public override void OnPageFinished(global::Android.Webkit.WebView view, string url)
        {
            var cookieHeader = CookieManager.Instance.GetCookie(url);
            var cookies = new CookieCollection();
            var cookiePairs = cookieHeader.Split('&');            
            UserSettings.CookieContainer.SetCookies(new Uri(url), cookieHeader);

            foreach (var cookiePair in cookiePairs)
            {
                var cookiePieces = cookiePair.Split('=');
                if (cookiePieces[0].Contains(":"))
                    cookiePieces[0] = cookiePieces[0].Substring(0, cookiePieces[0].IndexOf(":"));
                cookies.Add(new Cookie
                {
                    Name = cookiePieces[0],
                    Value = cookiePieces[1]
                });                

                _customWebView.OnNavigated(new CookieNavigatedEventArgs
                {
                    Cookies = cookies,
                    Url = url
                });
            }
        }
    }
}
