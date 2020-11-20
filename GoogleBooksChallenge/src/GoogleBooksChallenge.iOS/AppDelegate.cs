using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace GoogleBooksChallenge.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.InitImageSourceHandler();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
