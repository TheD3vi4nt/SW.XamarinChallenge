using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;
using Xam.Plugin.WebView.iOS;

namespace GoogleBooksChallenge.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.InitImageSourceHandler();
            FormsWebViewRenderer.Initialize();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
