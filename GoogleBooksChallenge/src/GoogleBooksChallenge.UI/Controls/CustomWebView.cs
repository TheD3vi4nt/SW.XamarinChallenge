using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using GoogleBooksChallenge.Core.Helpers;
using Xamarin.Forms;

namespace GoogleBooksChallenge.UI.Controls
{
    public delegate void WebViewNavigatedHandler(object sender, CookieNavigatedEventArgs args);
    public delegate void WebViewNavigatingHandler(object sender, CookieNavigationEventArgs args);
    public class CustomWebView : WebView
    {
        public CookieCollection Cookies { get; protected set; }

        public event WebViewNavigatedHandler Navigated;
        public event WebViewNavigatingHandler Navigating;
        
        public virtual void OnNavigated(CookieNavigatedEventArgs args)
        {
            var eventHandler = Navigated;
            base.Cookies = UserSettings.CookieContainer;

            if (eventHandler != null)
            {
                eventHandler(this, args);
                Cookies = args.Cookies;
                
            }
        }

        public virtual void OnNavigating(CookieNavigationEventArgs args)
        {
            var eventHandler = Navigating;

            if (eventHandler != null)
            {
                eventHandler(this, args);
            }
        }
    }

    public class CookieNavigationEventArgs : EventArgs
    {
        public string Url { get; set; }
    }

    public class CookieNavigatedEventArgs : CookieNavigationEventArgs
    {
        public CookieCollection Cookies { get; set; }
        public CookieNavigationMode NavigationMode { get; set; }
    }

    public enum CookieNavigationMode
    {
        Back,
        Forward,
        New,
        Refresh,
        Reset
    }
}
